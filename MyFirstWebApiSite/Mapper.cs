using AutoMapper;
using DTO;
using Services;

namespace MyFirstWebApiSite
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }
    }
}
