using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Hall.Core;
using Hall.Core.Models;

namespace Hall.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class HallController : ControllerBase
     {
          private readonly IHttpClientFactory _clientFactory;
          private readonly ILogger<HallController> _logger;
          private readonly IHallRequestHandler _hallRequestHandler;

          public HallController(IHttpClientFactory clientFactory, ILogger<HallController> logger, IHallRequestHandler hallRequestHandler)
          {
               _clientFactory = clientFactory;
               _logger = logger;
               _hallRequestHandler = hallRequestHandler;
          }

          [HttpPost("distribution")]
          public async Task<ActionResult<string>> GetRequest([FromBody] KitchenOrder kitchenOrder)
          {
               _logger.LogInformation($"Order with Id {kitchenOrder.OrderId} received by the Hall back. ");

               return Ok();
          }
     }

     public class Message
     {
          public string Text { get; set; }

     }
}
