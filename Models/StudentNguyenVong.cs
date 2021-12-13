
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Models
{
    public class StudentNguyenVong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Stt_NguyenVong { get; set; }

        public Nganh Nganh { get; set; }
        public int NganhId { get; set; }
        public ToHop ToHop { get; set; }
        public int ToHopId { get; set; }


        public StudentInfo StudentInfo { get; set; }
    }
}