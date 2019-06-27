using ATS_1.Data;
using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services.IndexServices
{
    public class IndexServices : IIndexServices
    {
        private ApplicationDBContext dbContext;

        public IndexServices(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void DeleteIndex(int id)
        {
            throw new NotImplementedException();
        }

        public List<Index> GetAllIndex()
        {
            throw new NotImplementedException();
        }

        public Index GetIndex(int ID)
        {
            throw new NotImplementedException();
        }

        public void InsertIndex(Index index)
        {
            throw new NotImplementedException();
        }

        public void UpdateIndex(Index index, int id)
        {
            throw new NotImplementedException();
        }
    }
}
