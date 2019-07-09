using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS_1.Data;
using ATS_1.Models;

namespace ATS_1.Services
{
    public class ApplicantStatusHistoryService : IApplicantStatusHistoryService
    {
        private ApplicationDBContext dbContext;
        public ApplicantStatusHistoryService(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;

        }

        public List<ApplicantStatusHistory> GetAllApplicantStatusHistory()
        {
            throw new NotImplementedException();
        }

        public ApplicantStatusHistory GetApplicantStatusHistory(int ID)
        {
            throw new NotImplementedException();
        }

        public void InsertApplicantStatusHistory(ApplicantStatusHistory ActivityLog)
        {
            throw new NotImplementedException();
        }
        public void DeleteApplicantStatusHistory(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
