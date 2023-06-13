using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> GetAll();

        Role GetById(int id);

        void Add(Role role);

        void Update(int id, Role role);

        void Delete(int id);

        void InActive(int id);

        List<Role> Search(string name);

        List<Role> OrderByCreatedDate(List<int> ids);

        List<Role> OrderByCreatedDateDescending(List<int> ids);

        List<Role> OrderByName(List<int> ids);

        List<Role> OrderByNameDescending(List<int> ids);
    }
}
