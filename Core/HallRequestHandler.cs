using Hall.Controllers;
using Hall.Core.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hall.Core
{
     public class HallRequestHandler : IHallRequestHandler
     {
          private readonly ILogger<HallController> _logger;

          public HallRequestHandler(ILogger<HallController> logger)
          {
               _logger = logger;
          }

          public async Task<HttpResponseMessage> PostOrderToKitchen(HallOrder order)
          {
               var clientHandler = new HttpClientHandler
               {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
               };

               using var client = new HttpClient(clientHandler);
               var postTask = await client.PostAsJsonAsync("https://192.168.100.2:8081/api/kitchen/order", order);

               if (postTask.IsSuccessStatusCode)
               {
                    _logger.LogInformation(
                         $"Order with Id {order.OrderId} send to the kitchen by Waiter {order.WaiterId}.");
               }
               else
               {
                    _logger.LogInformation("Unable to send the order to kitchen " + postTask.StatusCode);
               }

               return postTask;
          }
     }
}