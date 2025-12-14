using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IntegrationServices.DTOs;
using IntegrationServices.services;
namespace IntegrationServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly InvoiceServices _invoiceServices;

        public InvoiceController(ILogger<InvoiceController> logger, InvoiceServices invoiceServices)
        {
            _logger = logger;
            _invoiceServices = invoiceServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceRequestDto request)
        {
            try
            {
                var newInvoice = await _invoiceServices.CreateInvoice(request);
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