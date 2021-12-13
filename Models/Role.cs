
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class Role
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
         [MaxLength(100)]
        public string TenRole {get; set;}
         [MaxLength(100)]
        public string MoTa {get; set;}
    }
}