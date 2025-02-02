﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS_1.Data;
using ATS_1.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS_1.Services
{
    public class ApplicantFilesService : IApplicantFilesService, IDisposable
    {
        private readonly ApplicationDBContext dbContext;

        private ApplicantFilesService(ApplicationDBContext _dbContext) {
            this.dbContext = _dbContext; 
        }
        public void AddFiles(List<ApplicantFiles> applicantFile)
        {
            using (dbContext) {
                applicantFile.ForEach(file => {
                    dbContext.Entry<ApplicantFiles>(file).State = EntityState.Added;
                });
                dbContext.SaveChanges();
            }
        }

        public void DeleteFile(int id)
        {
                ApplicantFiles file = dbContext.ApplicantFiles.Find(id);
                dbContext.Entry<ApplicantFiles>(file).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }


        public List<ApplicantFiles> GetAllApplicantFiles(int ApplicantId)
        {
                return dbContext.ApplicantFiles.Where(appl => appl.ApplicantId == ApplicantId).ToList<ApplicantFiles>();
            }

        public List<ApplicantFiles> GetAllFiles()
        {
                if (dbContext.ApplicantFiles.Count() > 0) {
                    return dbContext.ApplicantFiles.ToList<ApplicantFiles>();
                }
                return null;
               
            }

        public ApplicantFiles GetFile(int ApplicantId, int id)
        {
                return dbContext.ApplicantFiles.Where(appl => appl.ApplicantId == ApplicantId && appl.Id == id).FirstOrDefault();
            }

        public void Dispose()
        {
            dbContext.Dispose();
        }

    }
}
