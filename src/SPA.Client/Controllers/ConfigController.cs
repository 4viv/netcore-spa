
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace SPA.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        
        private readonly IConfiguration _configuration;

        // Creamos variable de vercion para validar localStorage cada que se levante el proyecto generara una diferente
        private static readonly string AppVersion = "AppNetCoreVersion-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss");

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult index()
        {
            return Ok(
                    new {
                        ApiUrl = _configuration.GetValue<string>("ApiUrl")
                    }
                );
        }
        
        // Enviamos la variable de version
        [HttpGet("version")]
        public ActionResult getVersion()
        {
            return Ok(AppVersion );
        }
    }
}
