using System;
using System.Net.Http;
using System.Threading.Tasks;
using Hall.Core.Models;

namespace Hall.Core
{
     public interface IHallRequestHandler
     {
          event EventHandler<ReturnOrder> OrderReceivedBack;
          Task<HttpResponseMessage> PostOrderToKitchen(HallOrder order);
          void OnOrderReceivedBack(KitchenReturnOrder kitchenReturnOrder);

     }
}