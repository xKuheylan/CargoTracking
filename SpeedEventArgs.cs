public class SpeedEventArgs : EventArgs
{
    public string Plate { get; set; }
    public string Brand { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Speed { get; set; }
    public DateTime Timestamp { get; set; }
}