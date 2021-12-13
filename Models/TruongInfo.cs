
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project.Models
{
    public class TruongInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Truong10")]
        public int TruongLop10Id { get; set; }
        [ForeignKey("Truong11")]
        public int TruongLop11Id { get; set; }
        [ForeignKey("Truong12")]
        public int TruongLop12Id { get; set; }

        public StudentInfo StudentInfo { get; set; }
        [InverseProperty("Truong10Info")]
        public Truong Truong10 { get; set; }
        [InverseProperty("Truong11Info")]
        public Truong Truong11 { get; set; }
        [InverseProperty("Truong12Info")]
        public Truong Truong12 { get; set; }



    }
}