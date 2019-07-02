using ATS_1.Data;
using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public class InboxService : IInboxService
    {
        private ApplicationDBContext dbContext;

        public InboxService(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void DeleteInbox(int id)
        {
            throw new NotImplementedException();
        }

        public List<Inbox> GetAllInbox()
        {
            using (dbContext) {
                if (dbContext.Inbox.ToList().Count > 0) {
                    return dbContext.Inbox.ToList();
                } else {
                    throw new NotImplementedException();
                }
            } 
        }

        public Inbox GetInbox(int ID)
        {
            throw new NotImplementedException();
        }

        public void InsertInbox(Inbox inbox)
        {
            throw new NotImplementedException();
        }

        public void UpdateInbox(Inbox inbox, int id)
        {
            throw new NotImplementedException();
        }
    }
}
