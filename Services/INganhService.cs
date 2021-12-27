
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;

namespace Project.Services
{
    public interface INganhService
    {
        // Nganhs create update delete
        Task<IEnumerable<Nganh>> GetNganhs();
        Task<Nganh> GetNganhById(string maNganh);
        Task<Nganh> Create(NganhDtos dto);
        Task<Nganh> Update(string maNganh, NganhDtos dto);
        Task<bool> Delete(string maNganh);
    }
}