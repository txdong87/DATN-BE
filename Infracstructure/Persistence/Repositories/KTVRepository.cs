using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class KTVRepository : IKTVRepository
    {
        private readonly datnContext _context;

        public KTVRepository(datnContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KTV>> GetAllKTVsAsync()
        {
            return await _context.Ktvs.ToListAsync();
        }

        public async Task<KTV> GetKTVByIdAsync(int KTVId)
        {
            return await _context.Ktvs.FirstOrDefaultAsync(d => d.KtvId == KTVId);
        }

        public async Task CreateKTVAsync(KTV KTV)
        {
            await _context.Ktvs.AddAsync(KTV);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateKTVAsync(KTV KTV)
        {
            _context.Ktvs.Update(KTV);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteKTVAsync(int KTVId)
        {
            var KTV = await _context.Ktvs.FindAsync(KTVId);
            if (KTV != null)
            {
                _context.Ktvs.Remove(KTV);
                await _context.SaveChangesAsync();
            }
        }
    }
}
