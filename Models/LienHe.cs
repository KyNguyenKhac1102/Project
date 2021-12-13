

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class LienHe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string HoTenBo { get; set; }
        [MaxLength(100)]
        public string SdtBo { get; set; }

        [MaxLength(100)]
        public string HoTenMe { get; set; }
        [MaxLength(100)]
        public string SdtMe { get; set; }

        public StudentInfo StudentInfo { get; set; }

    }
}