using ATS_1.Data;
using ATS_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public class MetadataService : IMetadataService
    {
        private readonly ApplicationDBContext dbContext;

        public MetadataService(ApplicationDBContext _dbContext)
        {
            dbContext = _dbContext;
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
            using (dbContext) {
                return dbContext.Metadata.Find(ID);
            }
        }

        public void InsertMetadata(Metadata metadata)
        {
            using (dbContext)
            {
                dbContext.Entry<Metadata>(metadata).State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }

        public void DeleteMetadata(int ID) {
            using (dbContext) {
                Metadata metadata = dbContext.Metadata.Find(ID);
                dbContext.Entry<Metadata>(metadata).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

    }
}
