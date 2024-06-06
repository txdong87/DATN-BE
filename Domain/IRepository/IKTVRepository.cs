using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IKTVRepository
    {
        Task<KTV> GetKTVByIdAsync(int KTVId);
        Task<IEnumerable<KTV>> GetAllKTVsAsync();
        Task CreateKTVAsync(KTV KTV);
        Task UpdateKTVAsync(KTV KTV);
        Task DeleteKTVAsync(int id);
    }
}
