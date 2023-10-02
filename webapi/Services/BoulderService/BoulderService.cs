using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using webapi.Data;

namespace webapi.Services.BoulderService
{
    public class BoulderService : IBoulderService
    {

        private readonly AppDbContext _context;

        public BoulderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Boulder?> AddBoulder(Boulder boulder)
        {
           _context.Boulders.Add(boulder);
            await _context.SaveChangesAsync();
            return boulder;
        }

        public async Task<List<Boulder>?> DeleteBoulder(int id)
        {
           var boulderById = await _context.Boulders.FindAsync(id);
            if (boulderById == null)
            {
                return null;
            }
            _context.Boulders.Remove(boulderById);
            await _context.SaveChangesAsync();
            return await _context.Boulders.ToListAsync();

        }

        public async Task<Boulder?> GetBoulderById(int id)
        {
            var boulderById = await _context.Boulders.FindAsync(id);
            if (boulderById == null)
            {
                return null;
            }
            return boulderById;
        }

        public async Task<List<Boulder>> GetBoulders()
        {
            var boulders = await _context.Boulders.ToListAsync();
            return boulders;
        }

        public async Task<Boulder?> UpdateBoulder(Boulder request)
        {
            var boulderById = await _context.Boulders.FindAsync(request.Id);
            if (boulderById == null)
            {
                return null;
            }
            boulderById.Name = request.Name;
            boulderById.Description = request.Description;
            boulderById.Rating = request.Rating;
            
            await _context.SaveChangesAsync();

            return boulderById;
            
        }
    }
}
