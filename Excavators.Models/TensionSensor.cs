namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TensionSensor
    {
        public TensionSensor()
        {
            this.TensionSensorDatas = new HashSet<TensionSensorData>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int TensionSensorTypeId { get; set; }
        public TensionSensorType TensionSensorType { get; set; }
        
        [StringLength(250)]
        public string Description { get; set; }

        public float? WarningLowTension { get; set; }
        public float? WarningHighTension { get; set; }
        public float? WarningEmergencyHighTension { get; set; }


        public int BeltId { get; set; }
        public virtual Belt Belt { get; set; }

        public virtual ICollection<TensionSensorData> TensionSensorDatas { get; set; }

    }
}
