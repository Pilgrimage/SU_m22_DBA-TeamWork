namespace Excavators.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MRG
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int? DrumId { get; set; }
        public virtual Drum Drum { get; set; }

        public int? RotorWheelId { get; set; }
        public virtual RotorWheel RotorWheel { get; set; }

    }
}
