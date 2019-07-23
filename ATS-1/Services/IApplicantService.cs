using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public interface IApplicantService
    {
        List<Applicant> GetApplicants();
        // getAll
        Applicant GetApplicant(int ID);
        // getByID
        void InsertApplicant(Applicant applicant);
        // insert(obj)
        void UpdateApplicant(Applicant applicant, int id);
        // update (obj, id)
        void DeleteApplicant(int id);
        // delete (id)

        int GetStatusCountQueryResult(string status);

        List<Applicant> GetApplicantByStatus(string status);

    }
}
