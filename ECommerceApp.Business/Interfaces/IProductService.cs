using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface IProductService
    {
        List<GetProductDTO> GetAll();

        GetProductDTO GetById(int id);

        List<GetProductDTO> GetAllByPage(int page = 0, int pageSize = 40);

        ServiceResult<GetProductDTO> Create(CreateProductDTO createProductDTO);

        ServiceResult<GetProductDTO> Update(int id, UpdateProductDTO updateProductDTO);

        void Delete(int id);

        void InActive(int id);

        List<GetProductDTO> Search(string name, int? categoryId, double? minPrice, double? maxPrice);
        
        List<GetProductDTO> OrderByCreatedDate(List<int> ids);

        List<GetProductDTO> OrderByCreatedDateDescending(List<int> ids);

        List<GetProductDTO> OrderByName(List<int> ids);

        List<GetProductDTO> OrderByNameDescending(List<int> ids);

        List<GetProductDTO> OrderByPrice(List<int> ids);

        List<GetProductDTO> OrderByPriceDescending(List<int> ids);
    }
}
