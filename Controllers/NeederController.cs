using BloodDonor.BL.Interface;
using BloodDonor.BL.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodDonor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeederController : ControllerBase
    {
        private readonly INeederRep _neederRep;

        public NeederController(INeederRep needer)
        {
            _neederRep = needer;

        }
        // GET: api/<NeederController>
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public IActionResult Get()
        {
            return Ok(_neederRep.Get());
        }


        // GET api/<NeederController>/5
        [HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        public IActionResult Get(int id)
        {
            return Ok(_neederRep.GetById(id));
        }

        // POST api/<NeederController>
        [HttpPost]
        public void Post([FromBody] NeederVM value)
        {
            _neederRep.Add(value);
        }

        // PUT api/<NeederController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NeederVM value)
        {
            var needer = _neederRep.GetById(id);
            needer.Name = value.Name;
            _neederRep.Edit(needer);

        }

        // DELETE api/<NeederController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _neederRep.Delete(id);
        }
    }
}
