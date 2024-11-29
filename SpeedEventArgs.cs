using System;

namespace CargoTracking
{
    public class SpeedEventArgs : EventArgs
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Time { get; set; }
        public int CurrentSpeed { get; set; }

        public SpeedEventArgs(double latitude, double longitude, DateTime time, int speed)
        {
            this.Latitude = latitude;
            Longitude = longitude;
            Time = time;
            CurrentSpeed = speed;
        }
    }
}
