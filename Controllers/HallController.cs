using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hall.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class HallController : ControllerBase
     {
          [HttpGet]
          public async Task<ActionResult<string>> GetActionResult()
          {
               return "Hello world";
          }
     }
}
