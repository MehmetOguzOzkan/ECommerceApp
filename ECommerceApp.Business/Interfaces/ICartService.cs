using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface ICartService
    {
        List<GetCartDTO> GetAll();

        GetCartDTO GetByUserId(int userId);

        GetCartDTO GetById(int id);

        ServiceResult<GetCartItemDTO> AddItem(CreateCartItemDTO createCartItemDTO);

        ServiceResult<GetCartItemDTO> UpdateItem(int id, UpdateCartItemDTO updateCartItemDTO);

        ServiceResult<GetCartDTO> Create(CreateCartDTO createCartDTO);

        ServiceResult<GetCartDTO> Update(int id, UpdateCartDTO updateCartDTO);

        void DeleteItem(int id);

        void Delete(int id);

        void InActiveItem(int id);

        void InActive(int id);
    }
}
