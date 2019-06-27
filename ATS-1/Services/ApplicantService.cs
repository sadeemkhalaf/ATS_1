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

            using (var _dbContext = new ApplicationDBContext())
            {
                applicantFound = _dbContext.Applicants.Where(appl => appl.Id == id).FirstOrDefault<Applicant>();
            }
            // the entity is updated in a disconnected context
            if (applicantFound != null) {
                    applicantFound.name = applicant.name;
                    applicantFound.status = applicant.status;
                    applicantFound.phonenumber = applicant.phonenumber;
                    applicantFound.email = applicant.email;
                    applicantFound.degree = applicant.degree;
                    applicantFound.university = applicant.university;
                    applicantFound.otheruniversity = applicant.otheruniversity;
                    applicantFound.gpa1 = applicant.gpa1;
                    applicantFound.gpa2 = applicant.gpa2;
                    applicantFound.currentposition = applicant.currentposition;
                    applicantFound.technologies = applicant.technologies;
                    applicantFound.devexperience = applicant.devexperience;
                    applicantFound.teamleaderexperience = applicant.teamleaderexperience;
                    applicantFound.joindate = applicant.joindate;
                    applicantFound.expectedsalary = applicant.expectedsalary;
                    applicantFound.howdidyoufindus = applicant.howdidyoufindus;
                    applicantFound.notelog = applicant.notelog;
                }
            using (var dbCtx = new ApplicationDBContext()) {
                // mark as modified
                dbCtx.Entry<Applicant>(applicantFound).State = EntityState.Modified;
                // save changes
                dbCtx.SaveChanges();
            }
            
        }
    }
}
