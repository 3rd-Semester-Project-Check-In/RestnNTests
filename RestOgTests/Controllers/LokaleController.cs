using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestOgTests.DBContext;
using RestOgTests.Managers;
using RestOgTests.Models;

namespace RestOgTests.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class LokaleController : Controller
    {
        private readonly ILokaleManager _manager;
        public LokaleController(CheckInEasyContext _context) 
        {
            _manager = new DBManager(_context);
        }


        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Lokale>> Get()
        {
            IEnumerable<Lokale> list = _manager.GetAll();
            if (list == null || list.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(list);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Lokale> Get(string id)
        {
            Lokale getLokale = _manager.GetById(id);
            if (getLokale == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(getLokale);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Lokale> Post([FromBody] Lokale newLokale)
        {
            try
            {
                Lokale createdLokale = _manager.Add(newLokale);
                return Created("/" + createdLokale.LokaleId, createdLokale);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Lokale> Put(string id, [FromBody] Lokale updates)
        {
            try
            {
                Lokale updatedLokale = _manager.Update(id, updates);
                if (updatedLokale == null)
                {
                    return NotFound();
                }
                return Ok(updatedLokale);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Lokale> Delete(string id)
        {
            Lokale deletedLokale = _manager.Delete(id);
            if (deletedLokale == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(deletedLokale);
            }
        }
    }
}
