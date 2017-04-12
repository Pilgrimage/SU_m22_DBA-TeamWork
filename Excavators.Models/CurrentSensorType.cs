namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CurrentSensorType
    {
        public CurrentSensorType()
        {
            this.CurrentSensors = new HashSet<CurrentSensor>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public float RangeMin { get; set; }
        public float RangeMax { get; set; }


        public virtual ICollection<CurrentSensor> CurrentSensors { get; set; }

    }
}
