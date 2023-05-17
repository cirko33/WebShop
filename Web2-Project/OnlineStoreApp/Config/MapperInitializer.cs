using AutoMapper;
using OnlineStoreApp.DTOs;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Config
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, EditProfileDTO>().ReverseMap();

            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();

            CreateMap<Item, OrderItemDTO>().ReverseMap();
            
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
