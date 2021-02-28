using DocumentaryManagementWebApi.DataLayer.Models;
using DocumentaryManagementWebApi.Entity;
using System;
using System.Threading.Tasks;
using DocumentaryManagementWebApi.CustomExceptions;

namespace DocumentaryManagementWebApi.DataLayer
{
    public class ActorDataLayer : IActorDataLayer
    {
        
        private readonly DocumentaryDbContext _documentaryDbContext;

        public ActorDataLayer(DocumentaryDbContext documentaryDbContext)
        {
            _documentaryDbContext = documentaryDbContext;
        }
        public async Task<bool> AddActor(Actor actor)
        {
            int rowAffected = 0;
            bool flag = true;

            try
            {
                ActorModel actorModel = new ActorModel();

                actorModel.ActorId = actor.ActorId;
                actorModel.ActorName = actor.ActorName;
                actorModel.ActorGender = actor.ActorGender;
                actorModel.ActorAge = actor.ActorAge;
                actorModel.ActorDateOfBirth = actor.ActorDateOfBirth;

                _documentaryDbContext.Actors.Add(actorModel);

                rowAffected = await _documentaryDbContext.SaveChangesAsync();

                if (rowAffected < 1) {
                    throw new InvalidSqlOperation("Some Error Occurred");
                }
            }
            catch (Exception)
            {
                throw new Exception("Some Error Occurred");
            }

            return flag;
        }
    }
}