using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    interface IApplicantStatusHistoryService
    {

        List<ApplicantStatusHistory> GetAllApplicantStatusHistory();
        // getAll
        ApplicantStatusHistory GetApplicantStatusHistory(int ID);
        // getByID
        void InsertApplicantStatusHistory(ApplicantStatusHistory ActivityLog);
        // insert(obj)

        void DeleteApplicantStatusHistory(int ID);
        // insert(obj)
    }
}
