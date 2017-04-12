namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ShiftingSensorData
    {
        [Key]
        public int Id { get; set; }

        public bool IsShifted { get; set; }

        public DateTime DTCollected { get; set; }

        public int ShiftingSensorId { get; set; }
        public ShiftingSensor ShiftingSensor { get; set; }
    }
}
