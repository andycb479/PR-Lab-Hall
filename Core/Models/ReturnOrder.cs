using System;
using System.Collections.Generic;

namespace Hall.Core.Models
{
     public class ReturnOrder : EventArgs
     {
          public Guid OrderId { get; set; }
          public int TableId { get; set; }
          public List<int> Items { get; set; }
          public DateTime CreatedAt { get; set; }
          public int WaiterId { get; set; }
          public List<CookingDetails> CookingDetails { get; set; }

     }
}