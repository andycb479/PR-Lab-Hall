using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Hall.Controllers;
using Hall.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hall.Core
{
     public class HallCore
     {
          private readonly ILogger<HallController> _logger;
          private readonly IHallRequestHandler _hallRequestHandler;
          public readonly int TIME_UNIT;
          private static Mutex mut = new();
          private System.Timers.Timer aTimer;

          public BlockingCollection<Table> tables;


          public HallCore(ILogger<HallController> logger, IHallRequestHandler hallRequestHandler, IConfiguration configuration)
          {
               _logger = logger;
               _hallRequestHandler = hallRequestHandler;

               tables = new BlockingCollection<Table>();

               var numberOfTables = int.Parse(configuration["Tables"]);
               var numberOfWaiters = int.Parse(configuration["Waiters"]);
               TIME_UNIT = int.Parse(configuration["TIME_UNIT"]);


               for (int i = 1; i < numberOfTables + 1; i++)
               {
                    tables.Add(new Table(i));
               }

               aTimer = new System.Timers.Timer(2 * TIME_UNIT);
               aTimer.Elapsed += ChangeRandomTableState;
               aTimer.AutoReset = true;
               aTimer.Enabled = true;

               for (int i = 1; i < numberOfWaiters + 1; i++)
               {
                    Task.Factory.StartNew(() => { ProcessTables(i); });
               }

          }

          private void ChangeRandomTableState(object sender, ElapsedEventArgs e)
          {
               var r = new Random();
               (sender as System.Timers.Timer).Interval = r.Next(1, 10) * TIME_UNIT;

               mut.WaitOne();

               var index = r.Next(1, tables.Count + 1);

               foreach (var table in tables)
               {
                    if (table.Id == index && table.State == TableState.Free)
                    {
                         table.State = TableState.Ready;
                         _logger.LogInformation($"Table with Id {table.Id} is ready!");

                    }
               }

               mut.ReleaseMutex();
          }

          public void ProcessTables(int waiterId)
          {
               var r = new Random();
               while (true)
               {
                    mut.WaitOne();

                    foreach (var table in tables)
                         if (table.State == TableState.Ready)
                         {
                              table.State = TableState.Processing;

                              Thread.Sleep(r.Next(2 * TIME_UNIT, 4 * TIME_UNIT));

                              var order = table.GetRandomOrder(waiterId);

                              _logger.LogInformation($"Table with Id {table.Id} made order and is waiting.");
                              _logger.LogInformation(JsonSerializer.Serialize(order) + "\n");
                              _hallRequestHandler.PostOrderToKitchen(order);

                              table.State = TableState.Waiting;
                         }

                    mut.ReleaseMutex();
               }
          }
     }
}
