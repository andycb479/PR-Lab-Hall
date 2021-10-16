using System;
using System.Collections.Generic;
using System.Linq;

namespace Hall.Core.Models
{
     public class Table
     {
          public int Id { get; set; }
          public TableState State { get; set; }
          public HallOrder CurrentOrder { get; set; }
          public Table(int id)
          {
               Id = id;
               State = TableState.Free;
          }

          public HallOrder GetRandomOrder(int waiterId)
          {
               var foodDictionary = new FoodDictionary();
               var r = new Random();
               var order = new HallOrder()
               {
                    OrderId = Guid.NewGuid(),
                    TableId = Id,
                    Priority = r.Next(0, 5),
                    Items = new List<int>(r.Next(1, 5)),
                    WaiterId = waiterId,
                    CreatedAt = DateTime.UtcNow
               };
               for (var i = 0; i < order.Items.Capacity; i++)
               {
                    order.Items.Add(r.Next(1,10));
               }
               var maxPreparation = order.Items.Select(x => foodDictionary.GetFoodById(x).PreparationTime).Max();
               order.MaxWait = (int) Math.Ceiling(maxPreparation * 1.3);
               CurrentOrder = order;
               return order;

          }

          public void Reset()
          {
               State = TableState.Free;
               CurrentOrder = null;
          }
     }
}