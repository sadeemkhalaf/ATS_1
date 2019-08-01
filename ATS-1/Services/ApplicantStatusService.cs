using System.Collections.Generic;
using System.Linq;
using ATS_1.Data;
using ATS_1.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS_1.Services
{
    public class ApplicantStatusHistoryService : IApplicantStatusHistoryService
    {
        private readonly ApplicationDBContext dbContext;
        public ApplicantStatusHistoryService(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<ApplicantStatusHistory> GetAllApplicantStatusHistory(int ID)
        {
            using (dbContext) {
                    return dbContext.ApplicantStatusHistory.Where(appl => appl.ApplicantId == ID).ToList<ApplicantStatusHistory>();
                }
        }
        

        public void DeleteApplicantStatusHistory(int ID)
        {
            using (dbContext) {
                List<ApplicantStatusHistory> applicantStatusHistories = dbContext.ApplicantStatusHistory
                    .Where(appl => appl.ApplicantId == ID)
                    .ToList<ApplicantStatusHistory>();
                foreach (var status in applicantStatusHistories) {
                    dbContext.Entry<ApplicantStatusHistory>(status).State = EntityState.Deleted;
                }
                dbContext.SaveChanges();
            }
        }

        public List<ApplicantStatusHistory> GetAllApplicantStatusHistory()
        {
            using (dbContext) {
                return dbContext.ApplicantStatusHistory.ToList();
            }
        }
    }
}
