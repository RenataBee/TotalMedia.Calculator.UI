using Microsoft.AspNetCore.Mvc;
using TotalMedia.Calculator.WebApi.IService;
using TotalMedia.Calculator.WebApi.Models;
using TotalMedia.Calculator.WebApi.Service;

namespace TotalMedia.Calculator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRatesController : ControllerBase
    {
        private readonly IVatRateService _vatRateService;

        public VatRatesController(IVatRateService vatRateService)
        {
            _vatRateService = vatRateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VatRate>>> GetAllVatRates()
        {
            var vatRateList = await _vatRateService.GetAllVatRates();
            return Ok(vatRateList);
        }

        [HttpGet("{countryId}")]
        public async Task<ActionResult<List<VatRate>>> GetVatRateByCountryId(int countryId)
        {
            var vatRate = await _vatRateService.GetVatRateByCountryId(countryId);
            return Ok(vatRate);
        }

        [HttpPost]
        public async Task<ActionResult<List<VatRate>>> AddVatRates(VatRate vatRate)
        {
            var vatRateList = await _vatRateService.AddVatRates(vatRate);
            return Ok(vatRateList);
        }

        [HttpPatch]
        public async Task<ActionResult<List<VatRate>>> UpdateVatRates(VatRate vatRate)
        {
            var vatRateList = await _vatRateService.UpdateVatRates(vatRate);
            return Ok(vatRateList);
        }

        [HttpDelete]
        public async Task<ActionResult<VatRate>> DeleteVatRates(int id)
        {
            var vatRateList = await _vatRateService.DeleteVatRates(id);
            return Ok(vatRateList);
        }
    }
}
