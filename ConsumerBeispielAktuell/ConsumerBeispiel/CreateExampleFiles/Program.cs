using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateExampleFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateConsumers();
        }


        static void CreateConsumers()
        {
            ConsumerBeispiel.Service.DataService.Instance.XmlFolderPath = @"C:\Users\flori\Desktop\ExampleFiles";
            ConsumerBeispiel.Service.DataService.Instance.Initialize();
            for (int i = 0; i < 100; i++)
            {
                Random r = new Random();
                ConsumerBeispiel.Model.Consumer c = new ConsumerBeispiel.Model.Consumer();
                c.ID = new Guid();
                c.RoomID = new Guid("qwertzuiopasdfghjklqwertzuiop");
                c.DeviceID = new Guid("qwertzuiopasdfghjklqwertzuiop");
                c.TimeAreaID = new Guid("qwertzuiopasdfghjklqwertzuiop");
                c.DataCollectorID = new Guid("qwertzuiopasdfghjklqwertzuiop");
                c.DeviceCount = r.Next(1, 10);
                ConsumerBeispiel.Service.DataService.Instance.Consumers.Add(c);
            }
            ConsumerBeispiel.Service.DataService.Instance.SaveConsumers();
        }

    }
}
