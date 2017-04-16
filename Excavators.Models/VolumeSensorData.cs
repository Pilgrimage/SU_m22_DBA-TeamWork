namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VolumeSensorData
    {

        [Key]
        public int Id { get; set; }

        public double Volume { get; set; }   // Volume = m3/s

        public DateTime DTCollected { get; set; }

        public int Status { get; set; }
        // 0 -> means nothing
        // 1 => checked succesfully, OK
        // 64 => Sensor Failed (compared with VolumeSensorType.RangeMin and VolumeSensorType.RangeMax)

        public int VolumeSensorId { get; set; }
        public VolumeSensor VolumeSensor { get; set; }

    }
}
