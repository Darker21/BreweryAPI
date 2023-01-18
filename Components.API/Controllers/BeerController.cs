using Components.API.Interfaces;
using Components.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Components.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private IBeerRepository _beerRepository;

        public BeerController(IBeerRepository beerRepository) {
            _beerRepository = beerRepository;
        }

        // POST api/<BeerController>
        [HttpPost]
        public Beer Post([FromBody] Beer value)
        {
            return _beerRepository.CreateAsync(value).Result;
        }

        // PUT api/<BeerController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Beer updatedInstance)
        {
            try
            {
                Beer result = _beerRepository.UpdateAsync(updatedInstance).Result;

                // If we have a result back - we have successfully updated the record
                if (result != null)
                {
                    return "Successfully updated Beer.";
                }


                return "Failed to update Beer.";

            }
            catch (Exception) 
            {
                return "Failed to update Beer.";
            }
        }

        // GET api/<BeerController>?breweryName=Tetleys&gtAlcoholByVolume=3.0&ltAlcoholByVolume=4.0
        [HttpGet]
        public IEnumerable<Beer> Get([FromQuery] string breweryName, [FromQuery] double gtAlcoholByVolume, [FromQuery]double ltAlchoholByVolume) 
        { 
            return _beerRepository.GetByBreweryNameAlcholContentRange(breweryName, gtAlcoholByVolume, ltAlchoholByVolume).Result;
        }


        // GET api/<BeerController>/5
        [HttpGet("{id}")]
        public Beer GetById(int id)
        {
            return _beerRepository.GetByIdAsync(id).Result;
        }

    }
}
