
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class HocBaUrl
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Hocba10_url { get; set; }
        [MaxLength(200)]
        public string Hocba11_url { get; set; }
        [MaxLength(200)]
        public string Hocba12_url { get; set; }

        //navigation property
        public StudentInfo StudentInfo { get; set; }
    }
}