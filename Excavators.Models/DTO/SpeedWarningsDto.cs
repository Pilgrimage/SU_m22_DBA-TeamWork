namespace Excavators.Models.DTO
{
    using System;

    public class SpeedWarningsDto
    {
        public string SensorName { get; set; }
        public double Speed { get; set; }
        public DateTime TimeCollected { get; set; }
        public string Warning { get; set; }
    }
}
