using AutoMapper;
using AutoMapper.Configuration.Conventions;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using ECommerceApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<GetProductDTO> GetAll()
        {
            var products = _productRepository.GetAll();
            var getProductDTOs = new List<GetProductDTO>();
            products.ForEach(b => getProductDTOs.Add(_mapper.Map<GetProductDTO>(b)));
            return getProductDTOs;
        }

        public GetProductDTO GetById(int id)
        {
            return _mapper.Map<GetProductDTO>(_productRepository.GetById(id));
        }

        public List<GetProductDTO> GetAllByPage(int page = 0, int pageSize = 40)
        {
            var products = _productRepository.GetAllByPage(page,pageSize);
            var getProductDTOs = new List<GetProductDTO>();
            products.ForEach(b => getProductDTOs.Add(_mapper.Map<GetProductDTO>(b)));
            return getProductDTOs;
        }

        public ServiceResult<GetProductDTO> Create(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);
            if (product is null) return ServiceResult<GetProductDTO>.Failed(null, "Not Found", 400);

            _productRepository.Add(product);
            return ServiceResult<GetProductDTO>.Success(_mapper.Map<GetProductDTO>(product));
        }

        public ServiceResult<GetProductDTO> Update(int id, UpdateProductDTO updateProductDTO)
        {
            var product = _productRepository.GetById(id);
            if (product is null) return ServiceResult<GetProductDTO>.Failed(null, "Not Found", 404);

            product = _mapper.Map<Product>(updateProductDTO);
            if (product is null) return ServiceResult<GetProductDTO>.Failed(null,"Not Found",400); 
            
            _productRepository.Update(id,product);
            return ServiceResult<GetProductDTO>.Success(_mapper.Map<GetProductDTO>(product));
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public void InActive(int id)
        {
            _productRepository.InActive(id);
        }

        public List<GetProductDTO> Search(string name, int? categoryId, double? minPrice, double? maxPrice)
        {
            var products = _productRepository.Search(name, categoryId, minPrice, maxPrice);
            var getProductDTOs = new List<GetProductDTO>();
            products.ForEach(b=>getProductDTOs.Add(_mapper.Map<GetProductDTO>(b)));
            return getProductDTOs;
        }

        public List<GetProductDTO> OrderByCreatedDate(List<int> ids)
        {
            var getProductDTOs = new List<GetProductDTO>();
            var products = _productRepository.OrderByCreatedDate(ids);
            products.ForEach(b => getProductDTOs.Add(_mapper.Map<GetProductDTO>(b)));
            return getProductDTOs;
        }

        public List<GetProductDTO> OrderByCreatedDateDescending(List<int> ids)
        {
            var getProductDTOs = new List<GetProductDTO>();
            var products = _productRepository.OrderByCreatedDateDescending(ids);
            products.ForEach(b => getProductDTOs.Add(_mapper.Map<GetProductDTO>(b)));
            return getProductDTOs;
        }

        public List<GetProductDTO> OrderByName(List<int> ids)
        {
            var getProductDTOs = new List<GetProductDTO>();
            var products = _productRepository.OrderByName(ids);
            products.ForEach(b => getProductDTOs.Add(_mapper.Map<GetProductDTO>(b)));
            return getProductDTOs;
        }

        public List<GetProductDTO> OrderByNameDescending(List<int> ids)
        {
            var getProductDTOs = new List<GetProductDTO>();
            var products = _productRepository.OrderByNameDescending(ids);
            products.ForEach(b => getProductDTOs.Add(_mapper.Map<GetProductDTO>(b)));
            return getProductDTOs;
        }

        public List<GetProductDTO> OrderByPrice(List<int> ids)
        {
            var getProductDTOs = new List<GetProductDTO>();
            var products = _productRepository.OrderByPrice(ids);
            products.ForEach(b => getProductDTOs.Add(_mapper.Map<GetProductDTO>(b)));
            return getProductDTOs;
        }

        public List<GetProductDTO> OrderByPriceDescending(List<int> ids)
        {
            var getProductDTOs = new List<GetProductDTO>();
            var products = _productRepository.OrderByPriceDescending(ids);
            products.ForEach(b => getProductDTOs.Add(_mapper.Map<GetProductDTO>(b)));
            return getProductDTOs;
        }


    }
}
