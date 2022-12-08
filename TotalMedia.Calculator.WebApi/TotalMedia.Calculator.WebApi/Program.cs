using Microsoft.EntityFrameworkCore;
using TotalMedia.Calculator.WebApi.Data;
using TotalMedia.Calculator.WebApi.IRepository;
using TotalMedia.Calculator.WebApi.IService;
using TotalMedia.Calculator.WebApi.Repository;
using TotalMedia.Calculator.WebApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(name: "CalculatorOrigins" , 
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }
    ));

//Services
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IVatRateService, VatRateService>();

//Repositories
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IVatRatesRepository, VatRateRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CalculatorOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
