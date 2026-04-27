using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DockerWebAPI.Models;

namespace DockerWebAPI.Services
{
    public class BrandService:IBrandService
    {
        private readonly BykeStoresContext _dbContext;
        public BrandService(BykeStoresContext Context) {
            _dbContext =Context;
        }
        public async Task<List<Brand>> GetAllBrands()
        {
            return await _dbContext.Brands.ToListAsync();
        }

        public async Task<Brand> GetBrandById(int id)
        {
            return await _dbContext.Brands.FirstOrDefaultAsync(b => b.BrandId == id);
        }

        public async Task<int> AddBrand(Brand brd)
        {
            await _dbContext.Brands.AddAsync(brd);
            int result = await _dbContext.SaveChangesAsync();
            return result;
        }
        public async Task<Brand> GetBrandByName(string name)
        {
            return await _dbContext.Brands.FirstOrDefaultAsync(b => b.BrandName == name);
        }
    }
}
