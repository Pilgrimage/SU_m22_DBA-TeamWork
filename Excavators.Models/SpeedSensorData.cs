namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SpeedSensorData
    {
        [Key]
        public int Id { get; set; }

        public float Speed { get; set; }    // in meters/sec

        public DateTime DTCollected { get; set; }

        public int SpeedSensorId { get; set; }
        public SpeedSensor SpeedSensor { get; set; }
    }   
}
