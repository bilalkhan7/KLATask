using Microsoft.AspNetCore.Mvc;
using KLATaskApp.Server.Models; 

namespace KLATaskApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyConverterController : ControllerBase
    {
        [HttpPost]
        public IActionResult ConvertCurrency([FromBody] CurrencyConversionRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.Amount))
                {
                    return BadRequest("The 'amount' field is required.");
                }

                string result = CurrencyConverter.ConvertToWords(request.Amount);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
