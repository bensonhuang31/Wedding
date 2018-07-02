using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingCheck.Models
{
    public class WeddingCountViewModel
    {
        [Display(Name = "總人數")]
        public int Total { get; set; }

        [Display(Name = "實到")]
        public int Actual { get; set; }

        [Display(Name = "未到")]
        public int Absentee { get; set; }

    }
}
