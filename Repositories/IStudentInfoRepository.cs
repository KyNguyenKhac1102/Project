
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;


public interface IStudentInfoRepository
{
    // GetAll Insert, Update, Delete
    Task<IEnumerable<StudentInfo>> GetAll();
    Task<StudentInfo> Insert(StudentInfoDtos dto);

    Task<StudentInfo> Update(int id, StudentInfoDtos dto);
    Task<bool> Delete(int id);


}
