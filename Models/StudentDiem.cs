
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class StudentDiem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double DiemToan10 { get; set; }
        public double DiemLy10 { get; set; }
        public double DiemHoa10 { get; set; }

        public double DiemToan11 { get; set; }
        public double DiemLy11 { get; set; }
        public double DiemHoa11 { get; set; }

        public double DiemToan12 { get; set; }
        public double DiemLy12 { get; set; }
        public double DiemHoa12 { get; set; }

        // public double DiemTb10
        // {
        //     get
        //     {
        //         return Math.Round((DiemToan10 + DiemLy10 + DiemHoa10) / 3.0);
        //     }
        // }

        // public double DiemTb11
        // {
        //     get
        //     {
        //         return Math.Round((DiemToan11 + DiemLy11 + DiemHoa11) / 3.0);
        //     }
        //     set;
        // }
        // public double DiemTb12
        // {
        //     get
        //     {
        //         return Math.Round((DiemToan12 + DiemLy12 + DiemHoa12) / 3.0);
        //     }

        // }

        // public double DiemTb
        // {
        //     get
        //     {
        //         return Math.Round((DiemTb10 + DiemTb11 + DiemTb12) / 3.0);
        //     }

        // }

        // public double DiemTb_UuTien { get; set; }

        public StudentInfo StudentInfo { get; set; }
    }
}