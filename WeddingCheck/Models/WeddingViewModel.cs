using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingCheck.Models
{
    public class WeddingViewModel
    {
        public int SN { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "電話")]
        public string Phone { get; set; }

        [Display(Name = "人數")]
        public int Accompanied { get; set; }

        [Display(Name = "桌號")]
        public string Seat { get; set; }

        public int Checkin { get; set; }

        [Display(Name = "備註")]
        public string Note { get; set; }

        [Display(Name = "關係")]
        public string Relationship { get; set; }

    }
}
