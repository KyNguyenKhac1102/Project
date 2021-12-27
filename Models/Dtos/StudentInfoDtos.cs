
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;



namespace Project.Models
{
    public class StudentInfoDtos
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoCCCD { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChiHoKhau { get; set; }

        public string MaDoiTuong { get; set; }
        public string MaKhuVuc { get; set; }
        public string Tinh10Id { get; set; }

        public string Tinh11Id { get; set; }

        public string Tinh12Id { get; set; }
        public int TruongLop10Id { get; set; }

        public int TruongLop11Id { get; set; }

        public int TruongLop12Id { get; set; }

        public string DiaChiLienHe { get; set; }
        public string HoTenBo { get; set; }
        public string SdtBo { get; set; }
        public string HoTenMe { get; set; }
        public string SdtMe { get; set; }
        public string Hocba10_url { get; set; }

        public string Hocba11_url { get; set; }

        public string Hocba12_url { get; set; }

        public double DiemToan10 { get; set; }
        public double DiemLy10 { get; set; }
        public double DiemHoa10 { get; set; }

        public double DiemToan11 { get; set; }
        public double DiemLy11 { get; set; }
        public double DiemHoa11 { get; set; }

        public double DiemToan12 { get; set; }
        public double DiemLy12 { get; set; }
        public double DiemHoa12 { get; set; }

        public StudentNguyenVongDtos[] NguyenVongs { get; set; }

        public int UserId { get; set; }


    }
}