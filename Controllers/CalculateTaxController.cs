using congestiontaxapi.models;
using congestiontaxapi.services;
using Microsoft.AspNetCore.Mvc;
namespace congestiontaxapi.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculateTaxController : ControllerBase
{
    private readonly ILogger<CalculateTaxController> _logger;
    private readonly ICalculatorService _calculatorService;

    public CalculateTaxController(ILogger<CalculateTaxController> logger, ICalculatorService calculatorService)
    {
        _logger = logger;
        _calculatorService = calculatorService;
    }

    [HttpPost(Name = "CalculateTax")]
    public decimal Post(TaxCalculationRequest request)
    {
       return _calculatorService.CalculateTax(request.VehicleType, request.DateTimes);
    }
}
