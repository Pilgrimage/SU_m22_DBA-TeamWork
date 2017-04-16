namespace Excavators.Data.SeedSensorDatas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Excavators.Models;
    using Excavators.Models.DTO;

    public class SeedCurrentData
    {

        static Random excavatorRandom = new Random();

        public static void FillCurrentSensors()
        {
            using (var ctx = new ExcavatorsContext())
            {
                int currentSensorsCount = ctx.CurrentSensors.Count();
                DateTime dt = DateTime.Now;

                for (int sensorId = 1; sensorId <= currentSensorsCount; sensorId++)
                {
                    Console.WriteLine($"Seed data for current sensor {sensorId}");

                    List<CurrentSensorData> measurements = new List<CurrentSensorData>();

                    double warningHigh = ctx.CurrentSensors.Find(sensorId).WarningHighCurrent;
                    double emergencyHigh = ctx.CurrentSensors.Find(sensorId).WarningEmergencyHighCurrent;
                    double rangeMin = ctx.CurrentSensors.Find(sensorId).CurrentSensorType.RangeMin;
                    double rangeMax = ctx.CurrentSensors.Find(sensorId).CurrentSensorType.RangeMax;

                    DateTime currentTime = dt;

                    //1500 records to be generated
                    for (int j = 0; j < 1500; j++)
                    {
                        double currentRnd = GetRndCurrent(emergencyHigh);

                        var status = CheckSensorStatus(currentRnd, warningHigh, emergencyHigh, rangeMin, rangeMax);

                        var newMeasurement = new CurrentSensorData()
                        {
                            CurrentSensorId = sensorId,
                            Current = currentRnd,
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

        static double GetRndCurrent(double emergencyHigh)
        {
            var range = excavatorRandom.NextDouble();
            var next = excavatorRandom.Next(0, (int)(emergencyHigh * 1.5));

            return range * next;
        }

    }
}
