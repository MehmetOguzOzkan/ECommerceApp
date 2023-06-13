using AutoMapper;
using AutoMapper.Configuration.Conventions;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public List<GetAddressDTO> GetAll()
        {
            var addresses = _addressRepository.GetAll();
            var getAddressDTOs = new List<GetAddressDTO>();
            addresses.ForEach(b => getAddressDTOs.Add(_mapper.Map<GetAddressDTO>(b)));
            return getAddressDTOs;
        }

        public GetAddressDTO GetById(int id)
        {
            return _mapper.Map<GetAddressDTO>(_addressRepository.GetById(id));
        }

        public List<GetAddressDTO> GetByUserId(int userId)
        {
            var addresses = _addressRepository.GetAllByUserId(userId);
            var getAddressDTOs = new List<GetAddressDTO>();
            addresses.ForEach(b => getAddressDTOs.Add(_mapper.Map<GetAddressDTO>(b)));
            return getAddressDTOs;
        }

        public List<GetAddressDTO> GetAllByPage(int page = 0, int pageSize = 40)
        {
            var addresses = _addressRepository.GetAllByPage(page, pageSize);
            var getAddressDTOs = new List<GetAddressDTO>();
            addresses.ForEach(b => getAddressDTOs.Add(_mapper.Map<GetAddressDTO>(b)));
            return getAddressDTOs;
        }

        public ServiceResult<GetAddressDTO> Create(CreateAddressDTO createAddressDTO)
        {
            var address = _mapper.Map<Address>(createAddressDTO);
            if (address is null) return ServiceResult<GetAddressDTO>.Failed(null, "Not Found", 400);

            _addressRepository.Add(address);
            return ServiceResult<GetAddressDTO>.Success(_mapper.Map<GetAddressDTO>(address));
        }

        public ServiceResult<GetAddressDTO> Update(int id, UpdateAddressDTO updateAddressDTO)
        {
            var address = _addressRepository.GetById(id);
            if (address is null) return ServiceResult<GetAddressDTO>.Failed(null, "Not Found", 404);

            address = _mapper.Map<Address>(updateAddressDTO);
            if (address is null) return ServiceResult<GetAddressDTO>.Failed(null, "Not Found", 400);

            _addressRepository.Update(id, address);
            return ServiceResult<GetAddressDTO>.Success(_mapper.Map<GetAddressDTO>(address));
        }

        public void Delete(int id)
        {
            _addressRepository.Delete(id);
        }

        public void InActive(int id)
        {
            _addressRepository.InActive(id);
        }

        public List<GetAddressDTO> Search(string city, string district, string neighborhood, string street, string number, int? postalCode, int? userId)
        {
            var addresses = _addressRepository.Search(city, district, neighborhood, street, number, postalCode, userId);
            var getAddressDTOs = new List<GetAddressDTO>();
            addresses.ForEach(b => getAddressDTOs.Add(_mapper.Map<GetAddressDTO>(b)));
            return getAddressDTOs;
        }

        public List<GetAddressDTO> OrderByCreatedDate(List<int> ids)
        {
            var getAddressDTOs = new List<GetAddressDTO>();
            var addresses = _addressRepository.OrderByCreatedDate(ids);
            addresses.ForEach(b => getAddressDTOs.Add(_mapper.Map<GetAddressDTO>(b)));
            return getAddressDTOs;
        }

        public List<GetAddressDTO> OrderByCreatedDateDescending(List<int> ids)
        {
            var getAddressDTOs = new List<GetAddressDTO>();
            var addresses = _addressRepository.OrderByCreatedDateDescending(ids);
            addresses.ForEach(b => getAddressDTOs.Add(_mapper.Map<GetAddressDTO>(b)));
            return getAddressDTOs;
        }

        public List<GetAddressDTO> OrderByAddress(List<int> ids)
        {
            var getAddressDTOs = new List<GetAddressDTO>();
            var addresses = _addressRepository.OrderByAddress(ids);
            addresses.ForEach(b => getAddressDTOs.Add(_mapper.Map<GetAddressDTO>(b)));
            return getAddressDTOs;
        }

        public List<GetAddressDTO> OrderByAddressDescending(List<int> ids)
        {
            var getAddressDTOs = new List<GetAddressDTO>();
            var addresses = _addressRepository.OrderByAddressDescending(ids);
            addresses.ForEach(b => getAddressDTOs.Add(_mapper.Map<GetAddressDTO>(b)));
            return getAddressDTOs;
        }
    }
}
