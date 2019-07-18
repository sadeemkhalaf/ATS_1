using System.Collections.Generic;
using System.Linq;
using ATS_1.Data;
using ATS_1.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS_1.Services
{
    public class ApplicantEducationDetailsService : IApplicantEducationDetailsService
    {
        private readonly ApplicationDBContext dbContext;

        private ApplicantEducationDetailsService(ApplicationDBContext _dbContext) {
            this.dbContext = _dbContext;
        }
        public void AddEducationField(List<ApplicantEducationDetails> applicantEducation)
        {
            using (dbContext) {
                applicantEducation.ForEach(applicantEducationItem => {
                    dbContext.Entry<ApplicantEducationDetails>(applicantEducationItem).State = EntityState.Added;
                });
                dbContext.SaveChanges();
            }
        }

        public void DeleteEducationField(int id)
        {
            using (dbContext) {
                ApplicantEducationDetails applicantEducation = dbContext.ApplicantEducationDetails.Find(id);
                if ( applicantEducation != null ) {
                    dbContext.Entry<ApplicantEducationDetails>(applicantEducation).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        public void EditEducationField(ApplicantEducationDetails applicantEducation)
        {
            using (dbContext)
            {
                ApplicantEducationDetails applicantEducationFound = dbContext.ApplicantEducationDetails.Find(applicantEducation.Id);
                    if (applicantEducationFound != null) {
                        applicantEducationFound.Degree = applicantEducation.Degree ?? applicantEducation.Degree;
                        applicantEducationFound.GPA = applicantEducation.GPA ?? applicantEducationFound.GPA;
                        applicantEducationFound.Major = applicantEducation.Major ?? applicantEducationFound.Major;
                        applicantEducationFound.University = applicantEducation.University ?? applicantEducationFound.University;
                        applicantEducationFound.GraduationYear = applicantEducation.GraduationYear ?? applicantEducationFound.GraduationYear;
                        applicantEducationFound.StartYear = applicantEducation.StartYear ?? applicantEducation.StartYear;
                        applicantEducationFound.Graduated = applicantEducation.Graduated;
                        dbContext.Entry<ApplicantEducationDetails>(applicantEducationFound).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                } 
            }

        public List<ApplicantEducationDetails> GetAll()
        {
            using (dbContext)
            {
                    return dbContext.ApplicantEducationDetails.ToList<ApplicantEducationDetails>();
                
            }
        }

        public List<ApplicantEducationDetails> GetAllApplicantEducationDetails(int ApplicantId)
        {
            using (dbContext)
            {
                return dbContext.ApplicantEducationDetails.Where(appl => appl.ApplicantId == ApplicantId).ToList<ApplicantEducationDetails>();
            }   
        }
    }
}
