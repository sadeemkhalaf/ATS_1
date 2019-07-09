using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public interface IActivityLogService
    {

        List<ActivityLog> GetAllActivityLog();
        // getAll
        ActivityLog GetActivityLog(int ID);
        // getByID
        void InsertLog(ActivityLog ActivityLog);
        // insert(obj)

        void DeleteActivityLog(int ID);
        // insert(obj)

    }
}
