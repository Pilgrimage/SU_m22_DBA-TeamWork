namespace Excavators.Data.SeedSensorDatas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Excavators.Models;
    
    public static class SeedMeasurementDatas
    {

        static Random excavatorRandom = new Random();

        
        public static void FillTempSensors()
        {
            using (var ctx = new ExcavatorsContext())
            {
                DateTime dt = DateTime.Now;
                int tempSensorsCount = ctx.TempSensors.Count();
                int[] tempIdArray = ctx.TempSensors.Select(i => i.Id).OrderBy(x => x).ToArray();

                foreach (var sensorId in tempIdArray)
                {

                    Console.WriteLine($"Seed data for temperature sensor {sensorId} of {tempSensorsCount}");

                    List<TempSensorData> measurements = new List<TempSensorData>();

                    var ts = ctx.TempSensors.Find(sensorId);
                    var tst = ctx.TempSensorTypes.Find(ts.TempSensorTypeId);

                    double warningHigh = ts.WarningHighTemp;
                    double emergencyHigh = ts.WarningEmergencyHighTemp;
                    double rangeMin = tst.RangeMin;
                    double rangeMax = tst.RangeMax;

                    DateTime currentTime = dt;

                    //1500 records to be generated
                    for (int j = 0; j < 1500; j++)
                    {
                        double rndValue = GetRndValue(emergencyHigh);

                        var status = CheckSensorStatus(rndValue, warningHigh, emergencyHigh, rangeMin, rangeMax);

                        TempSensorData newMeasurement = new TempSensorData()
                        {
                            TempSensorId = sensorId,
                            Temperature = rndValue,
                            DTCollected = currentTime,
                            Status = status
                        };
                        measurements.Add(newMeasurement);

                        currentTime = currentTime.AddMinutes(1);
                    }

                    ctx.TempSensorDatas.AddRange(measurements);
                    ctx.SaveChanges();
                }
            }
        }

        public static void FillCurrentSensors()
        {
            using (var ctx = new ExcavatorsContext())
            {
                DateTime dt = DateTime.Now;
                int currentSensorsCount = ctx.CurrentSensors.Count();
                int[] currentIdArray = ctx.CurrentSensors.Select(i => i.Id).ToArray();

                foreach (var sensorId in currentIdArray)
                {
                    Console.WriteLine($"Seed data for current sensor {sensorId} of {currentSensorsCount}");

                    List<CurrentSensorData> measurements = new List<CurrentSensorData>();

                    var cs = ctx.CurrentSensors.Find(sensorId);
                    var cst = ctx.CurrentSensorTypes.Find(cs.CurrentSensorTypeId);

                    double warningHigh = cs.WarningHighCurrent;
                    double emergencyHigh = cs.WarningEmergencyHighCurrent;
                    double rangeMin = cst.RangeMin;
                    double rangeMax = cst.RangeMax;

                    DateTime currentTime = dt;

                    //1500 records to be generated
                    for (int j = 0; j < 1500; j++)
                    {
                        double rndValue = GetRndValue(emergencyHigh);

                        var status = CheckSensorStatus(rndValue, warningHigh, emergencyHigh, rangeMin, rangeMax);

                        CurrentSensorData newMeasurement = new CurrentSensorData()
                        {
                            CurrentSensorId = sensorId,
                            Current = rndValue,
                            DTCollected = currentTime,
                            Status = status
                        };
                        measurements.Add(newMeasurement);

                        currentTime = currentTime.AddMinutes(1);
                    }

                    ctx.CurrentSensorDatas.AddRange(measurements);
                    ctx.SaveChanges();
                }
            }
        }

        public static void FillSpeedSensors()
        {
            using (var ctx = new ExcavatorsContext())
            {
                DateTime dt = DateTime.Now;
                int speedSensorsCount = ctx.SpeedSensors.Count();
                int[] speedIdArray = ctx.SpeedSensors.Select(i => i.Id).ToArray();

                foreach (var sensorId in speedIdArray)
                {
                    Console.WriteLine($"Seed data for speed sensor {sensorId} of {speedSensorsCount}");

                    List<SpeedSensorData> measurements = new List<SpeedSensorData>();

                    var ss = ctx.SpeedSensors.Find(sensorId);
                    var sst = ctx.SpeedSensorTypes.Find(ss.SpeedSensorTypeId);

                    double warningLow = ss.WarningLowSpeed;
                    double warningHigh = ss.WarningHighSpeed;
                    double rangeMin = sst.RangeMin;
                    double rangeMax = sst.RangeMax;

                    DateTime currentTime = dt;

                    //1500 records to be generated
                    for (int j = 0; j < 1500; j++)
                    {
                        double rndValue = GetRndValue(warningHigh);

                        var status = CheckSpeedSensorStatus(rndValue, warningLow, warningHigh, rangeMin, rangeMax);

                        SpeedSensorData newMeasurement = new SpeedSensorData()
                        {
                            SpeedSensorId = sensorId,
                            Speed = rndValue,
                            DTCollected = currentTime,
                            Status = status
                        };
                        measurements.Add(newMeasurement);

                        currentTime = currentTime.AddMinutes(1);
                    }

                    ctx.SpeedSensorDatas.AddRange(measurements);
                    ctx.SaveChanges();
                }
            }
        }

        public static void FillTensionSensors()
        {
            using (var ctx = new ExcavatorsContext())
            {
                DateTime dt = DateTime.Now;
                int tensionSensorsCount = ctx.TensionSensors.Count();
                int[] tensionIdArray = ctx.TensionSensors.Select(i => i.Id).ToArray();

                foreach (var sensorId in tensionIdArray)
                {
                    Console.WriteLine($"Seed data for tension sensor {sensorId} of {tensionSensorsCount}");

                    List<TensionSensorData> measurements = new List<TensionSensorData>();

                    var ts = ctx.TensionSensors.Find(sensorId);
                    var tst = ctx.TensionSensorTypes.Find(ts.TensionSensorTypeId);

                    double warningLow = ts.WarningLowTension;
                    double warningHigh = ts.WarningHighTension;
                    double emergencyHigh = ts.WarningEmergencyHighTension;
                    double rangeMin = tst.RangeMin;
                    double rangeMax = tst.RangeMax;

                    DateTime currentTime = dt;

                    //1500 records to be generated
                    for (int j = 0; j < 1500; j++)
                    {
                        double rndValue = GetRndValue(emergencyHigh);

                        var status = CheckSensorStatus(rndValue, warningLow, warningHigh, emergencyHigh, rangeMin, rangeMax);

                        TensionSensorData newMeasurement = new TensionSensorData()
                        {
                            TensionSensorId = sensorId,
                            Tension = rndValue,
                            DTCollected = currentTime,
                            Status = status
                        };
                        measurements.Add(newMeasurement);

                        currentTime = currentTime.AddMinutes(1);
                    }

                    ctx.TensionSensorDatas.AddRange(measurements);
                    ctx.SaveChanges();
                }
            }
        }


        public static void FillVolumeSensors()
        {
            using (var ctx = new ExcavatorsContext())
            {
                DateTime dt = DateTime.Now;
                int volumeSensorsCount = ctx.VolumeSensors.Count();
                int[] volumeIdArray = ctx.VolumeSensors.Select(i => i.Id).ToArray();

                foreach (var sensorId in volumeIdArray)
                {
                    Console.WriteLine($"Seed data for volume sensor {sensorId} of {volumeSensorsCount}");

                    List<VolumeSensorData> measurements = new List<VolumeSensorData>();

                    var vs = ctx.VolumeSensors.Find(sensorId);
                    var vst = ctx.VolumeSensorTypes.Find(vs.VolumeSensorTypeId);

                    double rangeMin = vst.RangeMin;
                    double rangeMax = vst.RangeMax;

                    DateTime currentTime = dt;

                    //1500 records to be generated
                    for (int j = 0; j < 1500; j++)
                    {
                        double rndValue = GetRndValue(rangeMax*0.7);

                        var status = CheckSensorStatus(rndValue, rangeMin, rangeMax);

                        VolumeSensorData newMeasurement = new VolumeSensorData()
                        {
                            VolumeSensorId = sensorId,
                            Volume = rndValue,
                            DTCollected = currentTime,
                            Status = status
                        };
                        measurements.Add(newMeasurement);

                        currentTime = currentTime.AddMinutes(1);
                    }

                    ctx.VolumeSensorDatas.AddRange(measurements);
                    ctx.SaveChanges();
                }
            }
        }


        public static void FillShiftingSensors()
        {
            using (var ctx = new ExcavatorsContext())
            {
                DateTime dt = DateTime.Now;
                int shiftingSensorsCount = ctx.ShiftingSensors.Count();
                int[] shiftingIdArray = ctx.ShiftingSensors.Select(i => i.Id).ToArray();

                foreach (var sensorId in shiftingIdArray)
                {
                    Console.WriteLine($"Seed data for shifting sensor {sensorId} of {shiftingSensorsCount}");

                    List<ShiftingSensorData> measurements = new List<ShiftingSensorData>();

                    var ss = ctx.ShiftingSensors.Find(sensorId);

                    DateTime currentTime = dt;

                    //1500 records to be generated
                    for (int j = 0; j < 1500; j++)
                    {
                        double rndValue = GetRndValue(0.65);

                        bool isShiftedValue = (rndValue > 0.8);
                        int status = isShiftedValue ? 128 : 1;

                        ShiftingSensorData newMeasurement = new ShiftingSensorData()
                        {
                            ShiftingSensorId = sensorId,
                            IsShifted = isShiftedValue,
                            DTCollected = currentTime,
                            Status = status
                        };

                        measurements.Add(newMeasurement);

                        currentTime = currentTime.AddMinutes(1);
                    }

                    ctx.ShiftingSensorDatas.AddRange(measurements);
                    ctx.SaveChanges();
                }
            }

        }


        private static int CheckSensorStatus(double value, double rangeMin, double rangeMax)
        {
            if ((rangeMax > 0 && value > rangeMax) || value < rangeMin)
            {
                return 64;
            }
            return 1;
        }
        
        private static int CheckSensorStatus(double value, double warningHigh, double emergencyHigh, double rangeMin, double rangeMax)
        {
            if ((rangeMax > 0 && value > rangeMax) || value < rangeMin)
            {
                return 64;
            }
            if (emergencyHigh > 0 && value > emergencyHigh)
            {
                return 16;
            }
            if (warningHigh > 0 && value > warningHigh)
            {
                return 8;
            }
            return 1;
        }

        private static int CheckSensorStatus(double value, double warningLow, double warningHigh, double emergencyHigh, double rangeMin, double rangeMax)
        {
            if ((rangeMax > 0 && value > rangeMax) || value < rangeMin)
            {
                return 64;
            }
            if (emergencyHigh > 0 && value > emergencyHigh)
            {
                return 16;
            }
            if (warningHigh > 0 && value > warningHigh)
            {
                return 8;
            }
            if (value < warningLow)
            {
                return 2;
            }

            return 1;
        }

        private static int CheckSpeedSensorStatus(double value, double warningLow, double warningHigh, double rangeMin, double rangeMax)
        {
            if ((rangeMax > 0 && value > rangeMax) || value < rangeMin)
            {
                return 64;
            }
            if (warningHigh > warningLow && value > warningHigh)
            {
                return 8;
            }
            if (value < warningLow)
            {
                return 2;
            }

            return 1;
        }


        static double GetRndValue(double emergencyHigh)
        {
            var range = excavatorRandom.NextDouble();
            var next = excavatorRandom.Next(0, (int)(emergencyHigh * 1.5));

            return range * next;
        }

    }
}
