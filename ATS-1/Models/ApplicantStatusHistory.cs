using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Models
{
    public class ApplicantStatusHistory
    {
        public int Id { set; get; }
        public int ApplicantId { set; get; }
        public string Status { set; get; }
        public DateTime UpdateDate { set; get; }
    }
}
