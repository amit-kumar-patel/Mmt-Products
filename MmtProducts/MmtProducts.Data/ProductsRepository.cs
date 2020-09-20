using Microsoft.EntityFrameworkCore;
using MmtProducts.Data.Interfaces;
using MmtProducts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MmtProducts.Data
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext context;

        private const int FeatureSkuThreshold = 40000;

        public ProductsRepository(ProductsContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        public Task<List<Product>> GetFeaturedProducts()
        {
            return context.Products.Where(x => x.Sku < FeatureSkuThreshold).Include(x => x.Category).ToListAsync();
        }

        public Task<List<Product>> GetProducts(string category)
        {
            var products = context.Products.AsQueryable();
            if (category != null)
            {
                products = products.Where(x => x.Category.Name.Equals(category, StringComparison.InvariantCultureIgnoreCase));
            }

            return products.Include(x => x.Category).ToListAsync();
        }

        public Task<List<Category>> GetCategories()
        {
            return context.Categories.ToListAsync();
        }
    }
}
