using System.Collections.Generic;

namespace Hall.Core.Models
{
     public class RestaurantScore
     {
          public int ReceivedOrdersCount { get; set; }
          public List<int> Ratings { get; set; }
     }
}