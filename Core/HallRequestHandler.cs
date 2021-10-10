using System;
using Hall.Controllers;
using Hall.Core.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;

namespace Hall.Core
{
     public class HallRequestHandler : IHallRequestHandler
     {
          private readonly ILogger<HallController> _logger;
          private readonly IMapper _mapper;
          public event EventHandler<ReturnOrder> OrderReceivedBack; 

          public HallRequestHandler(ILogger<HallController> logger, IMapper mapper)
          {
               _logger = logger;
               _mapper = mapper;
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
                         $"HallOrder with Id {order.OrderId} send to the kitchen by Waiter {order.WaiterId}.");
               }
               else
               {
                    _logger.LogInformation("Unable to send the order to kitchen " + postTask.StatusCode);
               }

               return postTask;
          }

          public virtual void OnOrderReceivedBack(KitchenReturnOrder kitchenReturnOrder)
          {
               _logger.LogInformation($"HallOrder with Id {kitchenReturnOrder.OrderId} received by the Hall back. ");
               var e = _mapper.Map<ReturnOrder>(kitchenReturnOrder);
               OrderReceivedBack?.Invoke(this,e);
          }
     }
}