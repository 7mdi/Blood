using BloodDonor.BL.Interface;
using BloodDonor.BL.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodDonor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorRep _donorRep;

        public DonorController(IDonorRep donor)
        {
            _donorRep = donor;

        }

        // GET: api/<DonorController>
        //[HttpGet]
        //public IEnumerable<DonorVM> Get()
        //{
        //    var s = DonorRep.Get();
        //    return s;
        //}


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_donorRep.Get());
        }


        // GET api/<DonorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_donorRep.GetById(id));
        }

        // POST api/<DonorController>
        [HttpPost]
        public void Post([FromBody] DonorVM donor)
        {
            _donorRep.Add(donor);    
        }

        // PUT api/<DonorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DonorVM value)
        {
            var donor = _donorRep.GetById(id);
            donor.Name = value.Name;
            _donorRep.Edit(donor);
        }

        // DELETE api/<DonorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _donorRep.Delete(id);
        }
    }
}
