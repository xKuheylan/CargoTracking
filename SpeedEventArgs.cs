using System;

namespace CargoTracking
{
    public class SpeedExceededEventArgs : EventArgs
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
        public int Speed { get; set; }

        public SpeedExceededEventArgs(double latitude, double longitude, int speed)
        {
            Latitude = latitude;
            Longitude = longitude;
            Timestamp = DateTime.Now;
            Speed = speed;
        }
    }
}
