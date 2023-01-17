using Microsoft.AspNetCore.Mvc;

namespace Components.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        /// <summary>
        /// Gets all Beers in the database
        /// </summary>
        /// <example>api/BeerController</example>
        /// <returns>List of available Beers</returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BeerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BeerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BeerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BeerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
