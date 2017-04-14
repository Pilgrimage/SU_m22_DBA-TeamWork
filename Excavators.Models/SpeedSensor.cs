﻿namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class SpeedSensor
    {
        public SpeedSensor()
        {
            this.SpeedSensorDatas = new HashSet<SpeedSensorData>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int SpeedSensorTypeId { get; set; }
        public SpeedSensorType SppedSensorType { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public float? WarningLowSpeed { get; set; }  
        public float? WarningHighSpeed { get; set; }

        public int DrumId { get; set; }
        public virtual Drum Drum { get; set; }

        public virtual ICollection<SpeedSensorData> SpeedSensorDatas { get; set; }
    }
}