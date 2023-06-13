using AutoMapper;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;
using System.Collections.Generic;

namespace ECommerceApp.Presentation.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,GetProductDTO>().ReverseMap();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<Category, GetCategoryDTO>().ReverseMap();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<Address, GetAddressDTO>().ReverseMap();
            CreateMap<CreateAddressDTO, Address>();
            CreateMap<UpdateAddressDTO, Address>();
            CreateMap<Card, GetCardDTO>().ReverseMap();
            CreateMap<CreateCardDTO, Card>();
            CreateMap<UpdateCardDTO, Card>();
            CreateMap<Role, GetRoleDTO>().ReverseMap();
            CreateMap<CreateRoleDTO, Role>();
            CreateMap<UpdateRoleDTO, Role>();
            CreateMap<User, GetUserDTO>().ReverseMap();
            CreateMap<User,GetAuthUserDTO>().ReverseMap();
            CreateMap<GetAuthUserDTO, UpdateUserDTO>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<Cart, GetCartDTO>().ReverseMap();
            CreateMap<CreateCartDTO, Cart>();
            CreateMap<UpdateCartDTO, Cart>();
            CreateMap<CartItem, GetCartItemDTO>().ReverseMap();
            CreateMap<CreateCartItemDTO, CartItem>();
            CreateMap<UpdateCartItemDTO, CartItem>();
        }
    }
}
