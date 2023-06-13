using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface IRoleService
    {
        List<GetRoleDTO> GetAll();

        GetRoleDTO GetById(int id);

        ServiceResult<GetRoleDTO> Create(CreateRoleDTO createRoleDTO);

        ServiceResult<GetRoleDTO> Update(int id, UpdateRoleDTO updateRoleDTO);

        void Delete(int id);

        void InActive(int id);

        List<GetRoleDTO> Search(string name);

        List<GetRoleDTO> OrderByCreatedDate(List<int> ids);

        List<GetRoleDTO> OrderByCreatedDateDescending(List<int> ids);

        List<GetRoleDTO> OrderByName(List<int> ids);

        List<GetRoleDTO> OrderByNameDescending(List<int> ids);
    }
}
