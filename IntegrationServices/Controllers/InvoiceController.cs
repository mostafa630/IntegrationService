using Microsoft.AspNetCore.Mvc;
using IntegrationServices.DTOs;
using IntegrationServices.services;
namespace IntegrationServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateInvoice([FromBody] CreateInvoiceRequestDto request)
        {
            try
            {
                var newInvoice = InvoiceServices.CreateInvoice(request);
                return Ok(new { Message = "Invoice created successfully", InvoiceId = newInvoice.GetInvoiceId() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating invoice");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}