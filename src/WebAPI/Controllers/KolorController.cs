using Diagnostyka.Application.Common.Interfaces;
using Diagnostyka.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Diagnostyka.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KolorController : ControllerBase
    {
        public KolorController(IKolorManager context) 
        { 
            _kolorContext= context;
        }
        // GET: api/<KolorController>
        [HttpGet]
        public IEnumerable<Kolor> Get()
        {
            return _kolorContext.GetAll().ToList();
        }

        // GET api/<KolorController>/5
        [HttpGet("{id}")]
        public Kolor Get(int id)
        {
            return _kolorContext.GetById(id);
        }

        // POST api/<KolorController>
        [HttpPost]
        public void Post([FromBody] Kolor value)
        {
            _kolorContext.Add(value);
            _kolorContext.Context.SaveChanges();
        }

        // PUT api/<KolorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Kolor value)
        {
            value.Id = id;
            _kolorContext.Update(value);
            _kolorContext.Context.SaveChanges();
        }

        // DELETE api/<KolorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _kolorContext.Deactivate(id);
        }

        private readonly IKolorManager _kolorContext;
    }
}
