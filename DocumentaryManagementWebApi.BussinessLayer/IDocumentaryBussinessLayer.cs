using DocumentaryManagementWebApi.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentaryManagementWebApi.BussinessLayer
{
    public interface IDocumentaryBussinessLayer
    {
        //Add New Documentary
        Task<bool> AddDocumentary(Documentary documentary);

        //Show All Documentaries
        Task<List<Documentary>> ShowDocumentaries();

        //Show Documentary by Id
        Task<List<Documentary>> ShowDocumentary(int id);
    }
}