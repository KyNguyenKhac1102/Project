
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;

namespace Project.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken)
        {
            return await _userRepo.GetAll(cancellationToken);

        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepo.GetUserById(id);
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            return await _userRepo.GetUserByPhone(phone);
        }


        public async Task<User> Create(RegisterDtos dto)
        {

            var user = await _userRepo.Insert(dto);

            return user;

        }


        public async Task<bool> Update(int id, UserUpdateDtos dto)
        {
            if (await _userRepo.Update(id, dto))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (await _userRepo.Delete(id))
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