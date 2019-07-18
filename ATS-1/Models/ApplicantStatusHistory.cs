using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Models
{
    public class ApplicantStatusHistory
    {
        public int Id { set; get; }
        public string Status { set; get; }
        public Nullable<DateTime> UpdateDate { set; get; }
        [ForeignKey("Applicant")]
        public int ApplicantId { set; get; }
        public Applicant Applicant { set; get; }
    }
}
