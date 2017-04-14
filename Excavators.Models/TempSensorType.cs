namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TempSensorType
    {
        public TempSensorType()
        {
            this.TempSensors = new HashSet<TempSensor>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(250)]
        public string Description { get; set; }


        public float RangeMin { get; set; }
        public float RangeMax { get; set; }


        public virtual ICollection<TempSensor> TempSensors { get; set; }
    }
}
