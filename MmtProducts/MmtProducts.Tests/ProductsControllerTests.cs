using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MmtProducts.Api.Controllers;
using MmtProducts.Api.MappingProfile;
using MmtProducts.Data.Interfaces;
using MmtProducts.Domain;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MmtProducts.Tests
{
    public class ProductsControllerTests
    {
        private Mock<IProductsRepository> productsMock;
        private Mock<ILogger<ProductsController>> loggerMock;
        private IMapper mapper;

        public ProductsControllerTests()
        {
            var profile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            mapper = new Mapper(configuration);

            productsMock = new Mock<IProductsRepository>(MockBehavior.Strict);

            loggerMock = new Mock<ILogger<ProductsController>>();
        }

        [Test]
        public async Task When_CategoriesRequested_Then_OkReturned()
        {
            productsMock.Setup(x => x.GetCategories()).Returns(Task.FromResult(new System.Collections.Generic.List<Category>
            {
                new Category
                { 
                    Id = 1,
                    Name = "Test"
                },                
                new Category
                { 
                    Id = 2,
                    Name = "Test2"
                },
            }));
            var controller = new ProductsController(loggerMock.Object, productsMock.Object, mapper);

            var result = await controller.GetCategories();

            Assert.IsInstanceOf<OkObjectResult>(result);
            productsMock.VerifyAll();
        }

        [Test]
        public async Task When_FeaturedProductsRequested_Then_OkReturned()
        {
            productsMock.Setup(x => x.GetFeaturedProducts()).Returns(Task.FromResult(new System.Collections.Generic.List<Product>
            {
                new Product
                {
                     Id = 1,
                     Name = "Lamp",
                     Description = "It's a lamp",
                     Price = 100.00m,
                     Sku = 12345,
                     CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Hoe",
                    Description = "No, not that...",
                    Price = 100.00m,
                    Sku = 22345,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "TV",
                    Description = "You know what a TV is...",
                    Price = 200.00m,
                    Sku = 32345,
                    CategoryId = 3
                },
            }));

            var controller = new ProductsController(loggerMock.Object, productsMock.Object, mapper);

            var result = await controller.GetFeaturedProducts();

            Assert.IsInstanceOf<OkObjectResult>(result);
            productsMock.VerifyAll();
        }

        [Test]
        public async Task When_ProductsAreRequested_Then_OkReturned()
        {
            productsMock.Setup(x => x.GetProducts(It.IsAny<string>())).Returns(Task.FromResult(new System.Collections.Generic.List<Product>
            {
                new Product
                {
                     Id = 1,
                     Name = "Lamp",
                     Description = "It's a lamp",
                     Price = 100.00m,
                     Sku = 12345,
                     CategoryId = 1
                },
            }));

            var controller = new ProductsController(loggerMock.Object, productsMock.Object, mapper);

            var result = await controller.GetProducts();

            Assert.IsInstanceOf<OkObjectResult>(result);
            productsMock.VerifyAll();
        }
    }
}