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
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.Where(b=>b.IsActive==true).ToList();
        }

        public List<User> GetAllByPage(int page = 0, int pageSize = 20)
        {
            return _context.Users.Where(b=>b.IsActive==true).Skip(page*pageSize).Take(pageSize).ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Where(b => b.IsActive == true).FirstOrDefault(b=>b.Id==id);
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(b => b.Email == email && b.Password == password);
        }

        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, User user) 
        {
            var u = _context.Users.Where(b=>b.IsActive==true).FirstOrDefault(b=>b.Id==id);
            if (u is not null)
            {
                u.Name= user.Name;
                u.Email= user.Email;
                u.Password= user.Password;
                u.Phone= user.Phone;
                u.BirthDate= user.BirthDate;
                u.Gender = user.Gender;
                u.RoleId= user.RoleId;
                _context.SaveChanges();
            }
        }

        public void AuthUpdate(int id, User user)
        {
            var u = _context.Users.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if(u is not null)
            {
                u.RefreshToken = user.RefreshToken;
                u.RefreshTokenExpireDate = user.RefreshTokenExpireDate;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = _context.Users.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (user is not null)
            {
                var addresses = _context.Addresses.ToList();
                var cards = _context.Cards.Where(b => b.UserId == user.Id).ToList();
                _context.Remove(addresses);
                _context.Remove(cards);
                _context.Remove(user);
                _context.SaveChanges();
            }
        }

        public void InActive(int id)
        {
            var user = _context.Users.Where(b=>b.IsActive==true).FirstOrDefault(b => b.Id == id);
            if (user is not null)
            {
                var addresses = _context.Addresses.Where(b=>b.UserId==user.Id).ToList();
                var cards = _context.Cards.Where(b => b.UserId == user.Id).ToList();
                addresses.ForEach(b => b.IsActive = false);
                cards.ForEach(b => b.IsActive=false);
                user.IsActive = false;
                _context.SaveChanges();
            }
        }

        public List<User> Search(string name,int? roleId,string email)
        {
            var query = _context.Users.Where(b=>b.IsActive==true).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            if (roleId.HasValue)
                query.Where(x => x.RoleId == roleId);

            if (!string.IsNullOrWhiteSpace(email))
                query.Where(x => x.Email.Contains(email));

            return query.ToList();
        }

        public List<User> OrderByCreatedDate(List<int> ids)
        {
            var users = _context.Users.Where(b => ids.Contains(b.Id));
            return users.Where(b=>b.IsActive==true).OrderBy(b=>b.CreatedDate).ToList();
        }

        public List<User> OrderByCreatedDateDescending(List<int> ids)
        {
            var users = _context.Users.Where(b => ids.Contains(b.Id));
            return users.Where(b => b.IsActive == true).OrderByDescending(b => b.CreatedDate).ToList();
        }

        public List<User> OrderByName(List<int> ids)
        {
            var users = _context.Users.Where(b => ids.Contains(b.Id));
            return users.Where(b => b.IsActive == true).OrderBy(b => b.Name).ToList();
        }

        public List<User> OrderByNameDescending(List<int> ids)
        {
            var users = _context.Users.Where(b => ids.Contains(b.Id));
            return users.Where(b => b.IsActive == true).OrderByDescending(b => b.Name).ToList();
        }
    }
}
