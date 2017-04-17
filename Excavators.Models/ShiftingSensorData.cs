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

        public int Status { get; set; }
        // 0 -> means nothing
        // 1 => checked succesfully, OK
        // 128 => Sensor value is true, belt is shifted


        public int ShiftingSensorId { get; set; }
        public virtual ShiftingSensor ShiftingSensor { get; set; }
    }
}
