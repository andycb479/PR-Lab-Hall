using System.Net.Http;
using System.Threading.Tasks;
using Hall.Core.Models;

namespace Hall.Core
{
     public interface IHallRequestHandler
     {
          Task<HttpResponseMessage> PostOrderToKitchen(HallOrder order);

     }
}