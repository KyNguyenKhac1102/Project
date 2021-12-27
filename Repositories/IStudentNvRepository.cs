using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;


public interface IStudentNvRepository
{
    // GetAll Insert, Update, Delete
    Task<IEnumerable<StudentNguyenVong>> GetAll();
    Task<StudentNguyenVong> GetNguyenVongById(int id);
    Task<List<StudentNguyenVong>> Insert(StudentNguyenVongDtos[] dto, int id);

    Task<StudentNguyenVong> Update(int id, StudentNguyenVongDtos dto);
    Task<bool> Delete(int id);
    Task<bool> DeleteByInfoId(int studentInfoId);

}
