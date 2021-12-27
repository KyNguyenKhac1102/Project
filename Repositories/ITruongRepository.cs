
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;


public interface ITruongRepository
{
    // GetAll Insert, Update, Delete
    Task<IEnumerable<Truong>> GetAll();
    Task<Truong> GetTruongById(int id);
    Task<Truong> Insert(TruongDtos dto);

    Task<Truong> Update(int id, TruongDtos dto);
    Task<bool> Delete(int id);


}
