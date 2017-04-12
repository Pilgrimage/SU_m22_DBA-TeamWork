namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CurrentSensorData
    {
        [Key]
        public int Id { get; set; }

        public float Current { get; set; }

        public DateTime DTCollected { get; set; }

        public int CurrentSensorId { get; set; }
        public CurrentSensor CurrentSensor { get; set; }

    }
}
