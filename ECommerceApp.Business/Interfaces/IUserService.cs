using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface IUserService
    {
        List<GetUserDTO> GetAll();

        GetUserDTO GetById(int id);

        GetAuthUserDTO GetByEmailAndPassword(string email, string password);

        List<GetUserDTO> GetAllByPage(int page = 0, int pageSize = 20);

        ServiceResult<GetUserDTO> Create(CreateUserDTO createUserDTO);

        ServiceResult<GetUserDTO> Update(int id, UpdateUserDTO updateUserDTO);
        ServiceResult<GetAuthUserDTO> AuthUpdate(int id, UpdateUserDTO updateUserDTO);

        void Delete(int id);

        void InActive(int id);

        List<GetUserDTO> Search(string name, int? roleId, string email);

        List<GetUserDTO> OrderByCreatedDate(List<int> ids);

        List<GetUserDTO> OrderByCreatedDateDescending(List<int> ids);

        List<GetUserDTO> OrderByName(List<int> ids);

        List<GetUserDTO> OrderByNameDescending(List<int> ids);
    }
}
