using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ATS_1.Data;
using ATS_1.Models;
using Microsoft.EntityFrameworkCore;
namespace ATS_1.Services
{
    public class ApplicantService : IApplicantService, IDisposable
    {
        private ApplicationDBContext dbContext;


        public ApplicantService(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void DeleteApplicant(int id)
        {

            var applicant = GetApplicant(id);
            if (applicant != null)
            {
                var listToDelete = dbContext.ApplicantStatusHistory.Where(q => q.ApplicantId == applicant.Id).ToList();
                dbContext.ApplicantStatusHistory.RemoveRange(listToDelete);
                dbContext.Entry<Applicant>(applicant).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        public Applicant GetApplicant(int ID)
        {
                return dbContext.Applicants.Find(ID);
        }

        public List<Applicant> GetApplicantByStatus(string status)
        {
   
           return dbContext.Applicants.Where(appl => status.Contains("AllApplicants") ||  appl.Status.Contains(status)).ToList();           
        }

        public List<Applicant> GetApplicants()
        {
                return dbContext.Applicants.ToList();
        }

        public int GetStatusCountQueryResult(string status)
        {
                if (!status.Contains("AllApplicants"))
                {
                    return dbContext.Applicants.Count(appl => appl.Status.Contains(status));
                }
                else
                {
                    return dbContext.Applicants.ToList().Count;
                }
        }

        public void InsertApplicant(Applicant applicant)
        {
           applicant.ApplicationDate = DateTime.Now.ToString();
           applicant.Status = "Inbox";
           dbContext.Applicants.Add(applicant);
           ApplicantStatusHistory applicantStatusHistory = CreateApplicantStatusRecord(applicant);
           dbContext.Entry<ApplicantStatusHistory>(applicantStatusHistory).State = EntityState.Added;
           dbContext.SaveChanges();
        }

        private ApplicantStatusHistory CreateApplicantStatusRecord(Applicant applicantAdded)
        {
            ApplicantStatusHistory applicantStatusHistory = new ApplicantStatusHistory();
            applicantStatusHistory.ApplicantId = applicantAdded.Id;
            applicantStatusHistory.Status = applicantAdded.Status;
            applicantStatusHistory.UpdateDate = DateTime.Now;
            return applicantStatusHistory;
        }

        public Applicant FindSimilarApplicant(string email, string phoneNumber)
        {
            return dbContext.Applicants.Where(appl => (appl.Email.Equals(email) ||
                                                appl.PhoneNumber.Equals(phoneNumber)
                                            )).FirstOrDefault();
        }

        public void UpdateApplicant(Applicant applicant, int id)
        {
            Applicant applicantFound = dbContext.Applicants.Where(appl => appl.Id == id).FirstOrDefault<Applicant>();
            if (applicantFound != null)
            {
                    if (!applicantFound.Status.Equals(applicant.Status))
                    {
                        ActivityLog ActivityLog = new ActivityLog();
                        ApplicantStatusHistory applicantStatusHistory = new ApplicantStatusHistory();
                        ActivityLog.Activity = "Status changed to " + applicant.Status;
                        ActivityLog.UserName = "admin";
                        ActivityLog.ActivityDatetime = DateTime.Now;
                        ActivityLog.ApplicantId = applicantFound.Id;
                        dbContext.Entry<ActivityLog>(ActivityLog).State = EntityState.Added;
                        applicantStatusHistory.ApplicantId = id;
                        applicantStatusHistory.Status = applicant.Status;
                        applicantStatusHistory.UpdateDate = DateTime.Now;
                        dbContext.Entry<ApplicantStatusHistory>(applicantStatusHistory).State = EntityState.Added;
                }
                Applicant UpdateApplicant = this.AssignToApplicantObject(applicant, applicantFound);
                dbContext.Entry<Applicant>(UpdateApplicant).State = EntityState.Modified;
            }
            dbContext.SaveChanges();
            
        }
        private Applicant AssignToApplicantObject(Applicant applicant, Applicant applicantFound)
        {
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
            applicantFound.Notes = applicant.Notes != null ? applicant.Notes : "";
            applicantFound.EnglishSkills = applicant.EnglishSkills;
            applicantFound.Nationality = applicant.Nationality;
            applicantFound.Rating = applicant.Rating;
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
            applicantFound.ApplicationDate = applicant.ApplicationDate;
            return applicantFound;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public List<Applicant> GetApplicantsQueryResult(ApplicantQueryStructure queryObject)
        {
                return this.dbContext.Applicants.Where(app => 
                                                        (float.Parse( queryObject.ExperienceLevel.Last(), CultureInfo.InvariantCulture.NumberFormat) < float.Parse(app.Devexperience, CultureInfo.InvariantCulture.NumberFormat)
                                                            || queryObject.ExperienceLevel.First() == null )
                                                        && (float.Parse(queryObject.ExperienceLevel.First(), CultureInfo.InvariantCulture.NumberFormat) > float.Parse(app.Devexperience, CultureInfo.InvariantCulture.NumberFormat)
                                                            || queryObject.ExperienceLevel.Last() == null )
                                                        && (queryObject.CurrentPoisition.Contains(app.Currentposition) || queryObject.CurrentPoisition.Count == 0)
                                                        && (queryObject.Status.Contains(app.Status) || queryObject.Status.Count == 0)
                                                        && (queryObject.Rating.Contains(app.Rating) || queryObject.Rating.Count == 0)
                                                        && (queryObject.Major.Contains(app.Major) || queryObject.Major.Count == 0)
                                                        && (queryObject.ExperienceLevel.Contains(app.CareerLevel) || queryObject.ExperienceLevel.Count == 0)
                                                        && (queryObject.GPA <= app.GPA2 || queryObject.GPA == null) ).ToList<Applicant>();
        }
    }
}
