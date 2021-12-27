
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class ToHop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MaToHop { get; set; }
        [MaxLength(100)]
        public string TenToHop { get; set; }

    }
}