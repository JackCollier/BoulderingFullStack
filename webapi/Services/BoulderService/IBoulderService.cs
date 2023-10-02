using webapi.Data;

namespace webapi.Services.BoulderService
{
    public interface IBoulderService
    {
        Task<List<Boulder>> GetBoulders();
        Task<Boulder?> GetBoulderById(int id);
        Task<Boulder?> AddBoulder(Boulder boulder);
        Task<Boulder?> UpdateBoulder(Boulder request);
        Task<List<Boulder>?> DeleteBoulder(int id);
    }
}
