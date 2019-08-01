using System;
using System.Collections.Generic;
using System.Linq;
using ATS_1.Data;
using ATS_1.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS_1.Services
{
    public class ApplicantEducationDetailsService : IApplicantEducationDetailsService, IDisposable
    {
        private readonly ApplicationDBContext dbContext;

        private ApplicantEducationDetailsService(ApplicationDBContext _dbContext) {
            this.dbContext = _dbContext;
        }
        public void AddEducationField(List<ApplicantEducationDetails> applicantEducation)
        {
                applicantEducation.ForEach(applicantEducationItem => {
                    dbContext.Entry<ApplicantEducationDetails>(applicantEducationItem).State = EntityState.Added;
                });
                dbContext.SaveChanges();
            }

        public void DeleteEducationField(int id)
        {
                ApplicantEducationDetails applicantEducation = dbContext.ApplicantEducationDetails.Find(id);
                if ( applicantEducation != null ) {
                    dbContext.Entry<ApplicantEducationDetails>(applicantEducation).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }

        public void EditEducationField(ApplicantEducationDetails applicantEducation)
        {
            ApplicantEducationDetails applicantEducationFound = dbContext.ApplicantEducationDetails.Where(appl => appl.ApplicantId == applicantEducation.ApplicantId)
                .ToList<ApplicantEducationDetails>().Where(applicant => applicant.Id == applicantEducation.Id ).FirstOrDefault<ApplicantEducationDetails>();
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

        public List<ApplicantEducationDetails> GetAll()
        {
                    return dbContext.ApplicantEducationDetails.ToList<ApplicantEducationDetails>();     
            }

        public List<ApplicantEducationDetails> GetAllApplicantEducationDetails(int ApplicantId)
        {
                return dbContext.ApplicantEducationDetails.Where(appl => appl.ApplicantId == ApplicantId).ToList<ApplicantEducationDetails>();
            }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
