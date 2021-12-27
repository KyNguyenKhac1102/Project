using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;

namespace Project.Services
{
    public class NganhService : INganhService
    {
        private readonly INganhRepository _nganhRepo;

        public NganhService(INganhRepository nganhRepo)
        {
            _nganhRepo = nganhRepo;
        }

        public async Task<IEnumerable<Nganh>> GetNganhs()
        {
            return await _nganhRepo.GetAll();

        }

        public async Task<Nganh> GetNganhById(string maNganh)
        {
            return await _nganhRepo.GetNganhById(maNganh);

        }

        public async Task<Nganh> Create(NganhDtos dto)
        {
            return await _nganhRepo.Insert(dto);

        }

        public async Task<Nganh> Update(string maNganh, NganhDtos dto)
        {
            return await _nganhRepo.Update(maNganh, dto);

        }
        public async Task<bool> Delete(string maNganh)
        {
            if (await _nganhRepo.Delete(maNganh))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}