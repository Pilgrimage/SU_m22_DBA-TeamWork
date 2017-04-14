﻿namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TempSensorData
    {
        public TempSensorData()
        {
            DTCollected = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public float Temperature { get; set; }

        public DateTime DTCollected { get; set; }

        public int Status { get; set; }
        // 0 -> means nothing
        // 1 => checked succesfully, OK
        // 8 => High Temperature (compared with TempSensor.WarningHighTemp)
        // 16 => Emergency High Temperature (compared with TempSensor.WarningEmergencyHighTemp)
        // 64 => Sensor Failed (compared with TempSensorType.RangeMin and TempSensorType.RangeMax)


        public int TempSensorId { get; set; }
        public TempSensor TempSensor { get; set; }

    }
}