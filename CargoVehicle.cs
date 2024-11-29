using System;

namespace CargoTracking
{
    public delegate void SpeedHandler(CargoVehicle sender, SpeedEventArgs e);

    public class CargoVehicle
    {
        private int _speed;
        private const int SpeedLimit = 110;

        public string Plaka { get; private set; }
        public string Marka { get; private set; }
        public int Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                if (_speed > SpeedLimit)
                {
                    OnSpeedExceeded(new SpeedEventArgs(
                        GetRandomLatitude(),
                        GetRandomLongitude(),
                        DateTime.Now,
                        _speed));
                }
            }
        }

        public event SpeedHandler SpeedExceeded;

        public CargoVehicle(string plaka, string marka)
        {
            Plaka = plaka;
            Marka = marka;
        }

        protected virtual void OnSpeedExceeded(SpeedEventArgs e)
        {
            SpeedExceeded?.Invoke(this, e);
        }

        private static double GetRandomLatitude() => 0.0;
        private static double GetRandomLongitude() => new Random().NextDouble() * 1000000;
    }
}
