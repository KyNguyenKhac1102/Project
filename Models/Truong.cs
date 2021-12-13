
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project.Models
{
    public class Truong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string MaTruong { get; set; }
        [MaxLength(200)]
        public string TenTruong { get; set; }
        [MaxLength(1000)]
#nullable enable
        public string? DiaChi { get; set; }
#nullable disable
        [JsonIgnore]
        public StudentInfo Truong10Info { get; set; }
        [JsonIgnore]
        public StudentInfo Truong11Info { get; set; }
        [JsonIgnore]
        public StudentInfo Truong12Info { get; set; }
    }
}