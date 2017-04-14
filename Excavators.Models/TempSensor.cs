namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TempSensor
    {
        public TempSensor()
        {
            this.TempSensorDatas = new HashSet<TempSensorData>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int TempSensorTypeId { get; set; }
        public TempSensorType TempSensorType { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public float? WarningHighTemp { get; set; }
        public float? WarningEmergencyHighTemp { get; set; }

        public int? DrumId { get; set; }
        public virtual Drum Drum { get; set; }

        public int? MotorId { get; set; }
        public virtual Motor Motor { get; set; }

        public int? ReducerId { get; set; }
        public virtual Reducer Reducer { get; set; }

        public virtual ICollection<TempSensorData> TempSensorDatas { get; set; }

    }
}
