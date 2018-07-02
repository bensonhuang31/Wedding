using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingCheck.Models
{
    [Table("Wedding")]
    public class Wedding
    {
        [Key]
        public int SN { get; set; }

        public string Name { get; set; }

        public int Accompanied { get; set; }

        public int Seat { get; set; }

        public string Relationship { get; set; }

        public string Note { get; set; }

        public int Checkin { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
