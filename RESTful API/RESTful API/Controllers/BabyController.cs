using Microsoft.AspNetCore.Mvc;
using RESTful_API.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
Type T;
namespace RESTful_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BabyController : ControllerBase
    {
        private static List<Baby> babyList = new List<Baby>{};

        // GET: api/<BabyController>
        [HttpGet]
        public IEnumerable<Baby> Get()
        {
            return babyList;
        }

        // GET api/<BabyController>/5
        [HttpGet("{id}")]
        public ActionResult<Baby> Get(int id)
        {
            var baby = babyList.Find(x => x.Id == id);
            if(baby == null)
                return NotFound();
            return baby;
            //return Ok(baby);
        }
       
        // POST api/<BabyController>
        [HttpPost]
        public void Post([FromBody] Baby baby)
        {
            babyList.Add(new Baby { Id = baby.Id, Age = baby.Age, Name = baby.Name });
        }

        // PUT api/<BabyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Baby updateBaby)
        {
            var baby = babyList.Find(x => x.Id == id);
            baby.Id = updateBaby.Id;
            baby.Name = updateBaby.Name;
            baby.Age = updateBaby.Age;
        }

        // DELETE api/<BabyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var baby = babyList.Find(x => x.Id == id);
            babyList.Remove(baby);
        }
    }
}
