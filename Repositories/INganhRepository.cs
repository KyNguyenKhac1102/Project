
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;


public interface INganhRepository
{
    // GetAll Insert, Update, Delete
    Task<IEnumerable<Nganh>> GetAll();
    Task<Nganh> GetNganhById(string maNganh);
    Task<Nganh> Insert(NganhDtos dto);

    Task<Nganh> Update(string maNganh, NganhDtos dto);
    Task<bool> Delete(string maNganh);


}
