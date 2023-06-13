using ECommerceApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Interfaces
{
    public interface ICardRepository
    {
        List<Card> GetAll();

        List<Card> GetAllByPage(int page = 0, int pageSize = 40);

        List<Card> GetAllByUserId(int userId);

        Card GetById(int id);

        void Add(Card card);

        void Update(int id, Card card);

        void Delete(int id);

        void InActive(int id);

        List<Card> Search(string number, int? userId);

        List<Card> OrderByCreatedDate(List<int> ids);

        List<Card> OrderByCreatedDateDescending(List<int> ids);
    }
}
