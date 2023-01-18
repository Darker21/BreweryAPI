namespace Components.API.Interfaces
{
    public interface ITableRespository<TTable> where TTable : class
    {
        public Task<IEnumerable<TTable>> GetAllAsync();

        public Task<TTable> GetByIdAsync(int id);

        public Task<TTable> CreateAsync(TTable tInstance);

        public Task<TTable> UpdateAsync(TTable tInstance);

        public Task<bool> DeleteAsync(int id);
    }
}
