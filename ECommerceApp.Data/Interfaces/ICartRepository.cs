using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    public interface ICartRepository
    {
        List<Cart> GetAll();

        List<Cart> GetByUserId(int userId);

        Cart GetById(int id);

        void Add(Cart cart);

        void Update(int id, Cart cart);

        void Delete(int id);

        void InActive(int id);
    }
}
