using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DocumentaryManagementWebApi.Entity;

namespace DocumentaryManagementWebApi.DataLayer
{
    public interface IDocumentaryDataLayer
    {
        //To Add New Documentary
        Task<bool> AddDocumentary(Documentary documentary);

        //Show All Documentaries
        Task<List<Documentary>> ShowDocumentaries();

        //Show Documentary By Id
        Task<List<Documentary>> ShowDocumentary(int id);
    }
}
