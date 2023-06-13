using AutoMapper;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using ECommerceApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public List<GetOrderDTO> GetAll()
        {
            var orders = _orderRepository.GetAll();
            var getOrderDTOs = new List<GetOrderDTO>();
            orders.ForEach(b => getOrderDTOs.Add(_mapper.Map<GetOrderDTO>(b)));
            return getOrderDTOs;
        }

        public GetOrderDTO GetById(int id)
        {
            return _mapper.Map<GetOrderDTO>(_orderRepository.GetById(id));
        }

        public List<GetOrderDTO> GetByCartId(int cartId)
        {
            var orders = _orderRepository.GetByCartId(cartId);
            var getOrderDTOs = new List<GetOrderDTO>();
            orders.ForEach(b => getOrderDTOs.Add(_mapper.Map<GetOrderDTO>(b)));
            return getOrderDTOs;
        }

        public List<GetOrderDTO> GetByUserId (int userId)
        {
            var orders = _orderRepository.GetByUserId(userId);
            var getOrderDTOs = new List<GetOrderDTO>();
            orders.ForEach(b => getOrderDTOs.Add(_mapper.Map<GetOrderDTO>(b)));
            return getOrderDTOs;
        }

        public List<GetOrderDTO> GetAllByPage(int page = 0, int pageSize = 20)
        {
            var orders = _orderRepository.GetAllByPage(page, pageSize);
            var getOrderDTOs = new List<GetOrderDTO>();
            orders.ForEach(b => getOrderDTOs.Add(_mapper.Map<GetOrderDTO>(b)));
            return getOrderDTOs;
        }

        public ServiceResult<GetOrderDTO> Create(CreateOrderDTO createOrderDTO)
        {
            var order = _mapper.Map<Order>(createOrderDTO);
            if (order is null) return ServiceResult<GetOrderDTO>.Failed(null, "Not Found", 400);

            _orderRepository.Add(order);
            return ServiceResult<GetOrderDTO>.Success(_mapper.Map<GetOrderDTO>(order));
        }

        public ServiceResult<GetOrderDTO> Update(int id, UpdateOrderDTO updateOrderDTO)
        {
            var order = _orderRepository.GetById(id);
            if (order is null) return ServiceResult<GetOrderDTO>.Failed(null, "Not Found", 404);

            order = _mapper.Map<Order>(updateOrderDTO);
            if (order is null) return ServiceResult<GetOrderDTO>.Failed(null, "Not Found", 400);

            _orderRepository.Update(id, order);
            return ServiceResult<GetOrderDTO>.Success(_mapper.Map<GetOrderDTO>(order));
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }

        public void InActive(int id)
        {
            _orderRepository.InActive(id);
        }
    }
}
