
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class NganhDtos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MaNganh { get; set; }
        [MaxLength(100)]
        public string TenNganh { get; set; }
        public int KhoaId { get; set; }

    }
}