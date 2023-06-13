using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface ICategoryService
    {
        List<GetCategoryDTO> GetAll();

        GetCategoryDTO GetById(int id);

        ServiceResult<GetCategoryDTO> Create(CreateCategoryDTO createCategoryDTO);

        ServiceResult<GetCategoryDTO> Update(int id, UpdateCategoryDTO updateCategoryDTO);

        void Delete(int id);

        void InActive(int id);

        List<GetCategoryDTO> Search(string name);

        List<GetCategoryDTO> OrderByCreatedDate(List<int> ids);

        List<GetCategoryDTO> OrderByCreatedDateDescending(List<int> ids);

        List<GetCategoryDTO> OrderByName(List<int> ids);

        List<GetCategoryDTO> OrderByNameDescending(List<int> ids);
    }
}
