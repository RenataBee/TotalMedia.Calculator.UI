using TotalMedia.Calculator.WebApi.IService;
using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.Tests
{
    public class VatRatesTests
    {
        private readonly IVatRateService _vatRateService;

        public VatRatesTests(IVatRateService vatRateService)
        {
            _vatRateService = vatRateService;
        }

        [Fact]
        public async void Test_GetAllCountries()
        {
            //Arrange
            int ratesOnDB = 12;

            //Act
            var actionResult = await _vatRateService.GetAllVatRates();

            //Assert
            var returnVatRates = actionResult as List<VatRate>;
            Assert.NotNull(actionResult);
            Assert.Equal(ratesOnDB, returnVatRates.Count());
        }
    }
}
