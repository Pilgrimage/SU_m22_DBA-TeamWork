namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TensionSensorData
    {
        [Key]
        public int Id { get; set; }

        public double Tension { get; set; }

        public DateTime DTCollected { get; set; }

        public int Status { get; set; }
        // 0 -> means nothing
        // 1 => checked succesfully, OK
        // 2 => Low Tension (compared with TensionSensor.WarningLowTension)
        // 8 => High Tension (compared with TensionSensor.WarningHighTension)
        // 16 => Emergency High Tension (compared with TensionSensor.WarningEmergencyHighTension)
        // 64 => Sensor Failed (compared with TensionSensorType.RangeMin and TensionSensorType.RangeMax)


        public int TensionSensorId { get; set; }
        public virtual TensionSensor TensionSensor { get; set; }

    }
}
