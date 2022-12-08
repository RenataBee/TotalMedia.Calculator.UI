namespace TotalMedia.Calculator.WebApi.Models
{
    public class VatRate
    {
        public int Id { get; set; }
        public string TypeOfVatRates { get; set; } = string.Empty;
        public Double Percentual { get; set; }

        public int CountryId { get; set; }
    }
}
