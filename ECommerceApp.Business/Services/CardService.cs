using AutoMapper;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using ECommerceApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public List<GetCardDTO> GetAll()
        {
            var cards = _cardRepository.GetAll();
            var getCardDTOs = new List<GetCardDTO>();
            cards.ForEach(b => getCardDTOs.Add(_mapper.Map<GetCardDTO>(b)));
            return getCardDTOs;
        }

        public GetCardDTO GetById(int id)
        {
            return _mapper.Map<GetCardDTO>(_cardRepository.GetById(id));
        }

        public List<GetCardDTO> GetAllByPage(int page = 0, int pageSize = 40)
        {
            var cards = _cardRepository.GetAllByPage(page, pageSize);
            var getCardDTOs = new List<GetCardDTO>();
            cards.ForEach(b => getCardDTOs.Add(_mapper.Map<GetCardDTO>(b)));
            return getCardDTOs;
        }

        public ServiceResult<GetCardDTO> Create(CreateCardDTO createCardDTO)
        {
            var card = _mapper.Map<Card>(createCardDTO);
            if (card is null) return ServiceResult<GetCardDTO>.Failed(null, "Not Found", 400);

            _cardRepository.Add(card);
            return ServiceResult<GetCardDTO>.Success(_mapper.Map<GetCardDTO>(card));
        }

        public ServiceResult<GetCardDTO> Update(int id, UpdateCardDTO updateCardDTO)
        {
            var card = _cardRepository.GetById(id);
            if (card is null) return ServiceResult<GetCardDTO>.Failed(null, "Not Found", 404);

            card = _mapper.Map<Card>(updateCardDTO);
            if (card is null) return ServiceResult<GetCardDTO>.Failed(null, "Not Found", 400);

            _cardRepository.Update(id, card);
            return ServiceResult<GetCardDTO>.Success(_mapper.Map<GetCardDTO>(card));
        }

        public void Delete(int id)
        {
            _cardRepository.Delete(id);
        }

        public void InActive(int id)
        {
            _cardRepository.InActive(id);
        }

        public List<GetCardDTO> Search(string number, int? userId)
        {
            var cards = _cardRepository.Search(number, userId);
            var getCardDTOs = new List<GetCardDTO>();
            cards.ForEach(b => getCardDTOs.Add(_mapper.Map<GetCardDTO>(b)));
            return getCardDTOs;
        }

        public List<GetCardDTO> OrderByCreatedDate(List<int> ids)
        {
            var getCardDTOs = new List<GetCardDTO>();
            var cards = _cardRepository.OrderByCreatedDate(ids);
            cards.ForEach(b => getCardDTOs.Add(_mapper.Map<GetCardDTO>(b)));
            return getCardDTOs;
        }

        public List<GetCardDTO> OrderByCreatedDateDescending(List<int> ids)
        {
            var getCardDTOs = new List<GetCardDTO>();
            var cards = _cardRepository.OrderByCreatedDateDescending(ids);
            cards.ForEach(b => getCardDTOs.Add(_mapper.Map<GetCardDTO>(b)));
            return getCardDTOs;
        }
    }
}
