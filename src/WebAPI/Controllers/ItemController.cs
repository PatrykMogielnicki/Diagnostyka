using Diagnostyka.Application.Common.Interfaces;
using Diagnostyka.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diagnostyka.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public ItemController(IItemManager context)
        {
            _itemContext = context;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _itemContext.GetAll().ToList();
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            Item? item = _itemContext.GetById(id);
            return (item == null) ? BadRequest("Nie znaleziono id w bazie") : Ok(item);
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item value)
        {
            _itemContext.Add(value);
            try
            {
                _itemContext.Context.SaveChanges();
            }catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Item value)
        {
            value.Id = id;
            _itemContext.Update(value);
            try
            {
                _itemContext.Context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        private readonly IItemManager _itemContext;
    }
}
