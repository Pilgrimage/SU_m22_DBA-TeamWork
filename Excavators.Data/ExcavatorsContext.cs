namespace Excavators.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Excavators.Models;

    public class ExcavatorsContext : DbContext
    {
        public ExcavatorsContext()
            : base("name=ExcavatorsContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ExcavatorsContext>());;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Motor>()
            //    .HasRequired(a => a.Mrg)
            //    .WithOptional()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Reducer>()
            //    .HasRequired(a => a.Mrg)
            //    .WithOptional()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<RotorWheel>()
            //    .HasRequired(a => a.Excavator)
            //    .WithOptional()
            //    .WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Excavator> Excavators { get; set; }
        public virtual DbSet<RotorWheel> RotorWheels { get; set; }
        public virtual DbSet<Belt> Belts { get; set; }
        public virtual DbSet<Drum> Drums { get; set; }
        public virtual DbSet<MRG> MRGs { get; set; }

        public virtual DbSet<Reducer> Reducers { get; set; }
        public virtual DbSet<ReducerType> ReducerTypes { get; set; }

        public virtual DbSet<Motor> Motors { get; set; }
        public virtual DbSet<MotorType> MotorTypes { get; set; }

        public virtual DbSet<TempSensor> TempSensors { get; set; }
        public virtual DbSet<TempSensorType> TempSensorTypes { get; set; }
        public virtual DbSet<TempSensorData> TempSensorDatas { get; set; }

        public virtual DbSet<SpeedSensor> SpeedSensors { get; set; }
        public virtual DbSet<SpeedSensorType> SpeedSensorTypes { get; set; }
        public virtual DbSet<SpeedSensorData> SpeedSensorDatas { get; set; }

        public virtual DbSet<CurrentSensor> CurrentSensors { get; set; }
        public virtual DbSet<CurrentSensorType> CurrentSensorTypes { get; set; }
        public virtual DbSet<CurrentSensorData> CurrentSensorDatas { get; set; }

        public virtual DbSet<TensionSensor> TensionSensors { get; set; }
        public virtual DbSet<TensionSensorType> TensionSensorTypes { get; set; }
        public virtual DbSet<TensionSensorData> TensionSensorDatas { get; set; }

        public virtual DbSet<ShiftingSensor> ShiftingSensors { get; set; }
        public virtual DbSet<ShiftingSensorType> ShiftingSensorTypes { get; set; }
        public virtual DbSet<ShiftingSensorData> ShiftingSensorDatas { get; set; }

        public virtual DbSet<VolumeSensor> VolumeSensors { get; set; }
        public virtual DbSet<VolumeSensorType> VolumeSensorTypes { get; set; }
        public virtual DbSet<VolumeSensorData> VolumeSensorDatas { get; set; }

    }

}