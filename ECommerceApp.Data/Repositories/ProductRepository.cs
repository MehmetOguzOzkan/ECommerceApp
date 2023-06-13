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
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.Where(b => b.IsActive == true).ToList();
        }

        public List<Product> GetAllByPage(int page = 0, int pageSize = 40)
        {
            return _context.Products.Where(b => b.IsActive == true).Skip(page * pageSize).Take(pageSize).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
        }

        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            var p = _context.Products.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (p is not null)
            {
                p.Name = product.Name;
                p.Price = product.Price;
                p.Image = product.Image;
                p.CategoryId = product.CategoryId;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(b => b.Id == id);
            if (product is not null)
            {
                _context.Remove(product);
                _context.SaveChanges();
            }
        }

        public void InActive(int id)
        {
            var product = _context.Products.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (product is not null)
            {
                product.IsActive=false;
                _context.SaveChanges();
            }
        }

        public List<Product> Search(string name, int? categoryId, double? minPrice, double? maxPrice)
        {
            var query = _context.Products.Where(b=>b.IsActive==true);

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            if (categoryId.HasValue)
                query.Where(x => x.CategoryId == categoryId);

            if (minPrice.HasValue)
                query.Where(x => x.Price >= minPrice);

            if (maxPrice.HasValue)
                query.Where(x => x.Price <= maxPrice);

            return query.ToList();
        }

        public List<Product> OrderByCreatedDate(List<int> ids)
        {
            var products = _context.Products.Where(b=>ids.Contains(b.Id));
            return products.Where(b => b.IsActive == true).OrderBy(b => b.CreatedDate).ToList();
        }

        public List<Product> OrderByCreatedDateDescending(List<int> ids)
        {
            var products = _context.Products.Where(b => ids.Contains(b.Id));
            return products.Where(b => b.IsActive == true).OrderByDescending(b => b.CreatedDate).ToList();
        }

        public List<Product> OrderByName(List<int> ids)
        {
            var products = _context.Products.Where(b => ids.Contains(b.Id));
            return products.Where(b => b.IsActive == true).OrderBy(b => b.Name).ToList();
        }

        public List<Product> OrderByNameDescending(List<int> ids)
        {
            var products = _context.Products.Where(b => ids.Contains(b.Id));
            return products.Where(b => b.IsActive == true).OrderByDescending(b => b.Name).ToList();
        }

        public List<Product> OrderByPrice(List<int> ids)
        {
            var products = _context.Products.Where(b => ids.Contains(b.Id));
            return products.Where(b => b.IsActive == true).OrderBy(b => b.Price).ToList();
        }

        public List<Product> OrderByPriceDescending(List<int> ids)
        {
            var products = _context.Products.Where(b => ids.Contains(b.Id));
            return products.Where(b => b.IsActive == true).OrderByDescending(b => b.Price).ToList();
        }
    }
}
