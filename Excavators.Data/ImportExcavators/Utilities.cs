namespace Excavators.Data.ImportExcavators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Excavators.Models;

    public static class Utilities
    {
        public static int AddExcavator(string name, string type, string location)
        {
            using (var ctx = new ExcavatorsContext())
            {
                Excavator item = new Excavator()
                {
                    Name = name,
                    Type = type,
                    Location = location
                };
                ctx.Excavators.Add(item);
                ctx.SaveChanges();
                return item.Id;
            }
        }

        // Rotor Wheel
        public static int AddRotorWheel(int exId)
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


        // Rotor Belt
        public static int AddBeltWithSensors(int exId, string name)
        {
            using (var ctx = new ExcavatorsContext())
            {
                var ex = ctx.Excavators.Find(exId);

                Belt item = new Belt()
                {
                    Name = name,
                    Type = String.Concat(name, " in ", ex.Name),
                    Location = "on excavator",
                    ExcavatorId = ex.Id,
                };

                ctx.Belts.Add(item);
                ctx.SaveChanges();

                int beltId = item.Id;

                if (name == "Rotor Belt")
                {
                    VolumeSensor volumeSensor = new VolumeSensor()
                    {
                        Name = "Volume/Debit Sensor",
                        Description = String.Concat("Volume excavated material im m3/hour (on ", item.Type, ")"),
                        VolumeSensorTypeId = ctx.VolumeSensorTypes.FirstOrDefault(t => t.Type == "RUC300-M3047-LIAP8X-H1151").Id,
                        BeltId = beltId,
                    };
                    ctx.VolumeSensors.Add(volumeSensor);
                }

                ShiftingSensor shiftingSensor = new ShiftingSensor()
                {
                    Name = "Shifting Sensor",
                    Description = String.Concat("Shifting sensor for displacement of the belt (on ", item.Type, ")"),
                    ShiftingSensorTypeId = ctx.ShiftingSensorTypes.FirstOrDefault(t => t.Type == "XCRT115").Id,
                    BeltId = beltId,
                };

                TensionSensor tensionSensor = new TensionSensor()
                {
                    Name = "Tension Sensor",
                    Description = String.Concat("Load cell sensor for tension of belt (on ", item.Type, ")"),
                    TensionSensorTypeId = ctx.TensionSensorTypes.FirstOrDefault(t => t.Type == "Load Cell Model 5950-FORC000002").Id,
                    BeltId = beltId,
                    WarningLowTension = 2.00f,  // in tons
                    WarningHighTension = 10.00f,
                    WarningEmergencyHighTension = 12.00f
                };

                ctx.ShiftingSensors.Add(shiftingSensor);
                ctx.TensionSensors.Add(tensionSensor);
                ctx.SaveChanges();

                return beltId;
            }
        }


        public static int AddDrumWithSensors(int beltId, string name)
        {
            using (var ctx = new ExcavatorsContext())
            {
                var belt = ctx.Belts.Find(beltId);

                Drum item = new Drum()
                {
                    Name = name,       // "Drive Drum" or "Passive Drum"
                    Type = String.Concat(name, " on ", belt.Name),
                    BeltId = belt.Id,
                };

                ctx.Drums.Add(item);
                ctx.SaveChanges();

                int drumId = item.Id;

                List<TempSensor> tempSensors = new List<TempSensor>()
                {
                    new TempSensor()
                    {
                        Name = String.Concat("t° of Left bearing of ", item.Name),
                        Description = String.Concat("RTDx6 - Left bearing of ", item.Type),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL.M3.B.2.X.X-OV").Id,
                        DrumId = drumId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = String.Concat("t° of Right bearing of ", item.Name),
                        Description = String.Concat("RTDx7 - Right bearing of ", item.Type),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL.M3.B.2.X.X-OV").Id,
                        DrumId = drumId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    }
                };

                SpeedSensor speedSensor = new SpeedSensor()
                {
                    Name = String.Concat(item.Name, " speed"),
                    Description = String.Concat(item.Name, " speed of ", item.Type),
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
        

        public static int AddMrGroup(int upId, string type, string name, string flag)
        {
            using (var ctx = new ExcavatorsContext())
            {
                if (flag == "toRW")
                {
                    var up = ctx.RotorWheels.Find(upId);

                    MRGroup mrGroup = new MRGroup()
                    {
                        Name = name,
                        Type = type,
                        Location = "on excavator",
                        Description = String.Concat(name, " ", type, " in ", up.Name),
                        MotorTypeId = ctx.MotorTypes.FirstOrDefault(t => t.Type.Contains(type)).Id,
                        ReducerTypeId = ctx.ReducerTypes.FirstOrDefault(t => t.Type.Contains(type)).Id,
                        RotorWheelId = up.Id,
                    };
                    ctx.MRGroups.Add(mrGroup);
                    ctx.SaveChanges();
                    return mrGroup.Id;

                }
                else if (flag == "toDrum")
                {
                    var up = ctx.Drums.Find(upId);

                    MRGroup mrGroup = new MRGroup()
                    {
                        Name = name,
                        Type = type,
                        Location = "on excavator",
                        Description = String.Concat(name, " ", type, " in ", up.Type),
                        MotorTypeId = ctx.MotorTypes.FirstOrDefault(t => t.Type.Contains(type)).Id,
                        ReducerTypeId = ctx.ReducerTypes.FirstOrDefault(t => t.Type.Contains(type)).Id,
                        DrumId = up.Id,
                    };
                    ctx.MRGroups.Add(mrGroup);
                    ctx.SaveChanges();
                    return mrGroup.Id;
                }

                return 0;
            }
        }


        public static void AddSensorsToMRGroup(int mrGroupId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                var mrGroup = ctx.MRGroups.Find(mrGroupId);

                List<TempSensor> tempSensors = new List<TempSensor>()
                {
                    new TempSensor()
                    {
                        Name = "t° of Rear bearing of motor",
                        Description = String.Concat("RTDx0 - Rear bearing of motor in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL.M3.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 80.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = "t° of Front bearing of motor",
                        Description = String.Concat("RTDx1 - Front bearing of motor in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL.M3.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 80.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = "t° of Front bearing of reducer, 1st stage",
                        Description = String.Concat("RTDx2 - Front bearing of reducer, 1st stage in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSAG2-RD.T9.5.17.30.5SL.Q29.M1.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = "t° of Rear bearing of reducer, 1st stage",
                        Description = String.Concat("RTDx3 - Rear bearing of reducer, 1st stage in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSAG2-RD.T9.5.17.30.5SL.Q29.M1.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = "t° of Left bearing of reducer, 2nd stage",
                        Description = String.Concat("RTDx4 - Left bearing of reducer, 2nd stage in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSAG2-RD.T9.5.17.30.5SL.Q29.M1.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                    new TempSensor()
                    {
                        Name = "t° of Right bearing of reducer, 2nd stage",
                        Description = String.Concat("RTDx5 - Right bearing of reducer, 2nd stage in ", mrGroup.Name),
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSAG2-RD.T9.5.17.30.5SL.Q29.M1.B.2.X.X-OV").Id,
                        MRGroupId = mrGroup.Id,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },

                };

                CurrentSensor currentSensor = new CurrentSensor()
                {
                    Name = String.Concat("Motor current in ", mrGroup.Name),
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
