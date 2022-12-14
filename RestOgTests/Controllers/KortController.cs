using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestOgTests.DBContext;
using RestOgTests.Managers;
using RestOgTests.Models;

namespace RestOgTests.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class KortController : ControllerBase
    {
        private readonly IKortManager _manager;
        public KortController(CheckInEasyContext _context)
        {
            _manager = new KortDBManager(_context);
        }


        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Kort>> Get()
        {
            IEnumerable<Kort> list = _manager.GetAll();
            if (list == null || list.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(list);
            }
        }

        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Kort> Get(int id)
        {
            Kort getKort = _manager.GetById(id);
            if (getKort == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(getKort);
            }
        }

        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Kort> Post([FromBody] Kort newKort)
        {
            try
            {
                Kort createdKort = _manager.Add(newKort);
                return Created("/" + createdKort.CardId, createdKort);
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

        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Kort> Put(int id, [FromBody] Kort updates)
        {
            try
            {
                Kort updatedKort = _manager.Update(id, updates);
                if (updatedKort == null)
                {
                    return NotFound();
                }
                return Ok(updatedKort);
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

        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Kort> Delete(int id)
        {
            Kort deletedKort = _manager.Delete(id);
            if (deletedKort == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(deletedKort);
            }
        }
    }
}
