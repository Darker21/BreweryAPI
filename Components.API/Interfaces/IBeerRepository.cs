using Components.API.Models;

namespace Components.API.Interfaces
{
    public interface IBeerRepository : ITableRespository<Beer>
    {
        public Task<IEnumerable<Beer>> GetByBreweryNameAlcholContentRange(string breweryName, double alcholContentStart, double alcholContentEnd);
    }
}
