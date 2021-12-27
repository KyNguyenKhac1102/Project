using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;

namespace Project.Repositories
{
    public class TruongRepository : ITruongRepository
    {

        private readonly ProjectContext _context;

        public TruongRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Truong>> GetAll()
        {
            return await _context.Truongs.Take(100).ToListAsync();
        }

        public async Task<Truong> GetTruongById(int id)
        {
            return await _context.Truongs.FirstOrDefaultAsync(truong => truong.Id == id);
        }

        public async Task<Truong> Insert(TruongDtos dto)
        {
            var truong = new Truong()
            {
                MaTruong = dto.MaTruong,
                TenTruong = dto.TenTruong,
                DiaChi = dto.DiaChi
            };

            await _context.Truongs.AddAsync(truong);
            _context.SaveChanges();

            return truong;
        }

        public async Task<Truong> Update(int id, TruongDtos dto)
        {
            var truong = await _context.Truongs.FirstOrDefaultAsync(t => t.Id == id);

            try
            {
                truong.MaTruong = dto.MaTruong;
                truong.TenTruong = dto.TenTruong;
                truong.DiaChi = dto.DiaChi;

                await _context.SaveChangesAsync();
                return truong;
            }
            catch (System.Exception)
            {
                throw;
            }



        }
        public async Task<bool> Delete(int id)
        {
            var truong = await _context.Truongs.FirstOrDefaultAsync(t => t.Id == id);
            _context.Truongs.Remove(truong);

            if (await _context.SaveChangesAsync() > 0)
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