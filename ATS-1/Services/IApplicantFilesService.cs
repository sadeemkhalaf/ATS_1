using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public interface IApplicantFilesService
    {
        // Add, get(all), get(id), delete
        List<ApplicantFiles> GetAllFiles();
        List<ApplicantFiles> GetAllApplicantFiles(int ApplicantId);
        ApplicantFiles GetFile(int ApplicantId ,int id);
        void AddFiles(List<ApplicantFiles> applicantFile);
        void DeleteFile(int id);
    }
}
