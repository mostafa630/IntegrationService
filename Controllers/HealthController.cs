using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IntegrationServices.Controllers
{
    [Route("[controller]")]
    public class HealthController : Controller
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public string GetHealthStatus()
        {
            return "Service is running...";
        }
    }
}