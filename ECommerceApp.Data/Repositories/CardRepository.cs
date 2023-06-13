using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly Context _context;

        public CardRepository(Context context)
        {
            _context = context;
        }

        public List<Card> GetAll()
        {
            return _context.Cards.Where(b => b.IsActive == true).OrderBy(b => b.Number).ToList();
        }

        public List<Card> GetAllByPage(int page = 0, int pageSize = 40)
        {
            return _context.Cards.Where(b => b.IsActive == true).OrderBy(b => b.Number).Skip(page * pageSize).Take(pageSize).ToList();
        }

        public List<Card> GetAllByUserId(int userId)
        {
            return _context.Cards.Where(b => b.UserId == userId).Where(b => b.IsActive == true).ToList();
        }

        public Card GetById(int id)
        {
            return _context.Cards.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
        }

        public void Add(Card card)
        {
            _context.Add(card);
            _context.SaveChanges();
        }

        public void Update(int id, Card card)
        {
            var c = _context.Cards.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (c is not null)
            {
                c.Number = card.Number;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var card = _context.Cards.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (card is not null)
            {
                _context.Remove(card);
                _context.SaveChanges();
            }
        }

        public void InActive(int id)
        {
            var card = _context.Cards.Where(b => b.IsActive == true).FirstOrDefault(b => b.Id == id);
            if (card is not null)
            {
                card.IsActive = false;
                _context.SaveChanges();
            }
        }

        public List<Card> Search(string number, int? userId)
        {
            var query = _context.Cards.Where(b => b.IsActive == true).AsQueryable();

            if (!string.IsNullOrWhiteSpace(number))
                query.Where(x => x.Number.Contains(number));

            if (userId.HasValue)
                query.Where(x => x.UserId == userId);

            return query.ToList();
        }

        public List<Card> OrderByCreatedDate(List<int> ids)
        {
            var cards = _context.Cards.Where(b => ids.Contains(b.Id));
            return cards.Where(b => b.IsActive == true).OrderBy(b => b.CreatedDate).ToList();
        }

        public List<Card> OrderByCreatedDateDescending(List<int> ids)
        {
            var cards = _context.Cards.Where(b => ids.Contains(b.Id));
            return cards.Where(b => b.IsActive == true).OrderByDescending(b => b.CreatedDate).ToList();
        }
    }
}
