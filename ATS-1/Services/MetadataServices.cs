using ATS_1.Data;
using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services.MetadataServices
{
    public class MetadataServices : IMetadataServices
    {
        private readonly ApplicationDBContext dbContext;

        public MetadataServices(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void DeleteMetadata(int id)
        {
            throw new NotImplementedException();
        }

        public List<Metadata> GetAllMetadata()
        {
            using (dbContext)
            {
                return dbContext.Metadata.ToList();
            }
        }

        public Metadata GetMetadata(int ID)
        {
            throw new NotImplementedException();
        }

        public void InsertMetadata(Metadata metadata)
        {
            throw new NotImplementedException();
        }

        public void UpdateMetadata(Metadata metadata, int id)
        {
            throw new NotImplementedException();
        }
    }
}
