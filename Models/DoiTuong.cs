using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class DoiTuong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MaDoiTuong { get; set; }

        [MaxLength(100)]
        public string TenDoiTuong { get; set; }


        public StudentInfo StudentInfo { get; set; }


    }
}