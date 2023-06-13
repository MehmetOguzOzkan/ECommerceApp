using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly Context _context;

        public AddressRepository(Context context)
        {
            _context = context;
        }

        public List<Address> GetAll()
        {
            return _context.Addresses.Where(b => b.IsActive == true).OrderBy(b=>b.City).ToList();
        }

        public List<Address> GetAllByPage(int page = 0, int pageSize = 40)
        {
            return _context.Addresses.Where(b => b.IsActive == true).OrderBy(b=>b.City).Skip(page * pageSize).Take(pageSize).ToList();
        }

        public List<Address> GetAllByUserId(int userId)
        {
            return _context.Addresses.Where(b => b.IsActive == true).Where(b => b.UserId == userId).ToList();
        }

        public Address GetById(int id)
        {
            return _context.Addresses.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
        }

        public void Add(Address address)
        {
            _context.Add(address);
            _context.SaveChanges();
        }

        public void Update(int id, Address address)
        {
            var a = _context.Addresses.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == address.Id);
            if (a is not null)
            {
                a.City = address.City;
                a.District = address.District;
                a.Neighborhood = address.Neighborhood;
                a.Street = address.Street;
                a.Number = address.Number;
                a.PostalCode = address.PostalCode;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var address = _context.Addresses.FirstOrDefault(b => b.Id == id);
            if (address is not null)
            {
                _context.Remove(address);
                _context.SaveChanges();
            }
        }

        public void InActive(int id)
        {
            var address = _context.Addresses.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (address is not null)
            {
                address.IsActive = false;
                _context.SaveChanges();
            }
        }

        public List<Address> Search(string city, string district, string neighborhood, string street, string number, int? postalCode, int? userId)
        {
            var query = _context.Addresses.Where(b => b.IsActive == true).AsQueryable();

            if (!string.IsNullOrWhiteSpace(city))
                query.Where(x => x.City.Contains(city));

            if (!string.IsNullOrWhiteSpace(district))
                query.Where(x => x.District.Contains(district));

            if (!string.IsNullOrWhiteSpace(neighborhood))
                query.Where(x => x.Neighborhood.Contains(neighborhood));

            if (!string.IsNullOrWhiteSpace(street))
                query.Where(x => x.Street.Contains(street));

            if (!string.IsNullOrWhiteSpace(number))
                query.Where(x => x.Number.Contains(number));

            if (userId.HasValue)
                query.Where(x => x.UserId == userId);

            if (postalCode.HasValue)
                query.Where(x => x.PostalCode == postalCode);

            return query.ToList();
        }

        public List<Address> OrderByCreatedDate(List<int> ids)
        {
            var addresses = _context.Addresses.Where(b => ids.Contains(b.Id));
            return addresses.Where(b => b.IsActive == true).OrderBy(b => b.CreatedDate).ToList();
        }

        public List<Address> OrderByCreatedDateDescending(List<int> ids)
        {
            var addresses = _context.Addresses.Where(b => ids.Contains(b.Id));
            return addresses.Where(b => b.IsActive == true).OrderByDescending(b => b.CreatedDate).ToList();
        }

        public List<Address> OrderByAddress(List<int> ids)
        {
            var addresses = _context.Addresses.Where(b => ids.Contains(b.Id));
            return addresses.Where(b => b.IsActive == true)
                .OrderBy(b => b.City).ThenBy(b=>b.District).ThenBy(b=>b.Neighborhood)
                .ThenBy(b=>b.Street).ThenBy(b=>b.Number)
                .ToList();
        }

        public List<Address> OrderByAddressDescending(List<int> ids)
        {
            var addresses = _context.Addresses.Where(b => ids.Contains(b.Id));
            return addresses.Where(b => b.IsActive == true)
                .OrderByDescending(b => b.City).ThenByDescending(b => b.District)
                .ThenByDescending(b => b.Neighborhood).ThenByDescending(b => b.Street)
                .ThenByDescending(b => b.Number).ToList();
        }
    }
}
