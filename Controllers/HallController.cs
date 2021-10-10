using Hall.Core;
using Hall.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Hall.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class HallController : ControllerBase
     {
          private readonly ILogger<HallController> _logger;
          private readonly IHallRequestHandler _hallRequestHandler;

          public HallController(ILogger<HallController> logger, IHallRequestHandler hallRequestHandler)
          {
               _logger = logger;
               _hallRequestHandler = hallRequestHandler;
          }

          [HttpPost("distribution")]
          public async Task<ActionResult<string>> GetReadyOrder([FromBody] KitchenReturnOrder kitchenReturnOrder)
          {
               _hallRequestHandler.OnOrderReceivedBack(kitchenReturnOrder);
               return Ok();
          }
     }
}
