using ATS_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Services.IndexServices
{
    interface IIndexServices
    {
        List<Index> GetAllIndex();
        // getAll
        Index GetIndex(int ID);
        // getByID
        void InsertIndex(Index index);
        // insert(obj)
        void UpdateIndex(Index index, int id);
        // update (obj, id)
        void DeleteIndex(int id);
        // delete (id)
    }
}
