using DocumentaryManagementWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocumentaryManagementWebApi.BussinessLayer
{
    public interface IActorBussinessLayer
    {
        //Add new Actor
        Task<bool> AddActor(Actor actor);
    }
}
