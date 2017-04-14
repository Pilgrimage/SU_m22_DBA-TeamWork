namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SpeedSensorType
    {
        public SpeedSensorType()
        {
          this.SpeedSensors = new HashSet<SpeedSensor>();  
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public float RangeMin { get; set; }
        public float RangeMax { get; set; }


        public virtual ICollection<SpeedSensor> SpeedSensors { get; set; }

    }
}
