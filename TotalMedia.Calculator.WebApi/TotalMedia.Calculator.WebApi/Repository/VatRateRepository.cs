using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TotalMedia.Calculator.WebApi.Data;
using TotalMedia.Calculator.WebApi.IRepository;
using TotalMedia.Calculator.WebApi.Models;

namespace TotalMedia.Calculator.WebApi.Repository
{
    public class VatRateRepository : IVatRatesRepository
    {
        public readonly DataContext _dataContext;

        public VatRateRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<VatRate>> GetAllVatRates()
        {
            try
            {
                var vatRates = await _dataContext.VatRates.ToListAsync();
                return vatRates;
            }
            catch (Exception)
            {
                throw new Exception("Problem to access data base");
            }
        }

        public async Task<VatRate> GetVatRatesById(int id)
        {
            try
            {
                var vatRate = await _dataContext.VatRates.FindAsync(id);
                if (vatRate == null)
                    vatRate = new VatRate();

                return vatRate;
            }
            catch (Exception)
            {
                throw new Exception("Problem to access data base");
            }
        }

        public async Task<List<VatRate>> GetVatRateByCountryId(int countryId)
        {
            try
            {
                var vatRates = await _dataContext.VatRates.Where(v => v.CountryId == countryId).ToListAsync();
                return vatRates;
            }
            catch (Exception)
            {
                throw new Exception("Problem to access data base");
            }
        }

        public async Task<List<VatRate>> AddVatRates(VatRate vatRate)
        {
            try
            {
                _dataContext.VatRates.Add(vatRate);
                await _dataContext.SaveChangesAsync();
                return (await _dataContext.VatRates.ToListAsync());
            }
            catch (Exception)
            {
                throw new Exception("Problem to access data base");
            }
        }

        public async Task<List<VatRate>> UpdateVatRates(VatRate vatRate)
        {
            try
            {
                var dbReturn = await _dataContext.VatRates.FindAsync(vatRate.Id);
                if (dbReturn == null)
                    dbReturn = new VatRate();

                dbReturn.TypeOfVatRates = vatRate.TypeOfVatRates;
                dbReturn.Percentual = vatRate.Percentual;
                dbReturn.CountryId = vatRate.CountryId;

                await _dataContext.SaveChangesAsync();
                return (await _dataContext.VatRates.ToListAsync());
            }
            catch (Exception)
            {
                throw new Exception("Problem to access data base");
            }
        }

        public async Task<List<VatRate>> DeleteVatRates(int id)
        {
            try
            {
                var dbReturn = await _dataContext.VatRates.FindAsync(id);
                if (dbReturn == null)
                    dbReturn = new VatRate();

                _dataContext.VatRates.Remove(dbReturn);
                await _dataContext.SaveChangesAsync();
                return (await _dataContext.VatRates.ToListAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
