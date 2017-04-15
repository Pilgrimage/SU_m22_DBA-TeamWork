using System;
using System.Collections.Generic;
using System.Linq;
using Excavators.Models;

namespace Excavators.Data.ImportExcavators
{
    public static class ImportRs2000
    {
        public static void CreateRs2000()
        {
            Console.WriteLine("Creating Rs2000 B243...");
            //var context = new ExcavatorsContext();
            int exId = AddExcavator();
            int rwId = AddRotorWheel(exId);
            int mrgRwId = AddMrGroupRw(rwId, "1000kW");
            AddSensorsToMRGroup(mrgRwId);

            //AddSensorsToMotor(motRwId);
            //AddSensorsToReducer(redRwId);

            //int rotorBeltId = AddRotorBeltWithSensors(exId);
            //int drumFrontRotorBeltId = AddFrontDrumRotorBeltWithSensors(rotorBeltId);
            //int drumRearRotorBeltId = AddRearDrumRotorBeltWithSensors(rotorBeltId);




        }


        private static int AddExcavator()
        {
            using (var ctx = new ExcavatorsContext())
            {
                Excavator item = new Excavator()
                {
                    Name = "Rs2000 B243",
                    Type = "Rs2000",
                    Location = "MMI, Rudnik Troyanovo-Sever, RTNK-5"
                };
                ctx.Excavators.Add(item);
                ctx.SaveChanges();
                return item.Id;
            }
        }

        // Rotor Wheel
        private static int AddRotorWheel(int exId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                RotorWheel item = new RotorWheel()
                {
                    Name = "Rotor Wheel",
                    ExcavatorId = exId,
                };
                ctx.RotorWheels.Add(item);
                ctx.SaveChanges();
                return item.Id;
            }
        }

        private static int AddMrGroupRw(int rwId, string type)
        {
            using (var ctx = new ExcavatorsContext())
            {
                var rw = ctx.RotorWheels.Find(rwId);

                MRGroup mrGroup = new MRGroup()
                {
                    Name = "Motor-Reductor Group",
                    Type = type,
                    Location = "",
                    Description = String.Concat("Motor-Reductor Group ", type, " in ", rw.Name),
                    MotorTypeId = ctx.MotorTypes.FirstOrDefault(t => t.Type.Contains(type)).Id,
                    ReducerTypeId = ctx.ReducerTypes.FirstOrDefault(t => t.Type.Contains(type)).Id,
                    RotorWheelId = rw.Id,
                };

                ctx.MRGroups.Add(mrGroup);
                ctx.SaveChanges();
                return mrGroup.Id;
            }
        }




        // Rotor Belt
        private static int AddRotorBeltWithSensors(int exId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                Belt item = new Belt()
                {
                    Name = "Rotor Belt",
                    Type = "Rotor Belt for Rs2000 B243",
                    Location = "Upper level of the excavator",
                    ExcavatorId = exId,
                };

                ctx.Belts.Add(item);
                ctx.SaveChanges();

                int beltId = item.Id;

                VolumeSensor volumeSensor = new VolumeSensor()
                {
                    Name = "Volume/Debit",
                    Description = "Volume excavated material im m3/hour",
                    VolumeSensorTypeId = ctx.VolumeSensorTypes.FirstOrDefault(t => t.Type == "RUC300-M3047-LIAP8X-H1151").Id,
                    BeltId = beltId,
                };

                ShiftingSensor shiftingSensor = new ShiftingSensor()
                {
                    Name = "Shifting",
                    Description = "Shifting sensor for displacement of the besl",
                    ShiftingSensorTypeId = ctx.ShiftingSensorTypes.FirstOrDefault(t => t.Type == "XCRT115").Id,
                    BeltId = beltId,
                };

                TensionSensor tensionSensor = new TensionSensor()
                {
                    Name = "Volume/Debit",
                    Description = "Volume excavated material im m3/hour",
                    TensionSensorTypeId = ctx.TensionSensorTypes.FirstOrDefault(t => t.Type == "Load Cell Model 5950-FORC000002").Id,
                    BeltId = beltId,
                    WarningLowTension = 2.00f,  // in tons
                    WarningHighTension = 10.00f,
                    WarningEmergencyHighTension = 12.00f
                };

                ctx.VolumeSensors.Add(volumeSensor);
                ctx.ShiftingSensors.Add(shiftingSensor);
                ctx.TensionSensors.Add(tensionSensor);
                ctx.SaveChanges();

                return beltId;
            }
        }

        private static int AddFrontDrumRotorBeltWithSensors(int rotorBeltId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                Drum item = new Drum()
                {
                    Name = "Front drum",
                    Type = "Front drum for Rotor Belt of Rs2000 B243",
                    BeltId = rotorBeltId,
                };

                ctx.Drums.Add(item);
                ctx.SaveChanges();

                int drumId = item.Id;

                List<TempSensor> tempSensors = new List<TempSensor>()
                {
                    new TempSensor()
                    {
                        Name = "Left bearing",
                        Description = "Left bearing of Front drum/Rotor belt/Rs2000 B243",
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV").Id,
                        DrumId = drumId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                new TempSensor()
                    {
                        Name = "Right bearing",
                        Description = "Right bearing of Front drum/Rotor belt/Rs2000 B243",
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV").Id,
                        DrumId = drumId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    }
                };

                SpeedSensor speedSensor = new SpeedSensor()
                {
                    Name = "Drum speed",
                    Description = "Speed of Front drum/Rotor belt/Rs2000 B243",
                    SpeedSensorTypeId = ctx.SpeedSensorTypes.FirstOrDefault(t => t.Type == "XS130B3PBM12").Id,
                    DrumId = drumId,
                    WarningLowSpeed = 4.00f,        // in m/s
                    WarningHighSpeed = 12.00f
                };

                ctx.TempSensors.AddRange(tempSensors);
                ctx.SpeedSensors.Add(speedSensor);
                ctx.SaveChanges();

                return drumId;
            }

        }

        private static int AddRearDrumRotorBeltWithSensors(int rotorBeltId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                Drum item = new Drum()
                {
                    Name = "Rear drum",
                    Type = "Rear drum for Rotor Belt of Rs2000 B243",
                    BeltId = rotorBeltId,
                };

                ctx.Drums.Add(item);
                ctx.SaveChanges();

                int drumId = item.Id;

                List<TempSensor> tempSensors = new List<TempSensor>()
                {
                    new TempSensor()
                    {
                        Name = "Left bearing",
                        Description = "Left bearing of Rear drum/Rotor belt/Rs2000 B243",
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV").Id,
                        DrumId = drumId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                new TempSensor()
                    {
                        Name = "Right bearing",
                        Description = "Right bearing of Rear drum/Rotor belt/Rs2000 B243",
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV").Id,
                        DrumId = drumId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    }
                };

                SpeedSensor speedSensor = new SpeedSensor()
                {
                    Name = "Drum speed",
                    Description = "Speed of Rear drum/Rotor belt/Rs2000 B243",
                    SpeedSensorTypeId = ctx.SpeedSensorTypes.FirstOrDefault(t => t.Type == "XS130B3PBM12").Id,
                    DrumId = drumId,
                    WarningLowSpeed = 4.00f,        // in m/s
                    WarningHighSpeed = 12.00f
                };

                ctx.TempSensors.AddRange(tempSensors);
                ctx.SpeedSensors.Add(speedSensor);
                ctx.SaveChanges();

                return drumId;
            }

        }










        // ====================   UTILITIES   =============================


        private static void AddSensorsToMRGroup(int mrGroupId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                var mrGroup = ctx.MRGroups.Find(mrGroupId);

                List<TempSensor> tempSensors = new List<TempSensor>()
                {
                    new TempSensor()
                    {
                        Name = "Rear bearing of motor",
                        Description = String.Concat("RTDx1 - Rear bearing of motor in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL.M3.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 80.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = "Front bearing of motor",
                        Description = String.Concat("RTDx2 - Front bearing of motor in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL.M3.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 80.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = "Front bearing of reducer, 1st stage",
                        Description = String.Concat("RTDx3 - Front bearing of reducer, 1st stage in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSAG2-RD.T9.5.17.30.5SL.Q29.M1.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = "Rear bearing of reducer, 1st stage",
                        Description = String.Concat("RTDx4 - Rear bearing of reducer, 1st stage in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSAG2-RD.T9.5.17.30.5SL.Q29.M1.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = "Left bearing of reducer, 2nd stage",
                        Description = String.Concat("RTDx5 - Left bearing of reducer, 2nd stage in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSAG2-RD.T9.5.17.30.5SL.Q29.M1.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = "Right bearing of reducer, 2nd stage",
                        Description = String.Concat("RTDx6 - Right bearing of reducer, 2nd stage in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSAG2-RD.T9.5.17.30.5SL.Q29.M1.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },

                };

                CurrentSensor currentSensor = new CurrentSensor()
                {
                    Name = "Motor Current",
                    Description = String.Concat("CT - Current of motor in ", mrGroup.Name),
                    CurrentSensorTypeId = ctx.CurrentSensorTypes.FirstOrDefault(t => t.Type == "Serie 5AAC, model AC1-15").Id,
                    MRGroupId = mrGroup.Id,
                    WarningHighCurrent = 375.00f,
                    WarningEmergencyHighCurrent = 410.00f,
                };
                
                ctx.TempSensors.AddRange(tempSensors);
                ctx.CurrentSensors.Add(currentSensor);
                ctx.SaveChanges();
            }
        }



    }
}
