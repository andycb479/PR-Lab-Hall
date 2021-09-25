using System;
using System.Collections.Generic;

namespace Hall.Core.Models
{
     public class Order
     {
          public Guid OrderId { get; set; }
          public int TableId { get; set; }
          public List<int> Items { get; set; }
          public int Priority { get; set; }
          public int MaxWait { get; set; }
          public DateTime CreatedAt { get; set; }
     }
}