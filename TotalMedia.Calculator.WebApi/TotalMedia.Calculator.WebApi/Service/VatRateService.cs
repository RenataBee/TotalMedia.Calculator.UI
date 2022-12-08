using TotalMedia.Calculator.WebApi.IRepository;
using TotalMedia.Calculator.WebApi.IService;
using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.WebApi.Service
{
    public class VatRateService : IVatRateService
    {
        private readonly IVatRatesRepository _vatRatesRepository;

        public VatRateService(IVatRatesRepository vatRatesRepository)
        {
            _vatRatesRepository = vatRatesRepository;   
        }

        public async Task<List<VatRate>> GetAllVatRates()
        {
            try
            {
                var vatRates = await _vatRatesRepository.GetAllVatRates();
                return vatRates;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }

        public async Task<VatRate> GetVatRatesById(int idCountry)
        {
            try
            {
                var vatRate = await _vatRatesRepository.GetVatRatesById(idCountry);
                return vatRate;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }

        public async Task<List<VatRate>> GetVatRateByCountryId(int countryId)
        {
            try
            {
                var vatRates = await _vatRatesRepository.GetVatRateByCountryId(countryId);
                return vatRates;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }

        public async Task<List<VatRate>> AddVatRates(VatRate vatRate)
        {
            try
            {
                var vatRates = await _vatRatesRepository.AddVatRates(vatRate);
                return vatRates;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }

        public async Task<List<VatRate>> DeleteVatRates(int id)
        {
            try
            {
                var vatRates = await _vatRatesRepository.DeleteVatRates(id);
                return vatRates;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }       

        public async Task<List<VatRate>> UpdateVatRates(VatRate vatRate)
        {
            try
            {
                var vatRates = await _vatRatesRepository.UpdateVatRates(vatRate);
                return vatRates;
            }
            catch (Exception)
            {
                throw new Exception("Bad Request");
            }
        }
    }
}
