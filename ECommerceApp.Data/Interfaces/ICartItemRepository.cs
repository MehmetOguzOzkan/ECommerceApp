using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    public interface ICartItemRepository
    {
        List<CartItem> GetAll();

        List<CartItem> GetByCartIdByPage(int cartId, int page = 0, int pageSize = 20);

        List<CartItem> GetByCartId(int cartId);

        CartItem GetById(int id);

        void Add(CartItem cartItem);

        void Update(int id, CartItem cartItem);

        void Delete(int id);

        void InActive(int id);

        List<CartItem> Search(int? productId, int? cartId);

        List<CartItem> OrderByCreatedDate(List<CartItem> cartItems);

        List<CartItem> OrderByCreatedDateDescending(List<CartItem> cartItems);
    }
}
