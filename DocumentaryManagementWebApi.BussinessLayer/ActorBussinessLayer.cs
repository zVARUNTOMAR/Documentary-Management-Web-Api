using DocumentaryManagementWebApi.DataLayer;
using DocumentaryManagementWebApi.Entity;
using System.Threading.Tasks;

namespace DocumentaryManagementWebApi.BussinessLayer
{
    public class ActorBussinessLayer : IActorBussinessLayer
    {
        private readonly IActorDataLayer _actorData;

        public ActorBussinessLayer(IActorDataLayer actorData)
        {
            _actorData = actorData;
        }

        //Add New Actor
        public async Task<bool> AddActor(Actor actor)
        {
            return await _actorData.AddActor(actor);
        }
    }
}