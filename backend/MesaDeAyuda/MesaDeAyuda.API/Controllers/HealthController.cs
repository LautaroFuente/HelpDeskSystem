using Microsoft.AspNetCore.Mvc;

namespace MesaDeAyuda.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API funcionando correctamente.");
        }
    }
}
