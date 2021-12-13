
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;


public interface IUserRepository
{
    // GetAll Insert, Update, Delete
    Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken);
    Task<User> GetUserByPhone(string phone);
    Task<User> Insert(RegisterDtos dto);

    Task<bool> Update(int id, RegisterDtos dto);
    Task<bool> Delete(int id);


}
