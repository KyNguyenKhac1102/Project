
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class KhuVuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MaKhuVuc { get; set; }
        [MaxLength(100)]
        public string TenKhuVuc { get; set; }


        public StudentInfo StudentInfo { get; set; }
    }
}