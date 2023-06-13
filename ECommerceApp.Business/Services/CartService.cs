using AutoMapper;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepsitory,IMapper mapper)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepsitory;
            _mapper = mapper;
        }

        public List<GetCartDTO> GetAll()
        {
            var carts = _cartRepository.GetAll();
            var getCartDTOs = new List<GetCartDTO>();
            carts.ForEach(b => getCartDTOs.Add(_mapper.Map<GetCartDTO>(b)));
            return getCartDTOs;
        }

        public GetCartDTO GetByUserId(int userId)
        {
            return _mapper.Map<GetCartDTO>(_cartRepository.GetByUserId(userId));
        }

        public GetCartDTO GetById(int id)
        {
            var cart = _cartRepository.GetById(id);
            var getCartDTO = _mapper.Map<GetCartDTO>(cart);
            return getCartDTO;
        }

        public ServiceResult<GetCartItemDTO> AddItem(CreateCartItemDTO createCartItemDTO)
        {
            var cartItem = _mapper.Map<CartItem>(createCartItemDTO);
            if (cartItem is null) return ServiceResult<GetCartItemDTO>.Failed(null, "Not Found", 400);

            _cartItemRepository.Add(cartItem);
            return ServiceResult<GetCartItemDTO>.Success(_mapper.Map<GetCartItemDTO>(cartItem));
        }

        public ServiceResult<GetCartItemDTO> UpdateItem(int id, UpdateCartItemDTO updateCartItemDTO)
        {
            var cartItem = _cartItemRepository.GetById(id);
            if (cartItem is null) return ServiceResult<GetCartItemDTO>.Failed(null, "Not Found", 404);

            cartItem = _mapper.Map<CartItem>(updateCartItemDTO);
            if (cartItem is null) return ServiceResult<GetCartItemDTO>.Failed(null, "Not Found", 400);

            _cartItemRepository.Update(id, cartItem);
            return ServiceResult<GetCartItemDTO>.Success(_mapper.Map<GetCartItemDTO>(cartItem));
        }

        public ServiceResult<GetCartDTO> Create(CreateCartDTO createCartDTO)
        {
            var cart = _mapper.Map<Cart>(createCartDTO);
            if (cart is null) return ServiceResult<GetCartDTO>.Failed(null, "Not Found", 400);

            _cartRepository.Add(cart);
            return ServiceResult<GetCartDTO>.Success(_mapper.Map<GetCartDTO>(cart));
        }

        public ServiceResult<GetCartDTO> Update(int id, UpdateCartDTO updateCartDTO)
        {
            var cart = _cartRepository.GetById(id);
            if (cart is null) return ServiceResult<GetCartDTO>.Failed(null, "Not Found", 404);

            cart = _mapper.Map<Cart>(updateCartDTO);
            if (cart is null) return ServiceResult<GetCartDTO>.Failed(null, "Not Found", 400);

            _cartRepository.Update(id, cart);
            return ServiceResult<GetCartDTO>.Success(_mapper.Map<GetCartDTO>(cart));
        }

        public void DeleteItem(int id)
        {
            _cartItemRepository.Delete(id);
        }

        public void Delete(int id)
        {
            _cartRepository.Delete(id);
        }

        public void InActiveItem(int id)
        {
            _cartItemRepository.InActive(id);
        }

        public void InActive(int id)
        {
            _cartRepository.InActive(id);
        }
    }
}
