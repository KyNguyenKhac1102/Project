
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project.Models
{
    public class TruongDtos
    {
        public string MaTruong { get; set; }

        public string TenTruong { get; set; }

        public string DiaChi { get; set; }
    }
}