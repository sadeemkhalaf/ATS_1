using ATS_1.Data;
using ATS_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ATS_1.Services
{
    public class InboxService : IInboxService
    {
        private ApplicationDBContext dbContext;
        private Random Random = new Random();

        public InboxService(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void DeleteInbox(int id)
        {
            using (dbContext)
            {
                Inbox InboxedApplicant = dbContext.Inbox.Find(id);
                if (InboxedApplicant != null)
                {
                    dbContext.Entry<Inbox>(InboxedApplicant).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }

        public List<Inbox> GetAllInbox()
        {
            using (dbContext)
            {
                if (dbContext.Inbox.ToList().Count >= 0)
                {
                    return dbContext.Inbox.ToList();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public Inbox GetInbox(int id)
        {
            using (dbContext)
            {
                return dbContext.Inbox.Find(id);
            }
        }

        public void InsertInbox(Inbox InboxedApplicant) {
            using (dbContext)
            {
                dbContext.Entry<Inbox>(InboxedApplicant).State = EntityState.Added;
                dbContext.SaveChanges();
            }
    }
}
}
