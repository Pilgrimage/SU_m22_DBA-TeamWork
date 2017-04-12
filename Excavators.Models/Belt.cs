namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Belt
    {
        public Belt()
        {
            this.Drums = new HashSet<Drum>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
        // Rotor Belt
        // Reverse Belt
        // Intermediale Belt
        // Long Belt
        // Unloading Belt

        [StringLength(50)]
        public string Type { get; set; }
        // First Belt
        // Second Belt
        // Third Belt
        // Fourth Belt
        // Fifth Belt

        [StringLength(50)]
        public string Location { get; set; }
        // Upper level of the excavator
        // Bottom level of the excavator

        [Required]
        public int ExcavatorId { get; set; }
        public virtual Excavator Excavator { get; set; }
        
        public virtual ICollection<Drum> Drums { get; set; }
    }
}
