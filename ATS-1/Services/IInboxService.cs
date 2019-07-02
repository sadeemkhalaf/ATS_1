using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public interface IInboxService
    {
        List<Inbox> GetAllInbox();
        // getAll
        Inbox GetInbox(int ID);
        // getByID
        void InsertInbox(Inbox inbox);
        // insert(obj)
        void UpdateInbox(Inbox inbox, int id);
        // update (obj, id)
        void DeleteInbox(int id);
        // delete (id)
    }
}
