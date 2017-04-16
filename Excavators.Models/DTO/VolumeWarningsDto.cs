namespace Excavators.Models.DTO
{
    using System;

    class VolumeWarningsDto
    {
        public string SensorName { get; set; }
        public double Volume { get; set; }
        public DateTime TimeCollected { get; set; }
        public string Warning { get; set; }
    }
}
