
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Dtos;
using Project.Models;

namespace Project.Services
{
    public interface IStudentInfoService
    {
        // Truongs create update delete
        Task<IEnumerable<StudentInfo>> GetStudentInfos();
        Task<StudentInfo> GetInfoById(int id);
        Task<StudentInfo> Create(StudentInfoDtos dto);
        Task<StudentInfo> Update(int id, StudentInfoDtos dto);
        Task<bool> Delete(int id);
    }
}