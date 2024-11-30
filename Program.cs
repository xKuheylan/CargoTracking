class Program
{
    static void Main(string[] args)
    {
        CargoVehicle vehicle1 = new CargoVehicle("42SU1975", "Ford");
        CargoVehicle vehicle2 = new CargoVehicle("06TR1923", "Mercedes");

        vehicle1.SpeedExceeded += Vehicle_SpeedExceeded;
        vehicle2.SpeedExceeded += Vehicle_SpeedExceeded;

        for (byte i = 80; i < 130; i += 5)
        {
            vehicle1.Speed = i;
            vehicle2.Speed = i + 8;

            Console.WriteLine($"{vehicle1.Plate} plakalı aracın hızı = {vehicle1.Speed}");
            Console.WriteLine($"{vehicle2.Plate} plakalı aracın hızı = {vehicle2.Speed}");
            Thread.Sleep(1000);
        }
    }

    private static void Vehicle_SpeedExceeded(object sender, SpeedEventArgs e)
    {
        Console.WriteLine($"{e.Plate} plakalı {e.Brand} marka kargo aracı hız limitini aştı.");
        Console.WriteLine($"Aracın hız limitini aştığı konum : {e.Latitude}° enlem ve {e.Longitude}° boylam");
        Console.WriteLine($"{e.Timestamp} anında aracın hızı = {e.Speed} olarak ölçüldü.");
        Console.WriteLine();
    }
}