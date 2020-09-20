using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MmtProducts.Api.ViewModels;
using MmtProducts.Data.Interfaces;
using MmtProducts.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MmtProducts.Api.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public ProductsController(
            ILogger<ProductsController> logger, 
            IProductsRepository productsRepository,
            IMapper mapper)
        {
            this.logger = logger;
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("products")]
        public async Task<ActionResult> GetProducts(string category = null)
        {
            try
            {
                var products = await productsRepository.GetProducts(category);
                var mappedProducts = mapper.Map<IEnumerable<ProductViewModel>>(products);

                return Ok(mappedProducts);
            }
            catch(Exception ex)
            {
                logger.LogError("Error retrieving products", ex);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("products/featured")]
        public async Task<ActionResult> GetFeaturedProducts()
        {
            try
            {
                var products = await productsRepository.GetFeaturedProducts();
                var mappedProducts = mapper.Map<IEnumerable<ProductViewModel>>(products);

                return Ok(mappedProducts);
            }
            catch (Exception ex)
            {
                logger.LogError("Error retrieving featured products", ex);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("categories")]
        public async Task<ActionResult> GetCategories()
        {
            try
            {
                var categories = await productsRepository.GetCategories();
                var mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

                return Ok(mappedCategories);
            }
            catch (Exception ex)
            {
                logger.LogError("Error retrieving categories", ex);
                return StatusCode(500);
            }
        }
    }
}
