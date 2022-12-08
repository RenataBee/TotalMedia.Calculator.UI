using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.WebApi.IService
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountries();

        Task<Country> GetCountryByCountryId(int countryId);

        Task<List<Country>> AddCountry(Country country);

        Task<List<Country>> UpdateCountry(Country country);

        Task<List<Country>> DeleteCountry(int id);
    }
}
