using System;
using System.Collections.Generic;
using System.Text;
using DocumentaryManagementWebApi.Entity;
using System.Threading.Tasks;

namespace DocumentaryManagementWebApi.DataLayer
{
    public interface IActorDataLayer
    {
        Task<bool> AddActor(Actor actor);
    }
}
