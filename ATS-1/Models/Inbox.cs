using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Models
{
    public class Inbox
    {
        [Key]
        public int Id { set; get; }
        public string ApplicantMobile { set; get; }
        public string ApplicantName { set; get; }
        public string ApplicantEmail { set; get; }
        public string ApplicantStatus { set; get; } // by default is "Inbox"
        public string ApplicantJoinDate { set; get; }
        public string ApplicantUniversity { set; get; }
        public string ApplicantOtherUniversity { set; get; }
        public string ApplicantMajor { set; get; }
        public string ApplicantGPA1 { set; get; }
        public string ApplicantGPA2 { set; get; }
        public string ApplicantDevExperience { set; get; }
        public string ApplicantTeamLeaderExperience { set; get; }
        public string ApplicantTechnologies { set; get; }
        public string ApplicantCurrentPosition { set; get; }
        public string ApplicantHowdidyoufindus { set; get; }
        public string ApplicantDegree { set; get; }
        public string ApplicantExpectedSalary { set; get; }

        public string englishSkills { set; get; }
        public string nationality { set; get; }
        public string cvAttachment { set; get; }
        public string ApplicationTitle { set; get; }
    }
}
