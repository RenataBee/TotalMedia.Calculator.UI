using TotalMedia.Calculator.WebApi.IService;
using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.Tests
{
    public class CountryTests
    {
        private readonly ICountryService _countryService;

        public CountryTests(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [Fact]
        public async void Test_GetAllCountries()
        {
            //Arrange
            int countriesOnDB = 4;

            //Act
            var actionResult = await _countryService.GetAllCountries();

            //Assert
            var returnCountries = actionResult as List<Country>;
            Assert.NotNull(actionResult);
            Assert.Equal(countriesOnDB, returnCountries.Count());
        }
    }
}