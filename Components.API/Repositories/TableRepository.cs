using Components.API.DBContexts;
using Components.API.Interfaces;
using Components.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Components.API.Repositories
{
    public class TableRepository<TTable> : ITableRespository<TTable> where TTable : TableModel
    {
        protected BreweryDBContext _dbContext;

        public TableRepository(BreweryDBContext dBContext) 
        {
            _dbContext = dBContext;
        }

        /// <summary>
        /// Creates a new record in the database
        /// </summary>
        /// <param name="record">Instance of object to create database record for</param>
        /// <returns>Instance of object back to client</returns>
        /// <exception cref="ArgumentNullException">Thrown if instance passed is null</exception>
        /// <exception cref="Exception">Additional context exception thrown when EF fails</exception>
        public async Task<TTable> CreateAsync(TTable record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            try
            {
                await _dbContext.Set<TTable>().AddAsync(record);
                await _dbContext.SaveChangesAsync();
                return record;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(record)} could not be saved: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a record from the database by Id
        /// </summary>
        /// <param name="id">Id of the object to delete from Database</param>
        /// <returns>Boolean indicating whether deletion was successful</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteAsync(int id)
        {
            TTable record = await _dbContext.Set<TTable>().FindAsync(id);
            if (record == null)
            {
                throw new Exception($"{nameof(id)} could not be found.");
            }

            _dbContext.Set<TTable>().Remove(record);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        /// <summary>
        /// Gets all records from designated table
        /// </summary>
        /// <returns>IEnumerable of records in the designated table</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<TTable>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<TTable>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                // Would log exception here
                throw new Exception($"Could not retrieve entities: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets row from designated table by id
        /// </summary>
        /// <param name="id">Id of row to retrieve</param>
        /// <returns>Instance of object from DB</returns>
        /// <exception cref="Exception"></exception>
        public async Task<TTable> GetByIdAsync(int id)
        {
            try
            {
                TTable item = await _dbContext.Set<TTable>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
                if (item == null)
                {
                    throw new Exception($"No entity found with the Id={id}");
                }

                return item;
            }
            catch (Exception ex)
            {
                // Would log exception here
                throw new Exception($"Couldn't retrieve entity with Id={id}: {ex.Message}");
            }
        }

        /// <summary>
        /// Update instance of table entry
        /// </summary>
        /// <param name="instance">instance of object to commit to the database</param>
        /// <returns>Updated record</returns>
        /// <exception cref="ArgumentNullException">Thrown if instance passed is null or does not have an Id set</exception>
        /// <exception cref="Exception">Additional context exception thrown when EF fails</exception>
        public async Task<TTable> UpdateAsync(TTable instance)
        {
            if (instance == null || instance.Id < 1)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            try
            {
                _dbContext.Set<TTable>().Update(instance);
                await _dbContext.SaveChangesAsync();
                return instance;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(instance)} could not be updated: {ex.Message}");
            }
        }
    }
}
