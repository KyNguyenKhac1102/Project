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
    public class NganhRepository : INganhRepository
    {

        private readonly ProjectContext _context;

        public NganhRepository(ProjectContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Nganh>> GetAll()
        {
            return await _context.Nganhs.ToListAsync();
        }

        public async Task<Nganh> GetNganhById(string maNganh)
        {
            return await _context.Nganhs.FirstOrDefaultAsync(n => n.MaNganh == maNganh);
        }

        public async Task<Nganh> Insert(NganhDtos dto)
        {
            var nganh = new Nganh()
            {
                MaNganh = dto.MaNganh,
                TenNganh = dto.TenNganh,
                KhoaId = dto.KhoaId
            };

            await _context.Nganhs.AddAsync(nganh);
            _context.SaveChanges();

            return nganh;
        }

        public async Task<Nganh> Update(string maNganh, NganhDtos dto)
        {
            var nganh = await _context.Nganhs.FirstOrDefaultAsync(t => t.MaNganh == maNganh);

            try
            {
                nganh.MaNganh = dto.MaNganh;
                nganh.TenNganh = dto.TenNganh;
                nganh.KhoaId = dto.KhoaId;

                await _context.SaveChangesAsync();
                return nganh;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(string maNganh)
        {
            var nganh = await _context.Nganhs.FirstOrDefaultAsync(t => t.MaNganh == maNganh);
            _context.Nganhs.Remove(nganh);

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