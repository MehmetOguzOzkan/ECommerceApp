using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders.Where(b => b.IsActive == true).OrderByDescending(b=>b.CreatedDate).ToList();
        }

        public List<Order> GetByCartId(int cartId)
        {
            return _context.Orders.Where(b => b.CartId == cartId).Where(b => b.IsActive == true).OrderByDescending(b=>b.CreatedDate).ToList();
        }

        public List<Order> GetAllByPage(int page = 0, int pageSize = 20)
        {
            return _context.Orders.Where(b => b.IsActive == true).OrderByDescending(b=>b.CreatedDate).Skip(page * pageSize).Take(pageSize).ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
        }

        public List<Order> GetByUserId(int userId)
        {
            List<Cart> carts = _context.Carts.Where(b => b.UserId == userId).ToList();
            List<int> cartIds = carts.Select(b => b.Id).ToList();
            List<Order> orders = _context.Orders.Where(b=>cartIds.Contains(b.CartId)).ToList();
            return orders.OrderByDescending(b=>b.CreatedDate).ToList();
        }

        public void Add(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
        }

        public void Update(int id, Order order)
        {
            var o = _context.Orders.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (o is not null)
            {
                o.AddressId = order.AddressId;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var order = _context.Orders.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (order is not null)
            {
                _context.Remove(order);
                _context.SaveChanges();
            }
        }

        public void InActive(int id)
        {
            var order = _context.Orders.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (order is not null)
            {
                order.IsActive=false;
                _context.SaveChanges();
            }
        }
    }
}
