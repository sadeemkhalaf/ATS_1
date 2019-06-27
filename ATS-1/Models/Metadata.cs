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
        public int ApplicantID { set; get; }
        [ForeignKey("Id")]
        public Applicant Applicant { get; set; }
        public string ApplicantMobile { set; get; }
    }
}
