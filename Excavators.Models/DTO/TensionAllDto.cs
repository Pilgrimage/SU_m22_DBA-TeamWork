namespace Excavators.Models.DTO
{
    using System;

    public class TensionAllDto
    {
        public string SensorName { get; set; }
        public double Tension { get; set; }
        public DateTime TimeCollected { get; set; }
    }
}
