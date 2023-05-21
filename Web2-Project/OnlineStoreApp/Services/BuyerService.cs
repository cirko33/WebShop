using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineStoreApp.DTOs;
using OnlineStoreApp.Exceptions;
using OnlineStoreApp.Interfaces;
using OnlineStoreApp.Interfaces.IServices;
using OnlineStoreApp.Models;
using System.Security.Cryptography.Xml;

namespace OnlineStoreApp.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BuyerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateOrder(CreateOrderDTO createOrder, int userId)
        {
            var order = _mapper.Map<Order>(createOrder);
            if ((await _unitOfWork.Users.Get(x => x.Id == userId)) == null)
                throw new BadRequestException($"User doesn't exist.");

            order.UserId = userId;
            foreach (var item in order.Items!)
            {
                var product = await _unitOfWork.Products.Get(x => x.Id == item.ProductId);
                if (product == null)
                    throw new BadRequestException("Invalid Product ID.");

                if (item.Amount < 0)
                    throw new BadRequestException($"Amount of {product.Name} can't be less than 0.");

                if (item.Amount > product.Amount)
                    throw new BadRequestException($"System doesn't have enough {product.Name}.");

                product.Amount -= item.Amount;
                _unitOfWork.Products.Update(product);
            }

            order.DeliveryTime = DateTime.Now.AddHours(1).AddMinutes(new Random().Next(59));
            await _unitOfWork.Orders.Insert(order);
            await _unitOfWork.Save();
        }

        public async Task CancelOrder(int userId, int id)
        {
            var user = await _unitOfWork.Users.Get(x => x.Id == userId, new List<string> { "Orders.Items.Product" });
            if(user == null)
                throw new BadRequestException($"User doesn't exist.");

            var order = user.Orders!.First(x => x.Id == id);
            if (order == null)
                throw new NotFoundException($"Order doesn't belong to user.");


            if(order.OrderTime.AddHours(1) < DateTime.Now)
                throw new BadRequestException($"You can only cancel if it hasn't been an hour of order creation");

            order.IsCancelled = true;
            foreach (var item in order.Items!)
            {
                item.Product!.Amount += item.Amount;
                _unitOfWork.Products.Update(item.Product);
            }

            _unitOfWork.Orders.Update(order);
            await _unitOfWork.Save();
        }

        public async Task<List<OrderDTO>> GetMyOrders(int userId)
        {
            var user = await _unitOfWork.Users.Get(x => x.Id == userId, new List<string> { "Orders.Items.Product" });
            if (user == null)
                throw new BadRequestException($"User doesn't exist.");

            var orders = user.Orders!.FindAll(x => !x.IsCancelled);
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var products = await _unitOfWork.Products.GetAll();
            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}
