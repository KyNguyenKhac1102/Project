
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.Models
{
    public class StudentNguyenVongDtos
    {
        public int Stt_NguyenVong { get; set; }
        public int NganhId { get; set; }

        public int ToHopId { get; set; }
    }
}