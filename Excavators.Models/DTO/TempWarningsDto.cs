namespace Excavators.Models.DTO
{
    using System;

    public class TempWarningsDto
    {
        public string SensorName { get; set; }
        public string Temperature { get; set; }
        public string TimeCollected { get; set; }
        public string Warning { get; set; }
    }
}
