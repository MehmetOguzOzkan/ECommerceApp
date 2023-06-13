using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();

        List<Order> GetAllByPage(int page = 0, int pageSize = 20);

        List<Order> GetByCartId(int cartId);

        Order GetById(int id);

        List<Order> GetByUserId(int userId);

        void Add(Order order);

        void Update(int id, Order order);

        void Delete(int id);

        void InActive(int id);
    }
}
