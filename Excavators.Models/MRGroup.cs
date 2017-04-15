namespace Excavators.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MRGroup
    {


        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Location { get; set; }
        
        [StringLength(250)]
        public string Description { get; set; }

        
        [Required]
        public int MotorTypeId { get; set; }
        public virtual MotorType MotorType { get; set; }

        
        [Required]
        public int ReducerTypeId { get; set; }
        public virtual ReducerType ReducerType { get; set; }


        public int? DrumId { get; set; }
        public virtual Drum Drum { get; set; }

        public int? RotorWheelId { get; set; }
        public virtual RotorWheel RotorWheel { get; set; }

    }
}
