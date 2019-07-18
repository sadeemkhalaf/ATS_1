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
        public string Status { set; get; }
        public string JoinDate { set; get; }
        public string University { set; get; }
        public string OtherUniversity { set; get; }
        public string Major { set; get; }
        public Nullable<double> GPA1 { set; get; }
        public Nullable<double> GPA2 { set; get; }
        public Nullable<int> Devexperience { set; get; }
        public Nullable<int> TeamLeaderExperience { set; get; }
        public string Technologies { set; get; }
        public string Currentposition { set; get; }
        public string Howdidyoufindus { set; get; }
        public string Notes { set; get; }
        public string Degree { set; get; }
        public string ExpectedSalary { set; get; }

        public string EnglishSkills { set; get; }
        public string CareerLevel { set; get; }
        public string LastUdateLog { set; get; }
        public Nullable<double> ExamScore { set; get; }
        public string ToCallDate { set; get; }
        public string InterviewDate { set; get; }
        public string Nationality { set; get; }
        public string CVAttachment { set; get; }
        public string Title { set; get; } // get from a dictionary (frontend issue)
        public string ApplicationDate { set; get; }
        public string Comments { set; get; }

        public ICollection<ApplicantStatusHistory> ApplicantStatusHistory { set; get; }
        public ICollection<ApplicantFiles> ApplicantFiles { set; get; }
        public ICollection<ActivityLog> ActivityLog { set; get; }
        public ICollection<ApplicantEducationDetails> ApplicantEducationDetails { set; get; }
    }
}
