using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface ICardService
    {
        List<GetCardDTO> GetAll();

        GetCardDTO GetById(int id);

        List<GetCardDTO> GetAllByPage(int page = 0, int pageSize = 40);

        ServiceResult<GetCardDTO> Create(CreateCardDTO createCardDTO);

        ServiceResult<GetCardDTO> Update(int id, UpdateCardDTO updateCardDTO);

        void Delete(int id);

        void InActive(int id);

        List<GetCardDTO> Search(string number, int? userId);

        List<GetCardDTO> OrderByCreatedDate(List<int> ids);

        List<GetCardDTO> OrderByCreatedDateDescending(List<int> ids);
    }
}
