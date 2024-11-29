using System;

namespace CargoTracking
{
    public delegate void SpeedHandler(CargoVehicle sender, SpeedExceededEventArgs e);

    public class CargoVehicle
    {
        public string Plaka { get; private set; }
        public string Marka { get; set; }
        private int _speed;

        public int Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                if (_speed > SpeedLimit)
                {
                    OnSpeedExceeded(new SpeedExceededEventArgs(0, GenerateRandomLongitude(), _speed));
                }
            }
        }

        public int SpeedLimit { get; set; } = 110;

        public event SpeedHandler SpeedExceeded;

        public CargoVehicle(string plaka, string marka)
        {
            Plaka = plaka;
            Marka = marka;
        }

        protected virtual void OnSpeedExceeded(SpeedExceededEventArgs e)
        {
            SpeedExceeded?.Invoke(this, e);
        }

        private double GenerateRandomLongitude()
        {
            Random rnd = new Random();
            return rnd.NextDouble() * 1000000;
        }
    }
}
