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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<GetUserDTO> GetAll()
        {
            var users = _userRepository.GetAll();
            var getUserDTOs = new List<GetUserDTO>();
            users.ForEach(b => getUserDTOs.Add(_mapper.Map<GetUserDTO>(b)));
            return getUserDTOs;
        }

        public GetUserDTO GetById(int id)
        {
            return _mapper.Map<GetUserDTO>(_userRepository.GetById(id));
        }

        public GetAuthUserDTO GetByEmailAndPassword(string email, string password)
        {
            return _mapper.Map<GetAuthUserDTO>(_userRepository.GetByEmailAndPassword(email, password));
        }

        public List<GetUserDTO> GetAllByPage(int page = 0, int pageSize = 20)
        {
            var users = _userRepository.GetAllByPage(page,pageSize);
            var getUserDTOs = new List<GetUserDTO>();
            users.ForEach(b => getUserDTOs.Add(_mapper.Map<GetUserDTO>(b)));
            return getUserDTOs;
        }

        public ServiceResult<GetUserDTO> Create(CreateUserDTO createUserDTO)
        {
            var user = _mapper.Map<User>(createUserDTO);
            if (user is null) return ServiceResult<GetUserDTO>.Failed(null, "Not Found", 400);

            _userRepository.Add(user);
            return ServiceResult<GetUserDTO>.Success(_mapper.Map<GetUserDTO>(user));
        }

        public ServiceResult<GetUserDTO> Update(int id, UpdateUserDTO updateUserDTO)
        {
            var user = _userRepository.GetById(id);
            if (user is null) return ServiceResult<GetUserDTO>.Failed(null, "Not Found", 404);

            user = _mapper.Map<User>(updateUserDTO);
            if (user is null) return ServiceResult<GetUserDTO>.Failed(null, "Not Found", 400);

            _userRepository.Update(id, user);
            return ServiceResult<GetUserDTO>.Success(_mapper.Map<GetUserDTO>(user));
        }

        public ServiceResult<GetAuthUserDTO> AuthUpdate(int id, UpdateUserDTO updateUserDTO)
        {
            var user = _userRepository.GetById(id);
            if (user is null) if (user is null) return ServiceResult<GetAuthUserDTO>.Failed(null, "Not Found", 404);

            user = _mapper.Map<User>(updateUserDTO);
            if (user is null) return ServiceResult<GetAuthUserDTO>.Failed(null, "Not Found", 400);

            _userRepository.AuthUpdate(id, user);
            return ServiceResult<GetAuthUserDTO>.Success(_mapper.Map<GetAuthUserDTO>(user));
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public void InActive(int id)
        {
            _userRepository.InActive(id);
        }

        public List<GetUserDTO> Search(string name, int? roleId, string email)
        {
            var users = _userRepository.Search(name, roleId, email);
            var getUserDTOs = new List<GetUserDTO>();
            users.ForEach(b => getUserDTOs.Add(_mapper.Map<GetUserDTO>(b)));
            return getUserDTOs;
        }

        public List<GetUserDTO> OrderByCreatedDate(List<int> ids)
        {
            var getUserDTOs = new List<GetUserDTO>();
            var users = _userRepository.OrderByCreatedDate(ids);
            users.ForEach(b => getUserDTOs.Add(_mapper.Map<GetUserDTO>(b)));
            return getUserDTOs;
        }

        public List<GetUserDTO> OrderByCreatedDateDescending(List<int> ids)
        {
            var getUserDTOs = new List<GetUserDTO>();
            var users = _userRepository.OrderByCreatedDateDescending(ids);
            users.ForEach(b => getUserDTOs.Add(_mapper.Map<GetUserDTO>(b)));
            return getUserDTOs;
        }

        public List<GetUserDTO> OrderByName(List<int> ids)
        {
            var getUserDTOs = new List<GetUserDTO>();
            var users = _userRepository.OrderByName(ids);
            users.ForEach(b => getUserDTOs.Add(_mapper.Map<GetUserDTO>(b)));
            return getUserDTOs;
        }

        public List<GetUserDTO> OrderByNameDescending(List<int> ids)
        {
            var getUserDTOs = new List<GetUserDTO>();
            var users = _userRepository.OrderByNameDescending(ids);
            users.ForEach(b => getUserDTOs.Add(_mapper.Map<GetUserDTO>(b)));
            return getUserDTOs;
        }
    }
}
