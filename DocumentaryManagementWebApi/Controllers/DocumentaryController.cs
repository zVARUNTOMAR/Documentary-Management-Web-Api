using DocumentaryManagementWebApi.BussinessLayer;
using DocumentaryManagementWebApi.CustomExceptions;
using DocumentaryManagementWebApi.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DocumentaryManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentaryController : Controller
    {
        private readonly IDocumentaryBussinessLayer _documentaryData;

        public DocumentaryController(IDocumentaryBussinessLayer documentaryData)
        {
            _documentaryData = documentaryData;
        }

        [HttpPost("AddDocumentary")]
        public async Task<IActionResult> AddDocumentary(Documentary documentary)
        {
            try
            {
                return Ok(await _documentaryData.AddDocumentary(documentary));
            }
            catch (InvalidActorIdException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidSqlOperation e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ShowDocumentaries")]
        public async Task<IActionResult> ShowDocumentaries()
        {
            try
            {
                return Ok(await _documentaryData.ShowDocumentaries());
            }
            catch (InvalidSqlOperation e)
            {
                return BadRequest(e.Message);
            }
            catch (EmptyListException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ShowDocumentary/{id}")]
        public async Task<IActionResult> ShowDocumentary(int id)
        {
            try
            {
                return Ok(await _documentaryData.ShowDocumentary(id));
            }
            catch (InvalidSqlOperation e)
            {
                return BadRequest(e.Message);
            }
            catch (EmptyListException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}