using System;
using System.Threading;

namespace CargoTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Araçların oluşturulması
            CargoVehicle kargo_aracı1 = new CargoVehicle("42SU1975", "Ford");
            CargoVehicle kargo_aracı2 = new CargoVehicle("06TR1923", "Mercedes");

            // Hız aşımı olaylarının tanımlanması
            kargo_aracı1.SpeedExceeded += KargoAracı_SpeedExceeded;
            kargo_aracı2.SpeedExceeded += KargoAracı_SpeedExceeded;

            // Rastgele hız oluşturucu
            Random random = new Random();

            Console.WriteLine("Rastgele hız değerleri ile hız güncellemeleri başlıyor. Çıkmak için CTRL+C");

            // Hız güncellemeleri
            while (true)
            {
                int newSpeed1 = random.Next(70, 151); // 70 ile 150 arasında rastgele hız
                int newSpeed2 = random.Next(70, 151);

                kargo_aracı1.Speed = newSpeed1;
                kargo_aracı2.Speed = newSpeed2;

                Console.WriteLine($"{kargo_aracı1.Plaka} plakalı aracın hızı = {kargo_aracı1.Speed}");
                Console.WriteLine($"{kargo_aracı2.Plaka} plakalı aracın hızı = {kargo_aracı2.Speed}");

                Thread.Sleep(1000); // 1 saniye bekleme
            }
        }

        private static void KargoAracı_SpeedExceeded(CargoVehicle sender, SpeedEventArgs e)
        {
            Console.WriteLine($"\n{sender.Plaka} plakalı {sender.Marka} marka kargo aracı hız limitini aşmıştır.");
            Console.WriteLine($"Aracın hız limitini aştığı konum : {e.Latitude}° enlem ve {e.Longitude}° boylamdır.");
            Console.WriteLine($"Aracın şu anki konumu : {e.Latitude}° enlem ve {e.Longitude + 100}° boylamdır.");
            Console.WriteLine($"{e.Time} anında aracın hızı = {e.CurrentSpeed} olarak ölçülmüştür.");
        }
    }
}
