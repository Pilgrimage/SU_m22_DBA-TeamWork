namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Drum
    {
        public Drum()
        {
            this.MRGroups = new HashSet<MRGroup>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(50)]
        public string Type { get; set; }

        public int BeltId { get; set; }
        public virtual Belt Belt { get; set; }

        public virtual ICollection<MRGroup> MRGroups { get; set; }
    }
}
