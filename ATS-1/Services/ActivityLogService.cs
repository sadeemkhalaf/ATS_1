using ATS_1.Data;
using ATS_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly ApplicationDBContext dbContext;

        public ActivityLogService(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<ActivityLog> GetAllActivityLog()
        {
            using (dbContext)
            {
                return dbContext.ActivityLog.ToList();
            }
        }

        public ActivityLog GetActivityLog(int ID)
        {
            using (dbContext) {
                return dbContext.ActivityLog.Find(ID);
            }
        }

        public void InsertLog(ActivityLog ActivityLog)
        {
            using (dbContext)
            {
                ActivityLog.ActivityDatetime = DateTime.Now;
                dbContext.Entry<ActivityLog>(ActivityLog).State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }

        public void DeleteActivityLog(int ID) {
            using (dbContext) {
                ActivityLog ActivityLog = dbContext.ActivityLog.Find(ID);
                dbContext.Entry<ActivityLog>(ActivityLog).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

    }
}
