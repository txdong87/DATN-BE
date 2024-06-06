using Domain.Entities;
using Domain.IRepository;
using Infracstructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Ktv> GetKTVByIdAsync(int KTVid)
        {
            return await _context.Ktvs
                                 .Include(d => d.UserldNavigation)
                                 .FirstOrDefaultAsync(d => d.KtvId == KTVid);
        }
    }
}
