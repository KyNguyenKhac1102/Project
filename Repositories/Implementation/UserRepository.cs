
using Project.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Project.Dtos;
using Project.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace Project.Repositories
{
    public class UserRepository : IUserRepository
    {

        // inject dbcontext
        private readonly ProjectContext _context;

        public UserRepository(ProjectContext context)
        {
            _context = context;
        }
        TimeZoneInfo vnZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        public async Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Users.ToListAsync(cancellationToken);
            }
            catch (TaskCanceledException)
            { }

            return Enumerable.Empty<User>();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phone);
        }


        public async Task<User> Insert(RegisterDtos dto)
        {
            var user = new User()
            {
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Create_At = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnZone),
                Update_At = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnZone),
            };

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();


                return user;
            }
            catch (Exception)
            {
                return null;

            }
        }
        public async Task<bool> Update(int id, UserUpdateDtos dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);


            try
            {
                user.Name = dto.Name;
                user.PhoneNumber = dto.PhoneNumber;
                user.Update_At = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vnZone);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public async Task<bool> Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            _context.Users.Remove(user);

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