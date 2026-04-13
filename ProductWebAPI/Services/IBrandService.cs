using ProductWebAPI.Models;

namespace ProductWebAPI.Services
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllBrands();
        Task<Brand> GetBrandById(int id);  
        Task<int> AddBrand(Brand brand);
        Task<Brand> GetBrandByName(string name);
    }
}
