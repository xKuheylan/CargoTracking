public delegate void SpeedHandler(object sender, SpeedEventArgs e);

public class CargoVehicle
{
    public string Plaka { get; private set; } // Araç plakası
    public string Marka { get; set; }        // Araç markası
    private byte _speed;                     // Anlık hız
    public event SpeedHandler SpeedExceeded; // Hız aşımı olayı

    public byte Speed
    {
        get => _speed;
        set
        {
            _speed = value;
            if (_speed > 110) // Hız limiti kontrolü
            {
                // Rastgele konum bilgileri
                double latitude = 0;
                double longitude = new Random().NextDouble() * 1000000;

                // Olayı tetikle
                SpeedExceeded?.Invoke(this, new SpeedEventArgs(_speed, latitude, longitude));
            }
        }
    }

    public CargoVehicle(string plaka)
    {
        Plaka = plaka;
    }
}
