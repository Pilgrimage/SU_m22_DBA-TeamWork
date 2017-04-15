namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ReducerType
    {
        public ReducerType()
        {
            this.MRGroups = new HashSet<MRGroup>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public virtual ICollection<MRGroup> MRGroups { get; set; }

    }
}
