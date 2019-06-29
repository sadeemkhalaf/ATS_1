using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services
{
    public interface IMetadataService
    {

        List<Metadata> GetAllMetadata();
        // getAll
        Metadata GetMetadata(int ID);
        // getByID
        void InsertMetadata(Metadata metadata);
        // insert(obj)

    }
}
