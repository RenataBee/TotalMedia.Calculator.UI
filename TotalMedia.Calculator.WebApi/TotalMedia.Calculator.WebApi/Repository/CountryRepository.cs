using Microsoft.EntityFrameworkCore;
using TotalMedia.Calculator.WebApi.Data;
using TotalMedia.Calculator.WebApi.IRepository;
using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.WebApi.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public readonly DataContext _dataContext;

        public CountryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Country>> GetAllCountries()
        {
            try
            {
                var countries = await _dataContext.Countries.ToListAsync();
                return countries;
            }
            catch (Exception)
            {
                throw new Exception("Problem to access data base");
            }
        }

        public async Task<Country> GetCountryByCountryId(int countryId)
        {
            try
            {
                var country = await _dataContext.Countries.FindAsync(countryId);
                if (country == null)
                {
                    country = new Country();
                }
                return country;
            }
            catch (Exception)
            {
                throw new Exception("Problem to access data base");
            }
        }

        public async Task<List<Country>> AddCountry(Country country)
        {
            try
            {
                _dataContext.Countries.Add(country);
                await _dataContext.SaveChangesAsync();
                return (await _dataContext.Countries.ToListAsync());
            }
            catch (Exception)
            {
                throw new Exception("Problem to access data base");
            }
        }

        public async Task<List<Country>> UpdateCountry(Country country)
        {
            try
            {
                var dbCountry = await _dataContext.Countries.FindAsync(country.Id);
                if (dbCountry == null)
                    dbCountry = new Country();

                dbCountry.Name = country.Name;
                
                await _dataContext.SaveChangesAsync();
                return (await _dataContext.Countries.ToListAsync());
            }
            catch (Exception)
            {
                throw new Exception("Problem to access data base");
            }
        }

        public async Task<List<Country>> DeleteCountry(int id)
        {
            try
            {
                var dbCountry = await _dataContext.Countries.FindAsync(id);
                if (dbCountry == null)
                    dbCountry = new Country();

                _dataContext.Countries.Remove(dbCountry);
                await _dataContext.SaveChangesAsync();
                return (await _dataContext.Countries.ToListAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }              
    }
}
