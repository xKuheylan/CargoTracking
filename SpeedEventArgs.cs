public class SpeedEventArgs : EventArgs
{
    public byte Speed { get; set; }          // Hız bilgisi
    public double Latitude { get; set; }    // Enlem
    public double Longitude { get; set; }   // Boylam
    public DateTime Timestamp { get; set; } // Zaman bilgisi

    public SpeedEventArgs(byte speed, double latitude, double longitude)
    {
        Speed = speed;
        Latitude = latitude;
        Longitude = longitude;
        Timestamp = DateTime.Now;
    }
}
