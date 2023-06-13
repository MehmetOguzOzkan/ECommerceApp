using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        List<Product> GetAllByPage(int page = 0, int pageSize = 40);

        Product GetById(int id);

        void Add(Product product);

        void Update(int id, Product product);

        void Delete(int id);

        void InActive(int id);

        List<Product> Search(string name, int? categoryId, double? minPrice, double? maxPrice);
        List<Product> OrderByCreatedDate(List<int> ids);

        List<Product> OrderByCreatedDateDescending(List<int> ids);

        List<Product> OrderByName(List<int> ids);

        List<Product> OrderByNameDescending(List<int> ids);

        List<Product> OrderByPrice(List<int> ids);

        List<Product> OrderByPriceDescending(List<int> ids);
    }
}
