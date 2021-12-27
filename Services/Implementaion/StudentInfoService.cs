using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Services
{
    public class StudentInfoService : IStudentInfoService
    {
        private readonly IStudentInfoRepository _studentInfoRepo;
        private readonly IStudentNvRepository _nvRepo;

        public StudentInfoService(IStudentInfoRepository studentInfoRepo, IStudentNvRepository nvRepo)
        {
            _studentInfoRepo = studentInfoRepo;
            _nvRepo = nvRepo;
        }
        public async Task<IEnumerable<StudentInfo>> GetStudentInfos()
        {
            return await _studentInfoRepo.GetAll();
        }
        public async Task<StudentInfo> GetInfoById(int id)
        {
            //nguyenvong include
            return await _studentInfoRepo.GetInfoById(id);
        }
        public async Task<StudentInfo> Create(StudentInfoDtos dto)
        {
            var studentInfo = await _studentInfoRepo.Insert(dto);
            var studentInfoId = studentInfo.Id;

            // var storeNguyenVongs = new List<StudentNguyenVong>();
            await _nvRepo.Insert(dto.NguyenVongs, studentInfoId);
            // studentInfo.StudentNguyenVongs

            return studentInfo;
        }
        public async Task<StudentInfo> Update(int id, StudentInfoDtos dto)
        {
            var studentInfoRecord = await _studentInfoRepo.Update(id, dto);
            //studentinfoId and sttnguyenvong. notwork cause edit+add.
            //delete all the first add then add back. is edit.
            //delete all the nguyenvong with the studentInfoId then create by the
            //edit data
            var nguyenvongs = dto.NguyenVongs;
            var studentInfoId = studentInfoRecord.Id;
            if (await _nvRepo.DeleteByInfoId(studentInfoId))
            {
                await _nvRepo.Insert(dto.NguyenVongs, studentInfoId);
            }

            return studentInfoRecord;
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