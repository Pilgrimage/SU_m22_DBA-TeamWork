namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ShiftingSensor
    {
        public ShiftingSensor()
        {
            this.ShiftingSensorDatas = new HashSet<ShiftingSensorData>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int BeltId { get; set; }
        public virtual Belt Belt { get; set; }

        public virtual ICollection<ShiftingSensorData> ShiftingSensorDatas { get; set; }

    }
}
