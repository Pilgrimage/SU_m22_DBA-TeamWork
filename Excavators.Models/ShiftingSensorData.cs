namespace Excavators.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ShiftingSensorData
    {
        public ShiftingSensorData()
        {
            DTCollected = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        public bool? IsShifted { get; set; }

        public DateTime DTCollected { get; set; }

        public int Status { get; set; }
        // 0 -> means nothing
        // 1 => checked succesfully, OK
        // 64 => Sensor Failed (if it's null)


        public int ShiftingSensorId { get; set; }
        public ShiftingSensor ShiftingSensor { get; set; }
    }
}
