namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CurrentSensor
    {
        public CurrentSensor()
        {
            this.CurrentSensorDatas = new HashSet<CurrentSensorData>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
        // Current of the Motor - Phase 2

        public int CurrentSensorTypeId { get; set; }
        public virtual CurrentSensorType CurrentSensorType { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public double WarningHighCurrent { get; set; }
        public double WarningEmergencyHighCurrent { get; set; }


        [Required]
        public int MRGroupId { get; set; }
        public virtual MRGroup MRGroup { get; set; }

        public virtual ICollection<CurrentSensorData> CurrentSensorDatas { get; set; }

    }
}
