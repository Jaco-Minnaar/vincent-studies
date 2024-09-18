using Calculator;
using Calculator.Model;
using Microsoft.AspNetCore.Mvc;

namespace calculator.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;
    private readonly CalculatorService _calculatorService;

    public CalculatorController(
        ILogger<CalculatorController> logger,
        CalculatorService calculatorService
    )
    {
        _logger = logger;
        _calculatorService = calculatorService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Entry entry)
    {
        int? result = entry.Operator switch
        {
            "+" => _calculatorService.OnPlusPressed(entry.Lhs, entry.Rhs),
            "-" => _calculatorService.OnMinusPressed(entry.Lhs, entry.Rhs),
            "*" => _calculatorService.OnMultiplyPressed(entry.Lhs, entry.Rhs),
            "/" => _calculatorService.OnDividePressed(entry.Lhs, entry.Rhs),
            _ => null
        };

        if (!result.HasValue)
        {
            return BadRequest(new { Message = "Invalid operator" });
        }

        return Ok(new { Result = result });
    }
}
