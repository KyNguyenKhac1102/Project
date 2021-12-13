
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class Tinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MaTinh { get; set; }
        [MaxLength(100)]
        public string TenTinh { get; set; }

        public StudentInfo Tinh10Info { get; set; }
        public StudentInfo Tinh11Info { get; set; }
        public StudentInfo Tinh12Info { get; set; }
    }
}