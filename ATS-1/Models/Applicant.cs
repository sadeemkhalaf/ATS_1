using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Models
{
    public class Applicant
    {
        [Key]
        public int Id { set; get; }
        public string PhoneNumber { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string status { set; get; }
        public string JoinDate { set; get; }
        public string University { set; get; }
        public string OtherUniversity { set; get; }
        public string Major { set; get; }
        public string GPA1 { set; get; }
        public string GPA2 { set; get; }
        public string Devexperience { set; get; }
        public string TeamLeaderExperience { set; get; }
        public string Technologies { set; get; }
        public string Currentposition { set; get; }
        public string Howdidyoufindus { set; get; }
        public string NoteLog { set; get; }
        public string Degree { set; get; }
        public string ExpectedSalary { set; get; }

        public string EnglishSkills { set; get; }
        public string CareerLevel { set; get; }
        public string LastUpdateLog { set; get; }
        public string ExamScore { set; get; }
        public DateTime ToCallDate { set; get; }
        public DateTime InterviewDate { set; get; }
        public string Nationality { set; get; }
        public string CVAttachment { set; get; }

    }
}
