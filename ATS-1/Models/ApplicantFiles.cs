using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Models
{
    public class ApplicantFiles
    {
        [Key]
        public int Id { set; get; }
        public string FileName { set; get; }
        public string URL { set; get; }
        public Nullable<DateTime> CreatedAt { set; get; }
        [ForeignKey("Applicant")]
        public int ApplicantId { set; get; }
        public Applicant Applicant { set; get; }
    }
}
