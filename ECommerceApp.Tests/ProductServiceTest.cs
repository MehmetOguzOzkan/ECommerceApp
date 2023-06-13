using AutoMapper;
using ECommerceApp.Business;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Services;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceApp.Tests
{
    public class ProductServiceTest
    {
        private ProductService _productService;
        private Mock<IProductRepository> _productRepsoitory;
        private Mock<IMapper> _mapper;

        public ProductServiceTest()
        {
            _productRepsoitory = new Mock<IProductRepository>();
            _mapper = new Mock<IMapper>();
            _productService = new ProductService(_productRepsoitory.Object, _mapper.Object );
        }

        [Fact]
        public void Update_Success()
        {
            //arrange
            var id = 21;
            var product = new UpdateProductDTO { Name = "Product", Price = 12.34, Image = "Image", CategoryId = 1 };
            _mapper.Setup(b => b.Map<Product>(It.IsAny<UpdateProductDTO>())).Returns(new Product());
            _productRepsoitory.Setup(b=>b.GetById(It.IsAny<int>())).Returns(new Product());
            _productRepsoitory.Setup(b => b.Update(It.IsAny<int>(), It.IsAny<Product>()));

            //act
            var response = _productService.Update(id, product);

            //assert
            Assert.NotNull(response);
            Assert.IsType<ServiceResult<GetProductDTO>>(response);
            Assert.True(response.Succeed);
            Assert.NotNull(response.Result);
            Assert.Empty(response.ErrorMessage);
        }

        [Fact]
        public void Update_WhenProductIsNotFound_ReturnFailed()
        {
            //arrange
            var id = 21;
            var product = new UpdateProductDTO { Name = "Product", Price = 12.34, Image = "Image", CategoryId = 1 };
            _mapper.Setup(b => b.Map<Product>(It.IsAny<UpdateProductDTO>())).Returns(new Product());
            _productRepsoitory.Setup(b => b.GetById(It.IsAny<int>())).Returns((Product)null);
            //act
            var response = _productService.Update(id, product);

            //assert
            Assert.NotNull(response);
            Assert.IsType<ServiceResult<GetProductDTO>>(response);
            Assert.True(response.Succeed);
            Assert.NotNull(response.Result);
            Assert.Empty(response.ErrorMessage);
        }

        [Fact]
        public void Create_Success()
        {
            //arrange
            var id = 21;
            var product = new CreateProductDTO { Name = "Product", Price = 12.34, Image = "Image", CategoryId = 1 };
            _mapper.Setup(b => b.Map<Product>(It.IsAny<CreateProductDTO>())).Returns(new Product());
            _productRepsoitory.Setup(b => b.GetById(It.IsAny<int>())).Returns(new Product());
            _productRepsoitory.Setup(b => b.Add(It.IsAny<Product>()));

            //act
            var response = _productService.Create(product);

            //assert
            Assert.NotNull(response);
            Assert.IsType<ServiceResult<GetProductDTO>>(response);
            Assert.True(response.Succeed);
            Assert.NotNull(response.Result);
            Assert.Empty(response.ErrorMessage);
        }

        [Fact]
        public void Delete_WhenProductNotFound_ThrowException()
        {
            //arrange
            var id = 21;
            _productRepsoitory.Setup(b=>b.Delete(It.IsAny<int>())).Throws(new Exception());

            //assert
            Assert.Throws<Exception>(() => _productService.Delete(id));
        }

        [Fact]
        public void InActive_WhenProductNotFound_ThrowException()
        {
            //arrange
            var id = 21;
            _productRepsoitory.Setup(b => b.InActive(It.IsAny<int>())).Throws(new Exception());

            //assert
            Assert.Throws<Exception>(() => _productService.InActive(id));
        }

        [Fact]
        public void GetById_WhenProductNotFound_ThrowException()
        {
            //arrange
            var id = 21;
            _productRepsoitory.Setup(b => b.GetById(It.IsAny<int>())).Throws(new Exception());

            //assert
            Assert.Throws<Exception>(() => _productService.GetById(id));
        }


    }
}
