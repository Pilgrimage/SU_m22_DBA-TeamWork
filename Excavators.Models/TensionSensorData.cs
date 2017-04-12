namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TensionSensorData
    {
        [Key]
        public int Id { get; set; }

        public float Tension { get; set; }

        public DateTime DTCollected { get; set; }

        public int TensionSensorId { get; set; }
        public TensionSensor TensionSensor { get; set; }

    }
}
