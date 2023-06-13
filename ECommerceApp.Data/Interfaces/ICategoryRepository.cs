using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();

        Category GetById(int id);

        void Add(Category category);

        void Update(int id, Category category);

        void Delete(int id);

        void InActive(int id);

        List<Category> Search(string name);

        List<Category> OrderByCreatedDate(List<int> ids);

        List<Category> OrderByCreatedDateDescending(List<int> ids);

        List<Category> OrderByName(List<int> ids);

        List<Category> OrderByNameDescending(List<int> ids);
    }
}
