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

        [StringLength(250)]
        public string Description { get; set; }

        public double RangeMin { get; set; }
        public double RangeMax { get; set; }


        public virtual ICollection<SpeedSensor> SpeedSensors { get; set; }

    }
}
