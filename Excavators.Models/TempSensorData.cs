namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TempSensorData
    {
        [Key]
        public int Id { get; set; }

        public double Temperature { get; set; }

        public DateTime DTCollected { get; set; }

        public int Status { get; set; }
        // 0 -> means nothing
        // 1 => checked succesfully, OK
        // 8 => High Temperature (compared with TempSensor.WarningHighTemp)
        // 16 => Emergency High Temperature (compared with TempSensor.WarningEmergencyHighTemp)
        // 64 => Sensor Failed (compared with TempSensorType.RangeMin and TempSensorType.RangeMax)


        public int TempSensorId { get; set; }
        public virtual TempSensor TempSensor { get; set; }

    }
}
