using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Models
{
    public class ApplicantEducationDetails
    {
        [Key]
        public int Id { set; get; }
        public string University { set; get; }
        public string Major { set; get; }
        public string Degree { set; get; }
        public Nullable<double> GPA { set; get; }
        public string StartYear { set; get; }
        public string GraduationYear { set; get; }
        public bool Graduated { set; get; }
        [ForeignKey("Applicant")]
        public int ApplicantId { set; get; }
        public Applicant Applicant { set; get; }
    }
}
