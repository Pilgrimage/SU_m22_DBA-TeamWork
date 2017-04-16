namespace Excavators.Models.DTO
{
    using System;

    public class TempWarningsDto
    {
        public string SensorName { get; set; }
        public double Temperature { get; set; }
        public DateTime TimeCollected { get; set; }
        public string Warning { get; set; }
    }
}
