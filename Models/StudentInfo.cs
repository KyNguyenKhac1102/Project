
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;



namespace Project.Models
{
    public class StudentInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string HoTen { get; set; }

        [MaxLength(30)]
        [MinLength(4)]
        public DateTime NgaySinh { get; set; }
        [MaxLength(10)]
        public string GioiTinh { get; set; }
        [MaxLength(50)]
        public string SoCCCD { get; set; }
        [MaxLength(50)]
        public string SoDienThoai { get; set; }
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string DiaChiHoKhau { get; set; }


        [ForeignKey("DoiTuong")]
        public string MaDoiTuong { get; set; }
        [JsonIgnore]
        public DoiTuong DoiTuong { get; set; }


        [ForeignKey("KhuVuc")]
        public string MaKhuVuc { get; set; }
        [JsonIgnore]
        public KhuVuc KhuVuc { get; set; }


        [ForeignKey("Tinh10")]
        public string Tinh10Id { get; set; }
        [ForeignKey("Tinh11")]
        public string Tinh11Id { get; set; }
        [ForeignKey("Tinh12")]
        public string Tinh12Id { get; set; }


        [InverseProperty("Tinh10Info")]
        [JsonIgnore]
        public Tinh Tinh10 { get; set; }

        [InverseProperty("Tinh11Info")]
        [JsonIgnore]
        public Tinh Tinh11 { get; set; }
        [InverseProperty("Tinh12Info")]
        [JsonIgnore]
        public Tinh Tinh12 { get; set; }


        [ForeignKey("Truong10")]
        public int TruongLop10Id { get; set; }
        [ForeignKey("Truong11")]
        public int TruongLop11Id { get; set; }
        [ForeignKey("Truong12")]
        public int TruongLop12Id { get; set; }


        [InverseProperty("Truong10Info")]
        [JsonIgnore]
        public Truong Truong10 { get; set; }

        [InverseProperty("Truong11Info")]
        [JsonIgnore]
        public Truong Truong11 { get; set; }
        [InverseProperty("Truong12Info")]
        [JsonIgnore]
        public Truong Truong12 { get; set; }

        [MaxLength(100)]
        public string DiaChiLienHe { get; set; }

        [MaxLength(100)]
        public string HoTenBo { get; set; }
        [MaxLength(100)]
        public string SdtBo { get; set; }

        [MaxLength(100)]
        public string HoTenMe { get; set; }
        [MaxLength(100)]
        public string SdtMe { get; set; }

        [MaxLength(200)]
        public string Hocba10_url { get; set; }
        [MaxLength(200)]
        public string Hocba11_url { get; set; }
        [MaxLength(200)]
        public string Hocba12_url { get; set; }


        public ICollection<StudentNguyenVong> StudentNguyenVongs { get; set; }


        public double DiemToan10 { get; set; }
        public double DiemLy10 { get; set; }
        public double DiemHoa10 { get; set; }

        public double DiemToan11 { get; set; }
        public double DiemLy11 { get; set; }
        public double DiemHoa11 { get; set; }

        public double DiemToan12 { get; set; }
        public double DiemLy12 { get; set; }
        public double DiemHoa12 { get; set; }


        public double DiemTb10 { get; set; }

        public double DiemTb11 { get; set; }

        public double DiemTb12 { get; set; }

        public double DiemTb_UuTien { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        //navigation property
        // public int HocBaUrlId { get; set; }
        // public HocBaUrl HocBaUrl { get; set; }
        // public int LienHeId { get; set; }
        // public LienHe LienHe { get; set; }
        // public int StudentDiemId { get; set; }
        // public StudentDiem StudentDiem { get; set; }
        // public int TinhInfoId { get; set; }
        // public TinhInfo TinhInfo { get; set; }

        // public string MaDoiTuongId { get; set; }
        // [ForeignKey("MaDoiTuongId")]
        // public DoiTuong DoiTuong { get; set; }

        // public int TruongInfoId { get; set; }
        // public TruongInfo TruongInfo { get; set; }


        //nguyenvong

        // public string MaKhuVucId { get; set; }
        // [ForeignKey("MaKhuVucId")]
        // public KhuVuc KhuVuc { get; set; }
    }
}