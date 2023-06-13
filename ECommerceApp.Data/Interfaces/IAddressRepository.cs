using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAll();

        List<Address> GetAllByPage(int page = 0, int pageSize = 40);

        List<Address> GetAllByUserId(int userId);

        Address GetById(int id);

        void Add(Address address);

        void Update(int id, Address address);

        void Delete(int id);

        void InActive(int id);

        List<Address> Search(string city, string district, string neighborhood, string street, string number, int? postalCode, int? userId);

        List<Address> OrderByCreatedDate(List<int> ids);

        List<Address> OrderByCreatedDateDescending(List<int> ids);

        List<Address> OrderByAddress(List<int> ids);

        List<Address> OrderByAddressDescending(List<int> ids);
    }
}
