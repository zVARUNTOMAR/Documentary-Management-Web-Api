using DocumentaryManagementWebApi.DataLayer;
using DocumentaryManagementWebApi.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentaryManagementWebApi.BussinessLayer
{
    public class DocumentaryBussinessLayer : IDocumentaryBussinessLayer
    {
        private readonly IDocumentaryDataLayer _documentaryData;

        public DocumentaryBussinessLayer(IDocumentaryDataLayer documentaryData)
        {
            _documentaryData = documentaryData;
        }

        //Add New Documentary
        public async Task<bool> AddDocumentary(Documentary documentary)
        {
            return await _documentaryData.AddDocumentary(documentary);
        }

        //Show all Documentaries
        public async Task<List<Documentary>> ShowDocumentaries()
        {
            List<Documentary> documentaries = await _documentaryData.ShowDocumentaries();

            return documentaries;
        }

        //Show Documentary by Id
        public async Task<List<Documentary>> ShowDocumentary(int id)
        {
            List<Documentary> documentaries = await _documentaryData.ShowDocumentary(id);

            return documentaries;
        }
    }
}