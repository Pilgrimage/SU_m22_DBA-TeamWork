namespace Excavators.Models.DTO
{
    using System;

    public class CurrentAllDto
    {
        public string SensorName { get; set; }
        public double Current { get; set; }
        public DateTime TimeCollected { get; set; }
    }
}
