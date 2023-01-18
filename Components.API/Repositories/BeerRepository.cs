using Components.API.DBContexts;
using Components.API.Interfaces;
using Components.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Components.API.Repositories
{
    public class BeerRepository : TableRepository<Beer>, IBeerRepository
    {

        public BeerRepository(BreweryDBContext dBContext): base (dBContext) 
        {
        }

        public async Task<IEnumerable<Beer>> GetByBreweryNameAlcholContentRange(string breweryName, double alcholContentStart, double alcholContentEnd)
        {
            try
            {
                return await _dbContext.Beers.Where(x =>
                    x.Brewery == breweryName &&
                    x.PercentageAlcoholByVolume > alcholContentStart &&
                    x.PercentageAlcoholByVolume < alcholContentEnd
                ).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                // Would log exception here 
                throw new Exception($"Could not retrieve entities breweryName={breweryName}, gtAlcoholByVolume={alcholContentStart}, ltAlcoholByVolume={alcholContentEnd}: {ex.Message}");
            }
        }
    }
}
