using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;

namespace Project.Repositories
{
    public class StudentInfoRepository : IStudentInfoRepository
    {

        private readonly ProjectContext _context;

        public StudentInfoRepository(ProjectContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StudentInfo>> GetAll()
        {
            return await _context.StudentInfos.ToListAsync();
        }

        public async Task<StudentInfo> Insert(StudentInfoDtos dto)
        {
            var diemtb10 = Math.Round((dto.DiemToan10 + dto.DiemLy10 + dto.DiemHoa10) / 3, 2);
            var diemtb11 = Math.Round((dto.DiemToan11 + dto.DiemLy10 + dto.DiemHoa11) / 3, 2);
            var diemtb12 = Math.Round((dto.DiemToan12 + dto.DiemLy10 + dto.DiemHoa12) / 3, 2);

            var diemCongDoiTuong = 0;
            double diemCongKhuVuc = 0;
            if (dto.DoiTuongId == "01" || dto.DoiTuongId == "02" || dto.DoiTuongId == "03" || dto.DoiTuongId == "04")
            {
                diemCongDoiTuong = 2;
            }
            else if (dto.DoiTuongId == "05" || dto.DoiTuongId == "06" || dto.DoiTuongId == "07")
            {
                diemCongDoiTuong = 1;
            }

            if (dto.KhuVucId == "1")
            {
                diemCongKhuVuc = 0.75;
            }
            else if (dto.KhuVucId == "2")
            {
                diemCongKhuVuc = 0.25;
            }
            else if (dto.KhuVucId == "2NT")
            {
                diemCongKhuVuc = 0.5;
            }

            var diem_final = Math.Round((diemtb10 + diemtb11 + diemtb12) / 3, 2) + diemCongKhuVuc + diemCongDoiTuong;
            var studentInfo = new StudentInfo()
            {
                HoTen = dto.HoTen,
                NgaySinh = dto.NgaySinh,
                GioiTinh = dto.GioiTinh,
                SoCCCD = dto.SoCCCD,
                SoDienThoai = dto.SoDienThoai,
                Email = dto.Email,
                DiaChiHoKhau = dto.DiaChiHoKhau,
                DoiTuongId = dto.DoiTuongId,
                KhuVucId = dto.KhuVucId,
                Tinh10Id = dto.Tinh10Id,
                Tinh11Id = dto.Tinh11Id,
                Tinh12Id = dto.Tinh12Id,
                TruongLop10Id = dto.TruongLop10Id,
                TruongLop11Id = dto.TruongLop11Id,
                TruongLop12Id = dto.TruongLop12Id,
                DiaChiLienHe = dto.DiaChiLienHe,
                HoTenBo = dto.HoTenBo,
                SdtBo = dto.SdtBo,
                HoTenMe = dto.HoTenMe,
                SdtMe = dto.SdtMe,
                Hocba10_url = dto.Hocba10_url,
                Hocba11_url = dto.Hocba11_url,
                Hocba12_url = dto.Hocba12_url,
                DiemToan10 = dto.DiemToan10,
                DiemLy10 = dto.DiemLy10,
                DiemHoa10 = dto.DiemHoa10,

                DiemToan11 = dto.DiemToan11,
                DiemLy11 = dto.DiemLy11,
                DiemHoa11 = dto.DiemHoa11,

                DiemToan12 = dto.DiemToan12,
                DiemLy12 = dto.DiemLy12,
                DiemHoa12 = dto.DiemHoa12,

                DiemTb10 = diemtb10,

                DiemTb11 = diemtb11,
                DiemTb12 = diemtb12,

                DiemTb_UuTien = diem_final,
                UserId = dto.UserId,
            };

            await _context.StudentInfos.AddAsync(studentInfo);
            _context.SaveChanges();

            return studentInfo;
        }

        public async Task<StudentInfo> Update(int id, StudentInfoDtos dto)
        {
            var studentInfo = await _context.StudentInfos.FirstOrDefaultAsync(t => t.Id == id);

            try
            {
                studentInfo.HoTen = dto.HoTen;
                studentInfo.NgaySinh = dto.NgaySinh;
                studentInfo.GioiTinh = dto.GioiTinh;
                studentInfo.SoCCCD = dto.SoCCCD;
                studentInfo.SoDienThoai = dto.SoDienThoai;
                studentInfo.Email = dto.Email;
                studentInfo.DiaChiHoKhau = dto.DiaChiHoKhau;
                studentInfo.DoiTuongId = dto.DoiTuongId;
                studentInfo.KhuVucId = dto.KhuVucId;
                studentInfo.Tinh10Id = dto.Tinh10Id;
                studentInfo.Tinh11Id = dto.Tinh11Id;
                studentInfo.Tinh12Id = dto.Tinh12Id;
                studentInfo.TruongLop10Id = dto.TruongLop10Id;
                studentInfo.TruongLop11Id = dto.TruongLop11Id;
                studentInfo.TruongLop12Id = dto.TruongLop12Id;
                studentInfo.DiaChiLienHe = dto.DiaChiLienHe;
                studentInfo.HoTenBo = dto.HoTenBo;
                studentInfo.SdtBo = dto.SdtBo;
                studentInfo.HoTenMe = dto.HoTenMe;
                studentInfo.SdtMe = dto.SdtMe;
                studentInfo.Hocba10_url = dto.Hocba10_url;
                studentInfo.Hocba11_url = dto.Hocba11_url;
                studentInfo.Hocba12_url = dto.Hocba12_url;
                studentInfo.DiemToan10 = dto.DiemToan10;
                studentInfo.DiemLy10 = dto.DiemLy10;
                studentInfo.DiemHoa10 = dto.DiemHoa10;

                studentInfo.DiemToan11 = dto.DiemToan11;
                studentInfo.DiemLy11 = dto.DiemLy11;
                studentInfo.DiemHoa11 = dto.DiemHoa11;

                studentInfo.DiemToan12 = dto.DiemToan12;
                studentInfo.DiemLy12 = dto.DiemLy12;
                studentInfo.DiemHoa12 = dto.DiemHoa12;

                studentInfo.UserId = dto.UserId;
                return studentInfo;
            }
            catch (System.Exception)
            {
                throw;
            }

        }
        public async Task<bool> Delete(int id)
        {
            var studentInfo = await _context.StudentInfos.FirstOrDefaultAsync(t => t.Id == id);
            _context.StudentInfos.Remove(studentInfo);

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