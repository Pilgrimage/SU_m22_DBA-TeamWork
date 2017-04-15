using System;

namespace Excavators.Data.ImportExcavators
{
    using Excavators.Models;
    using Excavators.Data;
    using System.Collections.Generic;

    public static class Seeds
    {
        public static void SeedMotorTypes()
        {
            Console.WriteLine("Seeding Motor Types...");
            List<MotorType> motorTypes = new List<MotorType>()
                {
                    new MotorType()
                    {
                        Type = "1000kW, 500V, 3ph",
                        Manufacturer = "Siemens",
                        Description = "Motor for Rotor Wheel of Excavator type Rs2000"
                    },
                    new MotorType()
                    {
                        Type = "900kW, 500V, 3ph",
                        Manufacturer = "Siemens",
                        Description = "Motor for Rotor Wheel of Excavator type Rs2000"

                    },
                    new MotorType()
                    {
                        Type = "500kW, 400V, 3ph",
                        Manufacturer = "Siemens",
                        Description = "Motor for Excavator's Belt"
                    },
                    new MotorType()
                    {
                        Type = "380kW, 380V, 3ph",
                        Manufacturer = "Siemens",
                        Description = "Motor for Excavator's Belt"
                    },
                    new MotorType()
                    {
                        Type = "230kW, 380V, 3ph",
                        Manufacturer = "Siemens",
                        Description = "Motor for Excavator's Belt"
                    },
                    new MotorType()
                    {
                        Type = "180kW, 380V, 3ph",
                        Manufacturer = "Siemens",
                        Description = "Motor for Excavator's Belt"
                    },
                    new MotorType()
                    {
                        Type = "130kW, 380V, 3ph",
                        Manufacturer = "Siemens",
                        Description = "Motor for Excavator's Belt"
                    },
                    new MotorType()
                    {
                        Type = "80kW, 380V, 3ph",
                        Manufacturer = "Siemens",
                        Description = "Motor for Excavator's Belt"
                    }
                };

            using (var ctx = new ExcavatorsContext())
            {
                ctx.MotorTypes.AddRange(motorTypes);
                ctx.SaveChanges();
            }
        }   // Done

        public static void SeedReducerTypes()
        {
            Console.WriteLine("Seeding Reducer Types...");
            List<ReducerType> reducerTypes = new List<ReducerType>()
                {
                    new ReducerType()
                    {
                        Type = "Gear speed reducer 1 In 1 Out, 1000kW",
                        Manufacturer = "Nord DriveSystems",
                        Description = "Industrial gear reducer"
                    },
                    new ReducerType()
                    {
                        Type = "Gear speed reducer 1 In 1 Out, 900kW",
                        Manufacturer = "Nord DriveSystems",
                        Description = "Industrial gear reducer"

                    },
                    new ReducerType()
                    {
                        Type = "Gear speed reducer 1 In 1 Out, 600kW",
                        Manufacturer = "Nord DriveSystems",
                        Description = "Industrial gear reducer"
                    },
                    new ReducerType()
                    {
                        Type = "Gear speed reducer 1 In 1 Out, 400kW",
                        Manufacturer = "Nord DriveSystems",
                        Description = "Industrial gear reducer"
                    },
                    new ReducerType()
                    {
                        Type = "Gear speed reducer 1 In 1 Out, 250kW",
                        Manufacturer = "Nord DriveSystems",
                        Description = "Industrial gear reducer"
                    },
                    new ReducerType()
                    {
                        Type = "Gear speed reducer 1 In 1 Out, 200kW",
                        Manufacturer = "Nord DriveSystems",
                        Description = "Industrial gear reducer"
                    },
                    new ReducerType()
                    {
                        Type = "Gear speed reducer 1 In 1 Out, 150kW",
                        Manufacturer = "Nord DriveSystems",
                        Description = "Industrial gear reducer"
                    },
                    new ReducerType()
                    {
                        Type = "Gear speed reducer 1 In 1 Out, 100kW",
                        Manufacturer = "Nord DriveSystems",
                        Description = "Industrial gear reducer"
                    }
                };


            using (var ctx = new ExcavatorsContext())
            {
                ctx.ReducerTypes.AddRange(reducerTypes);
                ctx.SaveChanges();
            }

        }   // Done

        public static void SeedCurrentSensorTypes()
        {
            Console.WriteLine("Seeding Current Sensor Types...");
            List<CurrentSensorType> currentSensorTypes = new List<CurrentSensorType>()
            {
                new CurrentSensorType()
                    {
                        Type = "Serie 5AAC, model AC1-5",
                        Manufacturer = "Delta instruments",
                        Description = "Current to Current Transmitter, 0-5A -> 4-20mADC",
                        RangeMin = 0.00f,   // Ampers
                        RangeMax = 150.00f    // Ampers
                    },
                new CurrentSensorType()
                    {
                        Type = "Serie 5AAC, model AC1-15",
                        Manufacturer = "Delta instruments",
                        Description = "Current to Current Transmitter, 0-15A -> 4-20mADC",
                        RangeMin = 0.00f,   // Ampers
                        RangeMax = 450.00f    // Ampers
                    }
                };

            using (var ctx = new ExcavatorsContext())
            {
                ctx.CurrentSensorTypes.AddRange(currentSensorTypes);
                ctx.SaveChanges();
            }

        }   // Done

        public static void SeedTempSensorTypes()
        {
            Console.WriteLine("Seeding Temperature Sensor Types...");
            List<TempSensorType> tempSensorTypes = new List<TempSensorType>()
            {
                new TempSensorType()
                    {
                        Type = "TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV",
                        Manufacturer = "Comeco Ltd",
                        Description = "Temperature sensor Pt100, D=5mm, L=30 mm, Silicon cable 5m, vibration resistant",
                        RangeMin = -50.00f,
                        RangeMax = 200.00f
                    },
                new TempSensorType()
                    {
                        Type = "TSAG2-RD.T9.5.17. 30.5SL.Q29.M1.B.2.X.X-OV",
                        Manufacturer = "Comeco Ltd",
                        Description = "Temperature sensor Pt100, M8x1.25mm, Silicon cable 5m, vibration resistant",
                        RangeMin = -50.00f,
                        RangeMax = 200.00f
                    },
                new TempSensorType()
                    {
                        Type = "TSAT-RD.T9.6.5.20. 5SL.M1.B.2",
                        Manufacturer = "Comeco Ltd",
                        Description = "Temperature sensor Pt100, Cable shoe, Silicon cable 5m, vibration resistant",
                        RangeMin = -50.00f,
                        RangeMax = 200.00f
                    },
            };

            using (var ctx = new ExcavatorsContext())
            {
                ctx.TempSensorTypes.AddRange(tempSensorTypes);
                ctx.SaveChanges();
            }

        }   // Done

        public static void SeedSpeedSensorTypes()
        {
            Console.WriteLine("SeedingSpeed Sensor Types...");
            List<SpeedSensorType> speedSensorTypes = new List<SpeedSensorType>()
            {
                new SpeedSensorType()
                    {
                        Type = "XS130B3PBM12",
                        Manufacturer = "Schneider Electric",
                        Description = "OsiSense Inductive proximity sensors, D=30mm",
                        RangeMin = 0.00f,
                        RangeMax = 20.00f
                    }
            };

            using (var ctx = new ExcavatorsContext())
            {
                ctx.SpeedSensorTypes.AddRange(speedSensorTypes);
                ctx.SaveChanges();
            }
        }   // Done

        public static void SeedVolumeSensorTypes()
        {
            Console.WriteLine("Seeding Volume Sensor Types...");
            List<VolumeSensorType> volumeSensorTypes = new List<VolumeSensorType>()
            {
            new VolumeSensorType()
                    {
                        Type = "RUC300-M3047-LIAP8X-H1151",
                        Manufacturer = "TURCK Ltd",
                        Description = "Diffuse mode UltraSound sensor 0.3 ... 3 m",
                        RangeMin = 0.00f,
                        RangeMax = 1000.00f
                    },
            };

            using (var ctx = new ExcavatorsContext())
            {
                ctx.VolumeSensorTypes.AddRange(volumeSensorTypes);
                ctx.SaveChanges();
            }

        }   // Done

        public static void SeedTensionSensorTypes()
        {
            Console.WriteLine("Seeding Tension Sensor Types...");
            List<TensionSensorType> tensionSensorTypes = new List<TensionSensorType>()
            {
                new TensionSensorType()
                    {
                        Type = "Load Pin Model 5000-HOIS002913",
                        Manufacturer = "Sensy Ltd",
                        Description = "Load Pin (Axe Dynamometrique),  Output 4...20 mA",
                        RangeMin = 0.00f,
                        RangeMax = 7.50f
                    },
                new TensionSensorType()
                    {
                        Type = "Load Pin Model 5000-HOIS002914",
                        Manufacturer = "Sensy Ltd",
                        Description = "Load Pin (Axe Dynamometrique),  Output 4...20 mA",
                        RangeMin = 0.00f,
                        RangeMax = 12.00f
                    },
                new TensionSensorType()
                    {
                        Type = "Load Pin Model 5000-HOIS002915",
                        Manufacturer = "Sensy Ltd",
                        Description = "Load Pin (Axe Dynamometrique),  Output 4...20 mA",
                        RangeMin = 0.00f,
                        RangeMax = 7.50f
                    },
                new TensionSensorType()
                    {
                        Type = "Load Cell Model SB-5000S",
                        Manufacturer = "Cardinal Scale Mfg Co",
                        Description = "Load Cell, Output 4...20 mA",
                        RangeMin = 0.00f,
                        RangeMax = 2.50f
                    },
                new TensionSensorType()
                    {
                        Type = "Load Cell Model 5950-FORC000002",
                        Manufacturer = "Sensy Ltd",
                        Description = "Low profile compression load cell, Output 4...20 mA",
                        RangeMin = 0.00f,   // tons
                        RangeMax = 15.00f   // tons
                    }
            };

            using (var ctx = new ExcavatorsContext())
            {
                ctx.TensionSensorTypes.AddRange(tensionSensorTypes);
                ctx.SaveChanges();
            }
        }    // Done

        public static void SeedShiftingSensorTypes()
        {
            Console.WriteLine("Seeding Shifting Sensor Types...");
            List<ShiftingSensorType> shiftingSensorTypes = new List<ShiftingSensorType>()
            {
            new ShiftingSensorType()
                    {
                        Type = "XCRT115",
                        Manufacturer = "Schneider Electric",
                        Description = "Limit switch for conveyor belt shift monitoring +/- 90 degree",
                    },
            new ShiftingSensorType()
                    {
                        Type = "XCRT315",
                        Manufacturer = "Schneider Electric",
                        Description = "Limit switch for conveyor belt shift monitoring  +/- 70 degree",
                    }
            };

            using (var ctx = new ExcavatorsContext())
            {
                ctx.ShiftingSensorTypes.AddRange(shiftingSensorTypes);
                ctx.SaveChanges();
            }

        }   // Done
    }
}
