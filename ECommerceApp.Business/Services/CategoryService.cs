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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public List<GetCategoryDTO> GetAll()
        {
            var categories = _categoryRepository.GetAll();
            var getCategoryDTOs = new List<GetCategoryDTO>();
            categories.ForEach(b => getCategoryDTOs.Add(_mapper.Map<GetCategoryDTO>(b)));
            return getCategoryDTOs;
        }

        public GetCategoryDTO GetById(int id)
        {
            return _mapper.Map<GetCategoryDTO>(_categoryRepository.GetById(id));
        }

        public ServiceResult<GetCategoryDTO> Create(CreateCategoryDTO createCategoryDTO)
        {
            var category = _mapper.Map<Category>(createCategoryDTO);
            if (category is null) return ServiceResult<GetCategoryDTO>.Failed(null, "Not Found", 400);

            _categoryRepository.Add(category);
            return ServiceResult<GetCategoryDTO>.Success(_mapper.Map<GetCategoryDTO>(category));
        }

        public ServiceResult<GetCategoryDTO> Update(int id, UpdateCategoryDTO updateCategoryDTO)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null) return ServiceResult<GetCategoryDTO>.Failed(null, "Not Found", 404);

            category = _mapper.Map<Category>(updateCategoryDTO);
            if (category is null) return ServiceResult<GetCategoryDTO>.Failed(null, "Not Found", 400);

            _categoryRepository.Update(id, category);
            return ServiceResult<GetCategoryDTO>.Success(_mapper.Map<GetCategoryDTO>(category));
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        public void InActive(int id)
        {
            _categoryRepository.InActive(id);
        }

        public List<GetCategoryDTO> Search(string name)
        {
            var categories = _categoryRepository.Search(name);
            var getCategoryDTOs = new List<GetCategoryDTO>();
            categories.ForEach(b => getCategoryDTOs.Add(_mapper.Map<GetCategoryDTO>(b)));
            return getCategoryDTOs;
        }

        public List<GetCategoryDTO> OrderByCreatedDate(List<int> ids)
        {
            var getCategoryDTOs = new List<GetCategoryDTO>();
            var categories = _categoryRepository.OrderByCreatedDate(ids);
            categories.ForEach(b => getCategoryDTOs.Add(_mapper.Map<GetCategoryDTO>(b)));
            return getCategoryDTOs;
        }

        public List<GetCategoryDTO> OrderByCreatedDateDescending(List<int> ids)
        {
            var getCategoryDTOs = new List<GetCategoryDTO>();
            var categories = _categoryRepository.OrderByCreatedDateDescending(ids);
            categories.ForEach(b => getCategoryDTOs.Add(_mapper.Map<GetCategoryDTO>(b)));
            return getCategoryDTOs;
        }

        public List<GetCategoryDTO> OrderByName(List<int> ids)
        {
            var getCategoryDTOs = new List<GetCategoryDTO>();
            var categories = _categoryRepository.OrderByName(ids);
            categories.ForEach(b => getCategoryDTOs.Add(_mapper.Map<GetCategoryDTO>(b)));
            return getCategoryDTOs;
        }

        public List<GetCategoryDTO> OrderByNameDescending(List<int> ids)
        {
            var getCategoryDTOs = new List<GetCategoryDTO>();
            var categories = _categoryRepository.OrderByNameDescending(ids);
            categories.ForEach(b => getCategoryDTOs.Add(_mapper.Map<GetCategoryDTO>(b)));
            return getCategoryDTOs;
        }
    }
}
