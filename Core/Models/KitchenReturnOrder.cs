using System.Collections.Generic;

namespace Hall.Core.Models
{
     public class KitchenReturnOrder : HallOrder
     {
          public int CookingTime { get; set; }
          public List<CookingDetails> CookingDetails { get; set; }
     }
}