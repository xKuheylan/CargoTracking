using System;
using System.Threading;

namespace CargoTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            CargoVehicle kargo_aracı1 = new CargoVehicle("42SU1975", "Ford");
            CargoVehicle kargo_aracı2 = new CargoVehicle("06TR1923", "Mercedes");

            kargo_aracı1.SpeedExceeded += Kargo_Aracı_SpeedExceeded;
            kargo_aracı2.SpeedExceeded += Kargo_Aracı_SpeedExceeded;

            for (byte i = 80; i < 130; i += 5)
            {
                kargo_aracı1.Speed = i;
                kargo_aracı2.Speed = i + 8;

                Console.WriteLine($"{kargo_aracı1.Plaka} plakalı aracın hızı = {kargo_aracı1.Speed}");
                Console.WriteLine($"{kargo_aracı2.Plaka} plakalı aracın hızı = {kargo_aracı2.Speed}");
                Thread.Sleep(1000);
            }
        }

        static void Kargo_Aracı_SpeedExceeded(CargoVehicle sender, SpeedExceededEventArgs e)
        {
            Console.WriteLine($"{sender.Plaka} plakalı {sender.Marka} marka kargo aracı hız limitini aştı.");
            Console.WriteLine($"Aracın hız limitini aştığı konum : 0° enlem ve {e.Longitude:F4}° boylam");
            Console.WriteLine($"31.10.2020 {e.Timestamp:HH:mm:ss} anında aracın hızı = {e.Speed} olarak ölçüldü.");
        }
    }
}
