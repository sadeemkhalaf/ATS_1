using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Models
{
    public class Index
    {
        [Key]
        public int ApplicantID { set; get; }
        [Required]
        public string ApplicantMobile { set; get; }
        [Required]
        public string ApplicantName { set; get; }
        [Required]
        public string ApplicantEmail { set; get; }
        public string ApplicantStatus { set; get; } // by default is "Inbox"
        public string ApplicantJoinDate { set; get; }
        [Required]
        public string ApplicantUniversity { set; get; }
        public string ApplicantOtherUniversity { set; get; }
        [Required]
        public string ApplicantMajor { set; get; }
        public string ApplicantGPA1 { set; get; }
        public string ApplicantGPA2 { set; get; }
        public string ApplicantDevExperience { set; get; }
        public string ApplicantTeamLeaderExperience { set; get; }
        public string ApplicantTechnologies { set; get; }
        public string ApplicantCurrentPosition { set; get; }
        public string ApplicantHowdidyoufindus { set; get; }
        [Required]
        public string ApplicantDegree { set; get; }
        public string ApplicantExpectedSalary { set; get; }

        public string englishSkills { set; get; }
        public string nationality { set; get; }
        [Required]
        public string cvAttachment { set; get; }
    }
}
