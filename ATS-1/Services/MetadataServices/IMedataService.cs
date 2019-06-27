using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services.MetadataServices
{
    public interface IMetadataServices
    {
        List<Metadata> GetAllMetadata();
        // getAll
        Index GetMetadata(int ID);
        // getByID
        void InsertMetadata(Metadata metadata);
        // insert(obj)
        void UpdateMetadata(Metadata metadata, int id);
        // update (obj, id)
        void DeleteMetadata(int id);
        // delete (id)
    }
}
