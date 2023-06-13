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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.Where(b => b.IsActive == true).ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
        }

        public void Add(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void Update(int id, Category category)
        {
            var c = _context.Categories.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (c is not null)
            {
                c.Name = category.Name;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(b => b.Id == id);
            if (category is not null)
            {
                var products = _context.Products.Where(b => b.CategoryId == id).ToList();
                if(products is not null) 
                    _context.RemoveRange(products);
                _context.Remove(category);
                _context.SaveChanges();
            }
        }

        public void InActive(int id)
        {
            var category = _context.Categories.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (category is not null)
            {
                var products = _context.Products.Where(b => b.CategoryId == id).ToList();
                products.ForEach(b => b.IsActive=false);
                category.IsActive=false;
                _context.SaveChanges();
            }
        }

        public List<Category> Search(string name)
        {
            var query = _context.Categories.Where(b => b.IsActive == true).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            return query.ToList();
        }

        public List<Category> OrderByCreatedDate(List<int> ids)
        {
            var categories = _context.Categories.Where(b => ids.Contains(b.Id));
            return categories.Where(b => b.IsActive == true).OrderBy(b => b.CreatedDate).ToList();
        }

        public List<Category> OrderByCreatedDateDescending(List<int> ids)
        {    
            var categories = _context.Categories.Where(b => ids.Contains(b.Id));
            return categories.Where(b => b.IsActive == true).OrderByDescending(b => b.CreatedDate).ToList();
        }

        public List<Category> OrderByName(List<int> ids)
        {
            var categories = _context.Categories.Where(b => ids.Contains(b.Id));
            return categories.Where(b => b.IsActive == true).OrderBy(b => b.Name).ToList();
        }

        public List<Category> OrderByNameDescending(List<int> ids)
        {
            var categories = _context.Categories.Where(b => ids.Contains(b.Id));
            return categories.Where(b => b.IsActive == true).OrderByDescending(b => b.Name).ToList();
        }
    }
}
