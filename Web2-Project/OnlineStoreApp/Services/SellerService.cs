using AutoMapper;
using OnlineStoreApp.DTOs;
using OnlineStoreApp.Exceptions;
using OnlineStoreApp.Interfaces;
using OnlineStoreApp.Interfaces.IServices;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Services
{
    public class SellerService : ISellerService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public SellerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddImage(int id, int userId, IFormFile image)
        {
            var user = await _unitOfWork.Users.Get(x => x.Id == userId, new List<string> { "Products" }) ?? throw new UnauthorizedException("Error with id in token. Logout and login again");
            var product = user.Products!.Find(x => x.Id == id) ?? throw new UnauthorizedException("Product doesn't belong to you.");

            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                product.Image = ms.ToArray();
            }

            _unitOfWork.Products.Update(product);
            await _unitOfWork.Save();
        }

        public async Task AddProduct(CreateProductDTO product, int userId)
        {
            var prod = _mapper.Map<Product>(product);
            if((await _unitOfWork.Users.Get(x => x.Id == userId)) == null)
                throw new BadRequestException("Error with id in token. Logout and login again");

            prod.SellerId = userId;
            await _unitOfWork.Products.Insert(prod);
            await _unitOfWork.Save();
        }

        public async Task DeleteProduct(int id, int userId)
        {
            var user = await _unitOfWork.Users.Get(x => x.Id == userId, new List<string> { "Products" }) ?? throw new UnauthorizedException("Error with id in token. Logout and login again");

            var product = user.Products!.Find(x => x.Id == id) ?? throw new UnauthorizedException("This product isn't yours");

            product.IsDeleted = true;
            _unitOfWork.Products.Update(product);
            await _unitOfWork.Save();
        }

        public async Task<List<OrderDTO>> GetNewOrders(int userId)
        {
            var user = await _unitOfWork.Users.Get(x => x.Id == userId, new List<string> { "Products" }) ?? throw new UnauthorizedException("Error with id in token. Logout and login again");

            var orders = await _unitOfWork.Orders.GetAll(x => x.OrderStatus == OrderStatus.InDelivery, null, new List<string> { "Items" });
            if(orders != null)
                orders = orders.ToList().FindAll(x => x.Items!.Any(x => user.Products!.Select(x => x.Id).Contains(x.Id)));
                
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<List<OrderDTO>> GetOrders(int userId)
        {
            var user = await _unitOfWork.Users.Get(x => x.Id == userId, new List<string> { "Products" }) ?? throw new UnauthorizedException("Error with id in token. Logout and login again");

            var orders = await _unitOfWork.Orders.GetAll(null, null, new List<string> { "Items" });
            if (orders != null)
                orders = orders.ToList().FindAll(x => x.Items!.Any(x => user.Products!.Select(x => x.Id).Contains(x.Id)));

            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<ProductDTO> GetProduct(int id, int userId)
        {
            var user = await _unitOfWork.Users.Get(x => x.Id == userId, new List<string> { "Products" }) ?? throw new UnauthorizedException("Error with id in token. Logout and login again");

            var product = user.Products!.Find(x => x.Id == id);
            if (product == null)
                throw new BadRequestException("This product doesn't belong to you");

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<List<ProductDTO>> GetProducts(int userId)
        {
            var user = await _unitOfWork.Users.Get(x => x.Id == userId, new List<string> { "Products" }) ?? throw new UnauthorizedException("Error with id in token. Logout and login again");
            return _mapper.Map<List<ProductDTO>>(user.Products!);
        }

        public async Task UpdateProduct(int id, ProductDTO product, int userId)
        {
            var user = await _unitOfWork.Users.Get(x => x.Id == userId, new List<string> { "Products" }) ?? throw new UnauthorizedException("Error with id in token. Logout and login again");
            var prod = user.Products!.Find(x => x.Id == id) ?? throw new UnauthorizedException("This product doesn't belong to you");

            prod.Amount = product.Amount;
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Price = product.Price;
        }
    }
}
