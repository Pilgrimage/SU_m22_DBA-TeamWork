namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VolumeSensorData
    {
        [Key]
        public int Id { get; set; }

        public float Volume { get; set; }   // Volume = m3/s

        public DateTime DTCollected { get; set; }

        public int VolumeSensorId { get; set; }
        public VolumeSensor VolumeSensor { get; set; }

    }
}
