using AutoMapper;
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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public List<GetRoleDTO> GetAll()
        {
            var roles = _roleRepository.GetAll();
            var getRoleDTOs = new List<GetRoleDTO>();
            roles.ForEach(b => getRoleDTOs.Add(_mapper.Map<GetRoleDTO>(b)));
            return getRoleDTOs;
        }

        public GetRoleDTO GetById(int id)
        {
            return _mapper.Map<GetRoleDTO>(_roleRepository.GetById(id));
        }

        public ServiceResult<GetRoleDTO> Create(CreateRoleDTO createRoleDTO)
        {
            var role = _mapper.Map<Role>(createRoleDTO);
            if (role is null) return ServiceResult<GetRoleDTO>.Failed(null, "Not Found", 400);

            _roleRepository.Add(role);
            return ServiceResult<GetRoleDTO>.Success(_mapper.Map<GetRoleDTO>(role));
        }

        public ServiceResult<GetRoleDTO> Update(int id, UpdateRoleDTO updateRoleDTO)
        {
            var role = _roleRepository.GetById(id);
            if (role is null) return ServiceResult<GetRoleDTO>.Failed(null, "Not Found", 404);

            role = _mapper.Map<Role>(updateRoleDTO);
            if (role is null) return ServiceResult<GetRoleDTO>.Failed(null, "Not Found", 400);

            _roleRepository.Update(id, role);
            return ServiceResult<GetRoleDTO>.Success(_mapper.Map<GetRoleDTO>(role));
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }

        public void InActive(int id)
        {
            _roleRepository.InActive(id);
        }

        public List<GetRoleDTO> Search(string name)
        {
            var roles = _roleRepository.Search(name);
            var getRoleDTOs = new List<GetRoleDTO>();
            roles.ForEach(b => getRoleDTOs.Add(_mapper.Map<GetRoleDTO>(b)));
            return getRoleDTOs;
        }

        public List<GetRoleDTO> OrderByCreatedDate(List<int> ids)
        {
            var getRoleDTOs = new List<GetRoleDTO>();
            var roles = _roleRepository.OrderByCreatedDate(ids);
            roles.ForEach(b => getRoleDTOs.Add(_mapper.Map<GetRoleDTO>(b)));
            return getRoleDTOs;
        }

        public List<GetRoleDTO> OrderByCreatedDateDescending(List<int> ids)
        {
            var getRoleDTOs = new List<GetRoleDTO>();
            var roles = _roleRepository.OrderByCreatedDateDescending(ids);
            roles.ForEach(b => getRoleDTOs.Add(_mapper.Map<GetRoleDTO>(b)));
            return getRoleDTOs;
        }

        public List<GetRoleDTO> OrderByName(List<int> ids)
        {
            var getRoleDTOs = new List<GetRoleDTO>();
            var roles = _roleRepository.OrderByName(ids);
            roles.ForEach(b => getRoleDTOs.Add(_mapper.Map<GetRoleDTO>(b)));
            return getRoleDTOs;
        }

        public List<GetRoleDTO> OrderByNameDescending(List<int> ids)
        {
            var getRoleDTOs = new List<GetRoleDTO>();
            var roles = _roleRepository.OrderByNameDescending(ids);
            roles.ForEach(b => getRoleDTOs.Add(_mapper.Map<GetRoleDTO>(b)));
            return getRoleDTOs;
        }
    }
}
