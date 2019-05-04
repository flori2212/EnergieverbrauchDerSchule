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
            ConsumerBeispiel.Service.DataService.Instance.Inistalize();
            for (int i = 0; i < 100; i++)
            {
                Random r = new Random();
                ConsumerBeispiel.Model.Consumer c = new ConsumerBeispiel.Model.Consumer();
                c.ID = i + 1;
                c.RoomID = r.Next(1, 5);
                c.DeviceID = r.Next(1, 5);
                c.TimeAreaID = r.Next(1, 3);
                c.DataCollectorID = r.Next(1, 3);
                c.DeviceCount = r.Next(1, 10);
                ConsumerBeispiel.Service.DataService.Instance.Consumers.Add(c);
            }
            ConsumerBeispiel.Service.DataService.Instance.SaveConsumers();
        }

    }
}
