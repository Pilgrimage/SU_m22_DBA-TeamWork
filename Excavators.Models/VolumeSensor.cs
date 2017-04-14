namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class VolumeSensor
    {
        public VolumeSensor()
        {
            this.VolumeSensorDatas = new HashSet<VolumeSensorData>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        public int VolumeSensorTypeId { get; set; }
        public VolumeSensorType VolumeSensorType { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public int BeltId { get; set; }
        public virtual Belt Belt { get; set; }


        public virtual ICollection<VolumeSensorData> VolumeSensorDatas { get; set; }
    }
}
