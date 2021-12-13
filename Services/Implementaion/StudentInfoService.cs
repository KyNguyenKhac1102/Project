using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Services
{
    public class StudentInfoService : IStudentInfoService
    {
        private readonly IStudentInfoRepository _studentInfoRepo;


        public StudentInfoService(IStudentInfoRepository studentInfoRepo)
        {
            _studentInfoRepo = studentInfoRepo;
        }
        public async Task<IEnumerable<StudentInfo>> GetStudentInfos()
        {
            return await _studentInfoRepo.GetAll();
        }
        public async Task<StudentInfo> Create(StudentInfoDtos dto)
        {
            return await _studentInfoRepo.Insert(dto);
        }
        public async Task<StudentInfo> Update(int id, StudentInfoDtos dto)
        {
            return await _studentInfoRepo.Update(id, dto);
        }
        public async Task<bool> Delete(int id)
        {
            if (await _studentInfoRepo.Delete(id))
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