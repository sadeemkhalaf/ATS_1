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
        private Random random = new Random();

        public ApplicantService(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void DeleteApplicant(int id)
        {
            using (dbContext)
            {
                var applicant = dbContext.Applicants.Find(id);
                if (applicant != null) {
                    dbContext.Entry<Applicant>(applicant).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        public Applicant GetApplicant(int ID)
        {
            using (dbContext) {
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

            if (applicantFound != null) {
                    if (!applicantFound.status.Equals(applicant.status)) {
                        Metadata metadata = new Metadata();
                        metadata.Id = Convert.ToInt32(new DateTime());
                        metadata.Activity = "status changed to " + applicant.status;
                        metadata.userName = "admin";
                        metadata.ActivityDatetime = DateTime.Now;
                        metadata.ApplicantID = applicantFound.Id;
                        dbContext.Entry<Metadata>(metadata).State = EntityState.Added;
                    }
                    applicantFound.Name = applicant.Name;
                    applicantFound.status = applicant.status;
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
                    applicantFound.NoteLog = applicant.NoteLog;
                    applicantFound.EnglishSkills = applicant.EnglishSkills;
                    applicantFound.Nationality = applicant.Nationality;
                    applicantFound.ToCallDate = applicant.ToCallDate;
                    applicantFound.InterviewDate = applicant.InterviewDate;
                    applicantFound.CareerLevel = applicant.CareerLevel;
                    applicantFound.LastUdateLog = applicant.LastUdateLog;
                    dbContext.Entry<Applicant>(applicantFound).State = EntityState.Modified;
                }
                dbContext.SaveChanges();
            }
        }
    }
}
