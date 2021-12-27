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
    public class StudentNvRepository : IStudentNvRepository
    {

        private readonly ProjectContext _context;

        public StudentNvRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentNguyenVong>> GetAll()
        {
            return await _context.StudentNguyenVongs.ToListAsync();
        }

        public async Task<StudentNguyenVong> GetNguyenVongById(int id)
        {
            return await _context.StudentNguyenVongs.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<StudentNguyenVong>> Insert(StudentNguyenVongDtos[] dto, int id)
        {
            int length = dto.Length;
            var storeNguyenVong = new List<StudentNguyenVong>();


            for (int i = 0; i < length; i++)
            {
                var studentNguyenVong = new StudentNguyenVong()
                {
                    Stt_NguyenVong = i + 1,
                    StudentInfoId = id,
                    MaNganh = dto[i].MaNganh,
                    MaToHop = dto[i].MaToHop
                };
                storeNguyenVong.Add(studentNguyenVong);
                await _context.StudentNguyenVongs.AddAsync(studentNguyenVong);
            }

            _context.SaveChanges();

            return storeNguyenVong;
        }


        public async Task<bool> Delete(int id)
        {
            var studentNguyenVong = await _context.StudentNguyenVongs.FirstOrDefaultAsync(t => t.Id == id);
            _context.StudentNguyenVongs.Remove(studentNguyenVong);

            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteByInfoId(int studentInfoId)
        {

            _context.StudentNguyenVongs.RemoveRange(_context.StudentNguyenVongs.Where(t => t.StudentInfoId == studentInfoId));

            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<StudentNguyenVong> Update(int id, StudentNguyenVongDtos dto)
        {
            throw new NotImplementedException();
        }
    }
}