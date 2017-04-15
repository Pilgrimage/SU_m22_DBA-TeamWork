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
            var context = new ExcavatorsContext();
            int exId = AddExcavator();
            int rwId = AddRotorWheel(exId);
            int mrgRwId = AddMrgRw(rwId);
            int motRwId = AddMotor(mrgRwId);
            int redRwId = AddReducer(mrgRwId);

            AddSensorsToMotor(motRwId);
            AddSensorsToReducer(redRwId);


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

        private static int AddRotorWheel(int exId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                RotorWheel item = new RotorWheel()
                {
                    Name = "RotorWheel",
                    ExcavatorId = exId,
                };
                ctx.RotorWheels.Add(item);
                ctx.SaveChanges();
                return item.Id;
            }
        }

        private static int AddMrgRw(int rwId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                MRG item = new MRG()
                {
                    Name = "Motor-ReductorGroup",
                    Type = "MRG for RW for Rs2000, 1000kW, 1 Motor, 1 Reductor",
                    RotorWheelId = rwId,
                };
                ctx.MRGs.Add(item);
                ctx.SaveChanges();
                return item.Id;
            }
        }

        private static int AddMotor(int mrgRwId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                Motor item = new Motor()
                {
                    Name = "Motor",
                    MotorTypeId = ctx.MotorTypes.FirstOrDefault(t => t.Type == "1000kW, 500V, 3ph").Id,
                    MrgId = mrgRwId,
                };
                ctx.Motors.Add(item);
                ctx.SaveChanges();
                return item.Id;
            }
        }

        private static int AddReducer(int mrgRwId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                Reducer item = new Reducer()
                {
                    Name = "Reductor",
                    ReducerTypeId = ctx.ReducerTypes.FirstOrDefault(t => t.Type == "Gear speed reducer 1 In 1 Out, 1000kW").Id,
                    MrgId = ctx.MRGs.Find(mrgRwId).Id,
                };

                ctx.Reducers.Add(item);
                ctx.SaveChanges();
                return item.Id;
            };


        }

        private static void AddSensorsToMotor(int motRwId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                List<TempSensor> tempSensors = new List<TempSensor>()
                {
                    new TempSensor()
                    {
                        Name = "Rear bearing",
                        Description = "RTD10 - Rear bearing",
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV").Id,
                        MotorId = motRwId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    },
                new TempSensor()
                    {
                        Name = "Front bearing",
                        Description = "RTD11 - Front bearing",
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV").Id,
                        MotorId = motRwId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 120.00f
                    }
                };

                ctx.TempSensors.AddRange(tempSensors);
                ctx.SaveChanges();

                CurrentSensor currentSensor = new CurrentSensor()
                {
                    Name = "Motor Current",
                    Description = "Motor Current, measured on phase 2",
                    CurrentSensorTypeId = ctx.CurrentSensorTypes.FirstOrDefault(t => t.Type == "Serie 5AAC, model AC1-15").Id,
                    MotorId = motRwId,
                    WarningHighCurrent = 375.00f,
                    WarningEmergencyHighCurrent = 410.00f,
                };

                ctx.CurrentSensors.Add(currentSensor);
                ctx.SaveChanges();
            }
        }

        private static void AddSensorsToReducer(int redRwId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                List<TempSensor> tempSensors = new List<TempSensor>()
                {
                    new TempSensor()
                    {
                        Name = "First stage, front bearing",
                        Description = "RTD12 - First stage, front bearing",
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV").Id,
                        MotorId = redRwId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 110.00f
                    },
                new TempSensor()
                    {
                        Name = "First stage, rear bearing",
                        Description = "RTD13 - First stage, rear bearing",
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV").Id,
                        MotorId = redRwId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 110.00f
                    },
                                    new TempSensor()
                    {
                        Name = "Second stage, left bearing",
                        Description = "RTD14 - Second stage, left bearing",
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV").Id,
                        MotorId = redRwId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 110.00f
                    },
                    new TempSensor()
                    {
                        Name = "Second stage, right bearing",
                        Description = "RTD15 - Second stage, right bearing",
                        TempSensorTypeId = ctx.TempSensorTypes.FirstOrDefault(t=>t.Type=="TSA-RD.T9.5.30.5SL. M3.B.2.X.X-OV").Id,
                        MotorId = redRwId,
                        WarningHighTemp = 90.00f,
                        WarningEmergencyHighTemp = 110.00f
                    },

                };
                
                ctx.TempSensors.AddRange(tempSensors);
                ctx.SaveChanges();
            }
        }


        private static void AddBelt()
        {
            using (var ctx = new ExcavatorsContext())
            {
                RotorWheel item = new RotorWheel()
                {
                    Name = "RW for Rs2000 N243",
                    ExcavatorId = ctx.Excavators.SingleOrDefault(e => e.Name == "Rs2000 N243").Id,
                };
                ctx.RotorWheels.Add(item);
                ctx.SaveChanges();
            }

        }


    }
}
