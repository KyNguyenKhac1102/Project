using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;

namespace Project.Services
{
    public class TruongService : ITruongService
    {
        private readonly ITruongRepository _truongRepo;

        public TruongService(ITruongRepository truongRepo)
        {
            _truongRepo = truongRepo;
        }

        public async Task<IEnumerable<Truong>> GetTruongs()
        {
            return await _truongRepo.GetAll();

        }

        public async Task<Truong> GetTruongById(int id)
        {
            return await _truongRepo.GetTruongById(id);

        }

        public async Task<Truong> Create(TruongDtos dto)
        {
            return await _truongRepo.Insert(dto);

        }

        public async Task<Truong> Update(int id, TruongDtos dto)
        {
            return await _truongRepo.Update(id, dto);

        }
        public async Task<bool> Delete(int id)
        {
            if (await _truongRepo.Delete(id))
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