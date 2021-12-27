
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;

namespace Project.Services
{
    public interface ITruongService
    {
        // Truongs create update delete
        Task<IEnumerable<Truong>> GetTruongs();
        Task<Truong> GetTruongById(int id);
        Task<Truong> Create(TruongDtos dto);
        Task<Truong> Update(int id, TruongDtos dto);
        Task<bool> Delete(int id);
    }
}