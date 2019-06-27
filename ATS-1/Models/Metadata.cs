using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Models
{
    public class Metadata
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int ApplicantID { get; set; }
        public string userName { set; get; }
        public string Activity { set; get; }
        public DateTime ActivityDatetime { set; get; }
    }
}
