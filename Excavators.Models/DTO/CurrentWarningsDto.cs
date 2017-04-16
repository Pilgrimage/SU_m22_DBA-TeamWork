namespace Excavators.Models.DTO
{
    using System;

    public class CurrentWarningsDto
    {
        public string SensorName { get; set; }
        public double Current { get; set; }
        public DateTime TimeCollected { get; set; }
        public string Warning { get; set; }
    }
}
