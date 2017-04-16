namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SpeedSensorData
    {
        [Key]
        public int Id { get; set; }

        public double Speed { get; set; }    // in meters/sec

        public DateTime DTCollected { get; set; }

        public int Status { get; set; }
        // 0 -> means nothing
        // 1 => checked succesfully, OK
        // 2 => Low Speed (compared with SpeedSensor.WarningLowSpeed)
        // 8 => High Speed (compared with SpeedSensor.WarningHighSpeed)
        // 32 => Slip (difference more then 10%)
        // 64 => Sensor Failed (compared with SpeedSensorType.RangeMin and SpeedSensorType.RangeMax)

        public int SpeedSensorId { get; set; }
        public SpeedSensor SpeedSensor { get; set; }
    }   
}
