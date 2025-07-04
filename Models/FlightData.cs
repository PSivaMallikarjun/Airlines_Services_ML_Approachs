
namespace Airlines_Services_ML_Approachs.Models
{
    public class FlightData
    {
        public string ? Origin { get; set; }
        public string ? Destination { get; set; }
        public float TemperatureC { get; set; }
        public float WindSpeedKph { get; set; }
        public float ScheduledDepartureHour { get; set; }
        public float DelayMinutes { get; set; }
    }

    public class FlightPrediction
    {
        public float Score { get; set; }
    }
}
