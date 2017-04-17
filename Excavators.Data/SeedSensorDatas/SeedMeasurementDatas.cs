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



        private static int CheckSensorStatus(double current, double warningHigh, double emergencyHigh, double rangeMin, double rangeMax)
        {
            if ((rangeMax > 0 && current > rangeMax) || current < rangeMin)
            {
                return 64;
            }
            if (emergencyHigh > 0 && current > emergencyHigh)
            {
                return 16;
            }
            if (warningHigh > 0 && current > warningHigh)
            {
                return 8;
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
