namespace Excavators.Data.SeedSensorDatas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Excavators.Models.DTO;

    public static class SetDataToDto
    {

        public static void SetDataToTempDtos()
        {
            using (var ctx = new ExcavatorsContext())
            {
                Console.WriteLine("Set Data to Temperature DTOs...");
                var tempAllDto = new List<TempAllDto>();
                var tempWarningsDto = new List<TempWarningsDto>();

                var tsdPrepare = ctx.TempSensorDatas
                    .Include("TempSensor")
                    .Select(s => new
                    {
                        s.DTCollected,
                        s.Temperature,
                        s.TempSensorId,
                        Description = s.TempSensor.Description,
                        s.Status
                    });

                var val = new TempAllDto();
                var valW = new TempWarningsDto();

                foreach (var item in tsdPrepare)
                {
                    val.SensorName = $"TempSensor {item.TempSensorId} - {item.Description}";
                    val.Temperature = $"{item.Temperature:F2} °C";
                    val.TimeCollected = item.DTCollected.ToString("yyyy-MM-dd  hh:mm:ss");
                    tempAllDto.Add(val);

                    if (item.Status > 1)
                    {
                        valW.SensorName = val.SensorName;
                        valW.Temperature = val.Temperature;
                        valW.TimeCollected = val.TimeCollected;
                        valW.Warning = "";

                        switch (item.Status)
                        {
                            case 8:
                                valW.Warning = "High Temperature!";
                                break;
                            case 16:
                                valW.Warning = "Emergency High Temperature!";
                                break;
                            case 64:
                                valW.Warning = "The sensor is damaged or the connection with him is interrupted!";
                                break;
                        }

                        tempWarningsDto.Add(valW);
                    }
                }

                Console.WriteLine($"Records in tempAllDto : {tempAllDto.Count}");
                Console.WriteLine($"Records in tempWarningsDto : {tempWarningsDto.Count}");
                Console.WriteLine();
            }

        }


        public static void SetDataToCurrentDtos()
        {
            using (var ctx = new ExcavatorsContext())
            {
                Console.WriteLine("Set Data to Current DTOs...");
                var currentAllDto = new List<CurrentAllDto>();
                var currentWarningsDto = new List<CurrentWarningsDto>();

                var csdPrepare = ctx.CurrentSensorDatas
                    .Include("TempSensor")
                    .Select(s => new
                    {
                        s.DTCollected,
                        s.Current,
                        s.CurrentSensorId,
                        Description = s.CurrentSensor.Description,
                        s.Status
                    });

                var val = new CurrentAllDto();
                var valW = new CurrentWarningsDto();

                foreach (var item in csdPrepare)
                {
                    val.SensorName = $"CurrentSensor {item.CurrentSensorId} - {item.Description}";
                    val.Current = $"{item.Current:F2} A";
                    val.TimeCollected = item.DTCollected.ToString("yyyy-MM-dd  hh:mm:ss");
                    currentAllDto.Add(val);

                    if (item.Status > 1)
                    {
                        valW.SensorName = val.SensorName;
                        valW.Current = val.Current;
                        valW.TimeCollected = val.TimeCollected;
                        valW.Warning = "";

                        switch (item.Status)
                        {
                            case 8:
                                valW.Warning = "High Current!";
                                break;
                            case 16:
                                valW.Warning = "Emergency High Current!";
                                break;
                            case 64:
                                valW.Warning = "The sensor is damaged or the connection with him is interrupted!";
                                break;
                        }

                        currentWarningsDto.Add(valW);
                    }
                }
                Console.WriteLine($"Records in currentAllDto : {currentAllDto.Count}");
                Console.WriteLine($"Records in currentWarningsDto : {currentWarningsDto.Count}");
                Console.WriteLine();
            }
        }



    }
}
