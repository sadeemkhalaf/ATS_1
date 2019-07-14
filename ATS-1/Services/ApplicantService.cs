using System;
using System.Collections.Generic;
using System.Linq;
using ATS_1.Data;
using ATS_1.Models;
using Microsoft.EntityFrameworkCore;
namespace ATS_1.Services
{
    public class ApplicantService : IApplicantService
    {
        private ApplicationDBContext dbContext;

        public ApplicantService(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void DeleteApplicant(int id)
        {
            using (dbContext)
            {
                var applicant = dbContext.Applicants.Find(id);
                if (applicant != null)
                {
                    dbContext.Entry<Applicant>(applicant).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        public Applicant GetApplicant(int ID)
        {
            using (dbContext)
            {
                return dbContext.Applicants.Find(ID);
            }
        }

        public List<Applicant> GetApplicants()
        {
            using (dbContext)
            {
                return dbContext.Applicants.ToList();
            }
        }

        public void InsertApplicant(Applicant applicant)
        {
            using (dbContext)
            {
                applicant.ApplicationDate = new DateTime().ToUniversalTime();
                dbContext.Applicants.Add(applicant);
                dbContext.SaveChanges();
            }
        }

        public void UpdateApplicant(Applicant applicant, int id)
        {
            Applicant applicantFound;

            using (dbContext)
            {
                applicantFound = dbContext.Applicants.Where(appl => appl.Id == id).FirstOrDefault<Applicant>();

                if (applicantFound != null)
                {
                    if (!applicantFound.Status.Equals(applicant.Status))
                    {
                        ActivityLog ActivityLog = new ActivityLog();
                        ApplicantStatusHistory applicantStatusHistory = new ApplicantStatusHistory();
                        ActivityLog.Activity = "Status changed to " + applicant.Status;
                        ActivityLog.UserName = "admin";
                        ActivityLog.ActivityDatetime = DateTime.Now;
                        ActivityLog.ApplicantID = applicantFound.Id;
                        dbContext.Entry<ActivityLog>(ActivityLog).State = EntityState.Added;
                        applicantStatusHistory.ApplicantId = id;
                        applicantStatusHistory.Status = applicant.Status;
                        applicantStatusHistory.UpdateDate = new DateTime();
                        dbContext.Entry<ApplicantStatusHistory>(applicantStatusHistory).State = EntityState.Added;
                    }
                    applicantFound.Name = applicant.Name;
                    applicantFound.Status = applicant.Status;
                    applicantFound.PhoneNumber = applicant.PhoneNumber;
                    applicantFound.Email = applicant.Email;
                    applicantFound.Degree = applicant.Degree;
                    applicantFound.University = applicant.University;
                    applicantFound.OtherUniversity = applicant.OtherUniversity;
                    applicantFound.GPA1 = applicant.GPA1;
                    applicantFound.GPA2 = applicant.GPA2;
                    applicantFound.Currentposition = applicant.Currentposition;
                    applicantFound.Technologies = applicant.Technologies;
                    applicantFound.Devexperience = applicant.Devexperience;
                    applicantFound.TeamLeaderExperience = applicant.TeamLeaderExperience;
                    applicantFound.JoinDate = applicant.JoinDate;
                    applicantFound.ExpectedSalary = applicant.ExpectedSalary;
                    applicantFound.Howdidyoufindus = applicant.Howdidyoufindus;
                    applicantFound.Notes = applicant.Notes.Length > 0 ? applicant.Notes : "";
                    applicantFound.EnglishSkills = applicant.EnglishSkills;
                    applicantFound.Nationality = applicant.Nationality;
                    if (applicant.ToCallDate != null)
                    {
                        applicantFound.ToCallDate = applicant.ToCallDate;
                    }
                    if (applicant.InterviewDate != null)
                    {
                        applicantFound.InterviewDate = applicant.InterviewDate;
                    }
                    applicantFound.CareerLevel = applicant.CareerLevel;
                    applicantFound.LastUdateLog = applicant.LastUdateLog;
                    applicantFound.ExamScore = applicant.ExamScore != 0 ? applicant.ExamScore : 0;
                    applicantFound.Title = applicant.Title;
                    dbContext.Entry<Applicant>(applicantFound).State = EntityState.Modified;
                    applicantFound.ApplicationDate = applicant.ApplicationDate;
                }
                dbContext.SaveChanges();
            }
        }
    }
}
