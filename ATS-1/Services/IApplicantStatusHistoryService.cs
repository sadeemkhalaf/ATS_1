using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public interface IApplicantStatusHistoryService
    {

        List<ApplicantStatusHistory> GetAllApplicantStatusHistory();
        List<ApplicantStatusHistory> GetAllApplicantStatusHistory(int ID);
        // getAll by applicant Id
        void DeleteApplicantStatusHistory(int ID);
        // insert(obj)
    }
}
