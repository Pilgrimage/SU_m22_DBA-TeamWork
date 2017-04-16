namespace Excavators.Models.DTO
{
    using System;

    class TensionWarningsDto
    {
        public string SensorName { get; set; }
        public double Tension { get; set; }
        public DateTime TimeCollected { get; set; }
        public string Warning { get; set; }
    }
}
