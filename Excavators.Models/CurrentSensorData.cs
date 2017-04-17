namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CurrentSensorData
    {

        [Key]
        public int Id { get; set; }

        public double Current { get; set; }

        public DateTime DTCollected { get; set; }

        public int Status { get; set; }
        // 0 -> means nothing
        // 1 => checked succesfully, OK
        // 8 => High Current (compared with CurrentSensor.WarningHighCurret)
        // 16 => Emergency High Current (compared with CurrentSensor.WarningEmergencyHighCurret)
        // 64 => Sensor Failed (compared with CurrentSensorType.RangeMin and CurrentSensorType.RangeMax)

        public int CurrentSensorId { get; set; }
        public virtual CurrentSensor CurrentSensor { get; set; }

    }
}
