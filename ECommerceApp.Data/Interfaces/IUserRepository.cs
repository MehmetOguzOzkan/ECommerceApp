using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();

        List<User> GetAllByPage(int page = 0, int pageSize = 20);

        User GetById(int id);
        User GetByEmailAndPassword(string email, string password);

        void Add(User user);

        void Update(int id, User user);

        void AuthUpdate(int id, User user);

        void Delete(int id);

        void InActive(int id);

        List<User> Search(string name, int? role, string email);

        List<User> OrderByCreatedDate(List<int> idss);

        List<User> OrderByCreatedDateDescending(List<int> ids);

        List<User> OrderByName(List<int> ids);

        List<User> OrderByNameDescending(List<int> ids);
    }
}
