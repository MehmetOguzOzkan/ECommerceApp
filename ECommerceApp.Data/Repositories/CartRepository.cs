using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly Context _context;

        public CartRepository(Context context)
        {
            _context = context;
        }

        public List<Cart> GetAll()
        {
            return _context.Carts.Where(b => b.IsActive == true).ToList();
        }

        public List<Cart> GetByUserId(int userId)
        {
            return _context.Carts.Where(b => b.UserId == userId).Where(b => b.IsActive == true).OrderByDescending(b=>b.CreatedDate).ToList();
        }

        public Cart GetById(int id)
        {
            return _context.Carts.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
        }

        public void Add(Cart cart)
        {
            _context.Add(cart);
            _context.SaveChanges();
        }

        public void Update(int id, Cart cart)
        {
            var c = _context.Carts.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (c is not null)
            {
                c.Note = cart.Note;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var cart = _context.Carts.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (cart is not null)
            {
                _context.Remove(cart);
                _context.SaveChanges();
            }
        }

        public void InActive(int id)
        {
            var cart = _context.Carts.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (cart is not null)
            {
                cart.IsActive=false;
                _context.SaveChanges();
            }
        }
    }
}
