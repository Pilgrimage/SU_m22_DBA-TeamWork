namespace Excavators.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Motor
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string MotorType { get; set; }

        public int MrgId { get; set; }
        public virtual MRG Mrg { get; set; }

    }
}
