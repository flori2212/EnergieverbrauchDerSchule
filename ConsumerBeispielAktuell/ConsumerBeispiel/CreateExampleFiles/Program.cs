using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumerBeispiel.Model;

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


            Guid dg1_guid = new Guid();
            Guid dg2_guid = new Guid();
            Guid d1_guid = new Guid();
            Guid d2_guid = new Guid();
            Guid dc1_guid = new Guid();
            Guid dc2_guid = new Guid();
            Guid r1_guid = new Guid();
            Guid r2_guid = new Guid();
            Guid ta1_guid = new Guid();
            Guid ta2_guid = new Guid();
            

            DeviceGroup dg1 = new DeviceGroup();
            dg1.ID = dg1_guid; dg1.Name = "Beleuchtung";
            DeviceGroup dg2 = new DeviceGroup();
            dg2.ID = dg2_guid; dg2.Name = "Technik";
            ConsumerBeispiel.Service.DataService.Instance.DeviceGroups.Add(dg1); ConsumerBeispiel.Service.DataService.Instance.DeviceGroups.Add(dg2);

            Device d1 = new Device();
            d1.Name = "Neonlampe"; d1.Power = 56; d1.Description = "-"; d1.ID = d1_guid; d1.DeviceGroupID = dg1_guid;
            Device d2 = new Device();
            d2.Name = "Lampe"; d2.Power = 30; d2.Description = "rund"; d2.ID = d2_guid; d2.DeviceGroupID = dg2_guid;
            ConsumerBeispiel.Service.DataService.Instance.Devices.Add(d1); ConsumerBeispiel.Service.DataService.Instance.Devices.Add(d2);

            DataCollector dc1 = new DataCollector();
            dc1.ID = dc1_guid; dc1.Names = "Nathan, Arhant"; dc1.Grade = "9b";
            DataCollector dc2 = new DataCollector();
            dc2.ID = dc2_guid; dc2.Names = "Lukas, Finn"; dc2.Grade = "9c";
            ConsumerBeispiel.Service.DataService.Instance.DataCollectors.Add(dc1); ConsumerBeispiel.Service.DataService.Instance.DataCollectors.Add(dc2);


            Room r1 = new Room();
            r1.ID = r1_guid; r1.Floor = "0"; r1.RoomNumber = "003";
            Room r2 = new Room();
            r2.ID = r2_guid; r2.Floor = "1"; r2.RoomNumber = "114";
            ConsumerBeispiel.Service.DataService.Instance.Rooms.Add(r1); ConsumerBeispiel.Service.DataService.Instance.Rooms.Add(r2);


            TimeArea ta1 = new TimeArea();
            ta1.ID = ta1_guid; ta1.Name = "Immer an"; ta1.PercentOfTheYeahr = 100; ta1.TimePerDayInMinutes = 500; ta1.ActiveDaysPerWeek = 7; ta1.ActiveInHolydays = true;
            TimeArea ta2 = new TimeArea();
            ta2.ID = ta2_guid; ta2.Name = "Nur an Schultagen"; ta2.PercentOfTheYeahr = 50; ta2.TimePerDayInMinutes = 500; ta2.ActiveDaysPerWeek = 5; ta2.ActiveInHolydays = false;
            ConsumerBeispiel.Service.DataService.Instance.TimeAreas.Add(ta1); ConsumerBeispiel.Service.DataService.Instance.TimeAreas.Add(ta2);


           

            for (int i = 0; i < 20; i++)
            {
                Random r = new Random();
                Consumer c = new Consumer();
                Guid c_guid = new Guid();
                c.ID = c_guid;
                c.RoomID = r2_guid;
                c.DeviceID = d1_guid;
                c.TimeAreaID = ta2_guid;
                c.DataCollectorID = dc1_guid;
                c.DeviceCount = r.Next(1, 10);
                ConsumerBeispiel.Service.DataService.Instance.Consumers.Add(c);
                Console.WriteLine("Durchgang 1: " + i + " (" + c_guid + ")");
                System.Threading.Thread.Sleep(100);
            }

            Console.WriteLine();

            for (int i = 0; i < 20; i++)
            {
                Random r = new Random();
                Consumer c = new Consumer();
                Guid c_guid = new Guid();
                c.ID = c_guid;
                c.RoomID = r2_guid;
                c.DeviceID = d2_guid;
                c.TimeAreaID = ta2_guid;
                c.DataCollectorID = dc2_guid;
                c.DeviceCount = r.Next(1, 10);
                ConsumerBeispiel.Service.DataService.Instance.Consumers.Add(c);
                Console.WriteLine("Durchgang 2: " + i + " (" + c_guid + ")");
                System.Threading.Thread.Sleep(100);
            }

            Console.WriteLine();

            for (int i = 0; i < 20; i++)
            {
                Random r = new Random();
                Consumer c = new Consumer();
                Guid c_guid = new Guid();
                c.ID = c_guid;
                c.RoomID = r1_guid;
                c.DeviceID = d2_guid;
                c.TimeAreaID = ta2_guid;
                c.DataCollectorID = dc2_guid;
                c.DeviceCount = r.Next(1, 10);
                ConsumerBeispiel.Service.DataService.Instance.Consumers.Add(c);
                Console.WriteLine("Durchgang 3: " + i + " (" + c_guid + ")");
                System.Threading.Thread.Sleep(100);
            }

            Console.WriteLine();



            ConsumerBeispiel.Service.DataService.Instance.SaveAllData();
        }

    }
}
