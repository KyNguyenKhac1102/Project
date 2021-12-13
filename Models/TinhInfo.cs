
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class TinhInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public StudentInfo StudentInfo { get; set; }

        [ForeignKey("Tinh10")]
        public int Tinh10Id { get; set; }
        [ForeignKey("Tinh11")]
        public int Tinh11Id { get; set; }
        [ForeignKey("Tinh12")]
        public int Tinh12Id { get; set; }

        [InverseProperty("Tinh10Info")]
        public Tinh Tinh10 { get; set; }
        [InverseProperty("Tinh11Info")]
        public Tinh Tinh11 { get; set; }
        [InverseProperty("Tinh12Info")]
        public Tinh Tinh12 { get; set; }
    }
}