using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IKTVService
    {
        Task<IEnumerable<KTV>> GetAllKTVsAsync();
        Task<KTV> GetKTVByIdAsync(int KTVId);
        Task AddKTVAsync(KTV KTV);
        Task UpdateKTVAsync(KTV KTV);
        Task DeleteKTVAsync(int KTVId);
    }
}
