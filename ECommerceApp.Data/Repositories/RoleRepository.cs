using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly Context _context;

        public RoleRepository(Context context)
        {
            _context = context;
        }

        public List<Role> GetAll()
        {
            return _context.Roles.Where(b => b.IsActive == true).ToList();
        }
        public Role GetById(int id)
        {
            return _context.Roles.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
        }

        public void Add(Role role)
        {
            _context.Add(role);
            _context.SaveChanges();
        }

        public void Update(int id, Role role)
        {
            var r = _context.Roles.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (r is not null)
            {
                r.Name = role.Name;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var role = _context.Roles.FirstOrDefault(b => b.Id == id);
            if (role is not null)
            {
                var users = _context.Users.Where(b => b.RoleId==role.Id).ToList();
                _context.RemoveRange(users);
                _context.Remove(role);
                _context.SaveChanges();
            }
        }

        public void InActive(int id)
        {
            var role = _context.Roles.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (role is not null)
            {
                var users = _context.Users.Where(b => b.RoleId == role.Id).ToList();
                users.ForEach(b => b.IsActive = false);
                role.IsActive = false;
                _context.SaveChanges();
            }
        }

        public List<Role> Search(string name)
        {
            var query = _context.Roles.Where(b => b.IsActive == true).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            return query.ToList();
        }

        public List<Role> OrderByCreatedDate(List<int> ids)
        {
            var roles = _context.Roles.Where(b => ids.Contains(b.Id));
            return roles.Where(b => b.IsActive == true).OrderBy(b => b.CreatedDate).ToList();
        }

        public List<Role> OrderByCreatedDateDescending(List<int> ids)
        {
            var roles = _context.Roles.Where(b => ids.Contains(b.Id));
            return roles.Where(b => b.IsActive == true).OrderByDescending(b => b.CreatedDate).ToList();
        }

        public List<Role> OrderByName(List<int> ids)
        {
            var roles = _context.Roles.Where(b => ids.Contains(b.Id));
            return roles.Where(b => b.IsActive == true).OrderBy(b => b.Name).ToList();
        }

        public List<Role> OrderByNameDescending(List<int> ids)
        {
            var roles = _context.Roles.Where(b => ids.Contains(b.Id));
            return roles.Where(b => b.IsActive == true).OrderByDescending(b => b.Name).ToList();
        }
    }
}
