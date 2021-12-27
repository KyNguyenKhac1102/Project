
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project.Models
{
    public class StudentNguyenVong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Stt_NguyenVong { get; set; }

        [ForeignKey("MaNganh")]
        [JsonIgnore]
        public Nganh Nganh { get; set; }
        public string MaNganh { get; set; }
        [ForeignKey("MaToHop")]
        public ToHop ToHop { get; set; }
        public string MaToHop { get; set; }

        [ForeignKey("StudentInfoId")]
        public int StudentInfoId { get; set; }
        [JsonIgnore]
        public StudentInfo StudentInfo { get; set; }
    }
}