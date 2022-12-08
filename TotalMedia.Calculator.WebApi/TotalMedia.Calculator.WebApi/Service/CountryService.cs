using System.Diagnostics.Metrics;
using TotalMedia.Calculator.WebApi.IRepository;
using TotalMedia.Calculator.WebApi.IService;
using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.WebApi.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            try
            {
                var countries = await _countryRepository.GetAllCountries();
                return countries;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }

        public async Task<List<Country>> AddCountry(Country country)
        {
            try
            {
                var countries = await _countryRepository.AddCountry(country);
                return countries;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }

        public async Task<List<Country>> DeleteCountry(int id)
        {
            try
            {
                var countries = await _countryRepository.DeleteCountry(id);
                return countries;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }

        public async Task<Country> GetCountryByCountryId(int countryId)
        {
            try
            {
                var country = await _countryRepository.GetCountryByCountryId(countryId);
                return country;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }

        public async Task<List<Country>> UpdateCountry(Country country)
        {
            try
            {
                var countries = await _countryRepository.UpdateCountry(country);
                return countries;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }
    }
}
