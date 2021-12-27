
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(12)]
        [MinLength(9)]
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public string Password { get; set; }

        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }


        //navigation property
        [JsonIgnore]
        public StudentInfo StudentInfo { get; set; }

        public int? RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }

    }
}