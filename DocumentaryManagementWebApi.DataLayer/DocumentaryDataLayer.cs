using DocumentaryManagementWebApi.CustomExceptions;
using DocumentaryManagementWebApi.DataLayer.Models;
using DocumentaryManagementWebApi.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentaryManagementWebApi.DataLayer
{
    public class DocumentaryDataLayer : IDocumentaryDataLayer
    {
        private readonly DocumentaryDbContext _documentaryDbContext;

        public DocumentaryDataLayer(DocumentaryDbContext documentaryDbContext)
        {
            _documentaryDbContext = documentaryDbContext;
        }

        public async Task<bool> AddDocumentary(Documentary documentary)
        {
            bool flag = true;

            try
            {
                DocumentaryModel documentaryModel = new DocumentaryModel();

                documentaryModel.DocumentaryId = documentary.DocumentaryId;
                documentaryModel.DocumentaryName = documentary.DocumentaryName;
                documentaryModel.DocumentaryGenre = documentary.DocumentaryGenre;
                documentaryModel.ActorId = documentary.ActorId;

                //Create Actor object
                documentaryModel.Actor = _documentaryDbContext.Actors.Find(documentary.ActorId);

                if (documentaryModel.Actor == null) {
                    throw new InvalidActorIdException("Actor Doesn't Exist");
                }
                _documentaryDbContext.Documentaries.Add(documentaryModel);

                int rowAffected = await _documentaryDbContext.SaveChangesAsync();

                if (rowAffected < 1)
                {
                    
                }
            }
            catch (InvalidSqlOperation)
            {
                throw new InvalidSqlOperation("Some Error Occurred");
            }

            return flag;
        }

        public async Task<List<Documentary>> ShowDocumentaries()
        {
            List<Documentary> documentaries = new List<Documentary>();
            try
            {
                List<DocumentaryModel> documentaryModels = await _documentaryDbContext.Documentaries.ToListAsync();

                //documentaries = new List<Documentary>();

                if (documentaryModels.Count == 0)
                {
                    throw new EmptyListException("No Documentaries Present");
                }

                foreach (var item in documentaryModels)
                {
                    Documentary documentary = new Documentary();

                    documentary.DocumentaryId = item.DocumentaryId;
                    documentary.DocumentaryName = item.DocumentaryName;
                    documentary.DocumentaryGenre = item.DocumentaryGenre;
                    documentary.ActorId = item.ActorId;

                    documentary.actor = new Actor();
                    ActorModel actorModel = _documentaryDbContext.Actors.Find(item.ActorId);
                    documentary.actor.ActorId = actorModel.ActorId;
                    documentary.actor.ActorName = actorModel.ActorName;
                    documentary.actor.ActorGender = actorModel.ActorGender;
                    documentary.actor.ActorDateOfBirth = actorModel.ActorDateOfBirth;
                    documentary.actor.ActorAge = actorModel.ActorAge;

                    documentaries.Add(documentary);
                }
            }
            catch (InvalidSqlOperation)
            {
                throw new InvalidSqlOperation("Some error Occurred");
            }

            return documentaries;
        }

        public async Task<List<Documentary>> ShowDocumentary(int id)
        {
            List<Documentary> documentaries = new List<Documentary>();
            try
            {
                List<DocumentaryModel> documentaryModels = await (from t in _documentaryDbContext.Documentaries where t.ActorId == id select t).ToListAsync();

                if (documentaryModels.Count == 0)
                {
                    throw new EmptyListException("No Record Exist");
                }

                foreach (var item in documentaryModels)
                {
                    Documentary documentary = new Documentary();

                    documentary.DocumentaryId = item.DocumentaryId;
                    documentary.DocumentaryName = item.DocumentaryName;
                    documentary.DocumentaryGenre = item.DocumentaryGenre;

                    documentary.ActorId = item.ActorId;

                    documentary.actor = new Actor();
                    ActorModel actorModel = _documentaryDbContext.Actors.Find(item.ActorId);
                    documentary.actor.ActorId = actorModel.ActorId;
                    documentary.actor.ActorName = actorModel.ActorName;
                    documentary.actor.ActorGender = actorModel.ActorGender;
                    documentary.actor.ActorDateOfBirth = (actorModel.ActorDateOfBirth);
                    documentary.actor.ActorAge = actorModel.ActorAge;

                    documentaries.Add(documentary);

                }
            }
            catch (InvalidSqlOperation)
            {
                throw new InvalidSqlOperation("Some Error Occurred");
            }

            return documentaries;
        }
    }
}