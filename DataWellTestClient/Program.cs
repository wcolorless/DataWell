using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DataWellCore.core.Client;
using DataWellCore.core.Protocol;

namespace DataWellTestClient
{
    class Program
    {
        private static readonly List<string> ids = new List<string>(){"1", "2", "3", "4", "5", "6", "7"};
        private static readonly List<string> Names = new List<string>() { "Name1", "Name2", "Name3", "Name4", "Name5", "Name5", "Name6" };
        private static readonly List<int> Nums = new List<int>() { 1, 2, 3, 4, 5, 5, 6 };
        static async Task Main(string[] args)
        {
            Thread.Sleep(1000);
            Console.WriteLine("DataWell Test Client Starting");
            var client = new DataWellClient("localhost", "10080", TransportTypes.WebSocket);
            InitCollections(client);
            for (var i = 0; i < ids.Count; i++)
            {
                try
                {
                    var workItem = new WorkItem()
                    {
                        Name = Names[i],
                        Time = DateTime.UtcNow,
                        DWID = ids[i],
                        Num = Nums[i]
                    };
                    client.Save("WorkItem", workItem);
                }
                catch (Exception e)
                {
                    throw new Exception($"Test App Save Error: {e.Message}");
                }
            }
            var getObj = await client.GetItem<WorkItem>("WorkItem", "1");
            var objs = await client.GetAll<WorkItem>("WorkItem");
            var filteredEqual = client.Filter("WorkItem").Equal("Num", 5).Go<WorkItem>();
            var filteredNotEqual = client.Filter("WorkItem").NotEqual("Num", 1).Go<WorkItem>();
            var filteredGreater = client.Filter("WorkItem").Greater("Num", 4).Go<WorkItem>();
            var filteredGreaterOrEqual = client.Filter("WorkItem").GreaterOrEqual("Num", 4).Go<WorkItem>();
            var filteredLess = client.Filter("WorkItem").Less("Num", 4).Go<WorkItem>();
            var filteredLessOrEqual = client.Filter("WorkItem").LessOrEqual("Num", 4).Go<WorkItem>();
            var filteredEqualName = client.Filter("WorkItem").Equal("Name", "Name3").Go<WorkItem>();
            var filteredGreaterOrEqualAndLessOrEqual = client.Filter("WorkItem")
                .GreaterOrEqual("Num", 3)
                .LessOrEqual("Num", 5)
                .Go<WorkItem>();
            client.Remove("WorkItem", "5");
            var filteredEqualAfterRemoving = client.Filter("WorkItem").Equal("Num", 5).Go<WorkItem>();
            
            var updatedItem = new WorkItem()
            {
                Name = "NewName",
                Time = DateTime.UtcNow,
                DWID = ids[4],
                Num = 555
            };
            client.Update("WorkItem", updatedItem);

            var allObjects = await client.GetAll<WorkItem>("WorkItem");

            // Get Info About collection and memory usage
            var info = client.GetInfo();

            var pack = new List<object>();
            for (var i = 0; i < 100; i++)
            {
                pack.Add(new WorkItem()
                {
                    Name = Guid.NewGuid().ToString(),
                    Num = 1,
                    Time = DateTime.Now
                });
            }
            client.SavePack("WorkItem", pack);

            var allAfterSavePack = await client.GetAll<WorkItem>("WorkItem");
            client.RemoveCollection("WorkItem");
            Console.WriteLine("DataWell Test Client End");
            Console.ReadLine();
        }

        private static void InitCollections(IDWClient client)
        {
           var addWorkItemResult = client.AddCollection("WorkItem", new WorkItem());
           if (!addWorkItemResult)
           {
               throw new Exception("Init collection error");
           }
        }
    }
}
