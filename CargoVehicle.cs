// Delegate tanımı
public delegate void SpeedHandler(object sender, SpeedEventArgs e);

// CargoVehicle sınıfı
public class CargoVehicle
{
    private int _speed;
    private const int SpeedLimit = 110;

    public string Plate { get; }
    public string Brand { get; }

    // Event tanımı
    public event SpeedHandler SpeedExceeded;

    public int Speed
    {
        get => _speed;
        set {
            _speed = value;
            if (_speed > SpeedLimit)
            {
                OnSpeedExceeded(new SpeedEventArgs
                {
                    Plate = Plate,
                    Brand = Brand,
                    Latitude = GenerateRandomCoordinate(),
                    Longitude = GenerateRandomCoordinate(),
                    Speed = _speed,
                    Timestamp = DateTime.Now
                });
            }
        }
    }

    public CargoVehicle(string plate, string brand)
    {
        Plate = plate;
        Brand = brand;
    }

    protected virtual void OnSpeedExceeded(SpeedEventArgs e)
    {
        SpeedExceeded?.Invoke(this, e);
    }

    private double GenerateRandomCoordinate()
    {
        Random rand = new Random();
        return rand.Next(0, 1000000) + rand.NextDouble();
    }
}