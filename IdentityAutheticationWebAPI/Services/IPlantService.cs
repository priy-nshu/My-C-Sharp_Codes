using IdentityAutheticationWebAPI.Models;

namespace IdentityAutheticationWebAPI.Services
{
    public interface IPlantService
    {
        Task<List<Plant>> GetAllPlantsAsync();
        Task<Plant> CreatePlantAsync(Plant plant);
        Task<Plant?> UpdatePlantAsync(int id, Plant plant);
        Task<bool> DeletePlantAsync(int id);
    }
}