using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.WebApi.IRepository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();

        Task<Country> GetCountryByCountryId(int countryId);

        Task<List<Country>> AddCountry(Country country);

        Task<List<Country>> UpdateCountry(Country country);

        Task<List<Country>> DeleteCountry(int id);
    }
}
