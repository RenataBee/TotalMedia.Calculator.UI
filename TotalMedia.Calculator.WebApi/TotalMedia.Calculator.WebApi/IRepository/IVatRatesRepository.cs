using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.WebApi.IRepository
{
    public interface IVatRatesRepository
    {
        Task<List<VatRate>> GetAllVatRates();

        Task<VatRate> GetVatRatesById(int idCountry);

        Task<List<VatRate>> GetVatRateByCountryId(int countryId);
        Task<List<VatRate>> AddVatRates (VatRate vatRate);

        Task<List<VatRate>> UpdateVatRates (VatRate vatRate);

        Task<List<VatRate>> DeleteVatRates(int id);
    }
}
