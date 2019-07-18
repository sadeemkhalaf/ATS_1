using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public interface IApplicantEducationDetailsService
    {
        List<ApplicantEducationDetails> GetAll();
        List<ApplicantEducationDetails> GetAllApplicantEducationDetails(int ApplicantId);
        void AddEducationField(List<ApplicantEducationDetails> applicantEducation);
        void EditEducationField(ApplicantEducationDetails applicantEducation);
        void DeleteEducationField(int id);
    }
}
