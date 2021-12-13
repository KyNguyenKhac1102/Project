
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class StudentDiemTb
    {
        [Key]
        [ForeignKey("StudentInfo")]
        public int StudentInfoId { get; set; }
        public double DiemTb10 { get; set; }
        public double DiemTb11 { get; set; }
        public double DiemTb12 { get; set; }


        public double DiemTb_UuTien { get; set; }
        public StudentInfo StudentInfo { get; set; }
    }
}