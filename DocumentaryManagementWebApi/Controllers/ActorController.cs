using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentaryManagementWebApi.BussinessLayer;
using DocumentaryManagementWebApi.Entity;
using DocumentaryManagementWebApi.CustomExceptions;

namespace DocumentaryManagementWebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : Controller
    {
        private readonly IActorBussinessLayer _actorData;

        public ActorController(IActorBussinessLayer actorData)
        {
            _actorData = actorData;
        }

       [HttpPost("AddActor")]
        public async Task<IActionResult> AddActor(Actor actor)
        {
            try
            {
                return Ok(await _actorData.AddActor(actor));
            }
            catch (InvalidSqlOperation e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
