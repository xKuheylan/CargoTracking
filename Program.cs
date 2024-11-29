using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Araçların oluşturulması
        CargoVehicle kargo_aracı1 = new CargoVehicle("42SU1975") { Marka = "Ford" };
        CargoVehicle kargo_aracı2 = new CargoVehicle("06TR1923") { Marka = "Mercedes" };

        // Olaylara metod bağlama
        kargo_aracı1.SpeedExceeded += kargo_aracı_SpeedExceeded;
        kargo_aracı2.SpeedExceeded += kargo_aracı_SpeedExceeded;

        // Döngüyle hızların artırılması
        byte j = 8; // Ek hız faktörü
        for (byte i = 80; i < 130; i += 5)
        {
            kargo_aracı1.Speed = i; // İlk araç için hız ataması
            kargo_aracı2.Speed = (byte)(i + j); // İkinci araç için hız ataması

            // Hız bilgilerini yazdırma
            Console.WriteLine($"{kargo_aracı1.Plaka} plakalı aracın hızı = {kargo_aracı1.Speed}");
            Console.WriteLine($"{kargo_aracı2.Plaka} plakalı aracın hızı = {kargo_aracı2.Speed}");
            Console.WriteLine();

            Thread.Sleep(1000); // 1 saniye bekleme
        }
    }

    // Hız aşımı durumunda tetiklenecek metod
    static void kargo_aracı_SpeedExceeded(object sender, SpeedEventArgs e)
    {
        if (sender is CargoVehicle arac)
        {
            Console.WriteLine($"{arac.Plaka} plakalı {arac.Marka} marka kargo aracı hız limitini aştı.");
            Console.WriteLine($"Aracın hız limitini aştığı konum : {e.Latitude}° enlem ve {e.Longitude}° boylam");
            Console.WriteLine($"Aracın şu anki konumu : {e.Latitude}° enlem ve {e.Longitude + 200}° boylam");
            Console.WriteLine($"{e.Timestamp} anında aracın hızı = {e.Speed} olarak ölçüldü.");
        }
    }

}
