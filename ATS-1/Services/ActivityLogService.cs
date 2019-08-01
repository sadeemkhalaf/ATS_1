using ATS_1.Data;
using ATS_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public class ActivityLogService : IActivityLogService, IDisposable
    {
        private readonly ApplicationDBContext dbContext;

        public ActivityLogService(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<ActivityLog> GetAllActivityLog()
        {
                return dbContext.ActivityLog.ToList();
        }

        public ActivityLog GetActivityLog(int ID)
        {
                return dbContext.ActivityLog.Find(ID);
        }

        public void InsertLog(ActivityLog ActivityLog)
        {
                ActivityLog.ActivityDatetime = DateTime.Now;
                dbContext.Entry<ActivityLog>(ActivityLog).State = EntityState.Added;
                dbContext.SaveChanges();
        }

        public void DeleteActivityLog(int ID) {
                ActivityLog ActivityLog = GetActivityLog(ID);
                dbContext.Entry<ActivityLog>(ActivityLog).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
