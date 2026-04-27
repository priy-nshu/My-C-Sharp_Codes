using ProductsWebApp.Models;

namespace ProductsWebApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(string id, string subCategory);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(string id, string subCategory);
    }
}
