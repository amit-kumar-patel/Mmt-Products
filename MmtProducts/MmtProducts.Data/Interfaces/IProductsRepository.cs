using MmtProducts.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MmtProducts.Data.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetFeaturedProducts();

        Task<List<Product>> GetProducts(string category);

        Task<List<Category>> GetCategories();
    }
}
