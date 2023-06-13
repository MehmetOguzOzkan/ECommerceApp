using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly Context _context;

        public CartItemRepository(Context context)
        {
            _context = context;
        }

        public List<CartItem> GetAll()
        {
            return _context.CartItems.Where(b => b.IsActive == true).ToList();
        }

        public List<CartItem> GetByCartIdByPage(int cartId, int page = 0, int pageSize = 20)
        {
            return _context.CartItems.Where(b => b.CartId == cartId).Where(b => b.IsActive == true).Skip(page * pageSize).Take(pageSize).ToList();
        }

        public List<CartItem> GetByCartId(int cartId)
        {
            return _context.CartItems.Where(b => b.CartId == cartId).Where(b => b.IsActive == true).ToList();
        }

        public CartItem GetById(int id)
        {
            return _context.CartItems.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
        }

        public void Add(CartItem cartItem)
        {
            _context.Add(cartItem);
            _context.SaveChanges();
        }

        public void Update(int id, CartItem cartItem)
        {
            var item = _context.CartItems.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (item is not null)
            {
                item.Quantity = cartItem.Quantity;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = _context.CartItems.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (item is not null)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
        }

        public void InActive(int id)
        {
            var item = _context.CartItems.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (item is not null)
            {
                item.IsActive=false;
                _context.SaveChanges();
            }
        }

        public List<CartItem> Search(int? productId, int? cartId)
        {
            var query = _context.CartItems.Where(b => b.IsActive == true).AsQueryable();

            if (cartId.HasValue)
                query.Where(x => x.CartId == cartId);

            if (productId.HasValue)
                query.Where(x => x.ProductId == productId);

            return query.ToList();
        }

        public List<CartItem> OrderByCreatedDate(List<CartItem> cartItems)
        {
            return cartItems.Where(b => b.IsActive == true).OrderBy(b => b.CreatedDate).ToList();
        }

        public List<CartItem> OrderByCreatedDateDescending(List<CartItem> cartItems)
        {
            return cartItems.Where(b => b.IsActive == true).OrderByDescending(b => b.CreatedDate).ToList();
        }
    }
}
