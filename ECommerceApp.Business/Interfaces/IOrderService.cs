using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface IOrderService
    {
        List<GetOrderDTO> GetAll();

        GetOrderDTO GetById(int id);

        List<GetOrderDTO> GetByCartId(int cartId);

        List<GetOrderDTO> GetByUserId(int userId);

        List<GetOrderDTO> GetAllByPage(int page = 0, int pageSize = 20);

        ServiceResult<GetOrderDTO> Create(CreateOrderDTO createOrderDTO);

        ServiceResult<GetOrderDTO> Update(int id, UpdateOrderDTO updateOrderDTO);

        void Delete(int id);

        void InActive(int id);
    }
}
