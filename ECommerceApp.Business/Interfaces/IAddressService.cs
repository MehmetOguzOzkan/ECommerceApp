using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface IAddressService
    {
        List<GetAddressDTO> GetAll();

        GetAddressDTO GetById(int id);

        List<GetAddressDTO> GetByUserId(int userId);

        List<GetAddressDTO> GetAllByPage(int page = 0, int pageSize = 40);

        ServiceResult<GetAddressDTO> Create(CreateAddressDTO createAddressDTO);

        ServiceResult<GetAddressDTO> Update(int id, UpdateAddressDTO updateAddressDTO);

        void Delete(int id);

        void InActive(int id);

        List<GetAddressDTO> Search(string city, string district, string neighborhood, string street, string number, int? postalCode, int? userId);

        List<GetAddressDTO> OrderByCreatedDate(List<int> ids);

        List<GetAddressDTO> OrderByCreatedDateDescending(List<int> ids);

        List<GetAddressDTO> OrderByAddress(List<int> ids);

        List<GetAddressDTO> OrderByAddressDescending(List<int> ids);
    }
}
