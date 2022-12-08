using Microsoft.AspNetCore.Mvc;
using TotalMedia.Calculator.WebApi.IService;
using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountries();
            return Ok(countries);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryByCountryId(int id)
        {
            var country = await _countryService.GetCountryByCountryId(id);
            return Ok(country);
        }

        [HttpPost]
        [Route("AddCountry")]
        public async Task<ActionResult<List<Country>>> AddCountry(Country country)
        {
            var countries = await _countryService.AddCountry(country);
            return Ok(countries);
        }

        [HttpPatch]
        [Route("UpdateCountry")]
        public async Task<ActionResult<List<Country>>> UpdateCountry(Country country)
        {
            var countries = await _countryService.UpdateCountry(country);
            return Ok(countries);
        }

        [HttpDelete]
        [Route("DeleteCountry")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            var countries = await _countryService.DeleteCountry(id);
            return Ok(countries);
        }
    }
}
