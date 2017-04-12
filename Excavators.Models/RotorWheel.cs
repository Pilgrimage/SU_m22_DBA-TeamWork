namespace Excavators.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RotorWheel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public int ExcavatorId { get; set; }
        public virtual Excavator Excavator { get; set; }

    }
}
