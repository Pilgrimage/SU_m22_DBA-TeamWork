namespace Excavators.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Excavator
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }        // Rs2000-338

        [StringLength(50)]
        public string Type { get; set; }        // Rs2000

        [StringLength(50)]
        public string Location { get; set; }    // Rudnik Troyanovo-4, RTNK5

    }
}
