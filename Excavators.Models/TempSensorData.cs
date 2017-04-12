namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TempSensorData
    {
        [Key]
        public int Id { get; set; }

        public float Temperature { get; set; }

        public DateTime DTCollected { get; set; }

        public int TempSensorId { get; set; }
        public TempSensor TempSensor { get; set; }

    }
}
