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
                    .Include("CurrentSensor")
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


        public static void SetDataToSpeedDtos()
        {
            using (var ctx = new ExcavatorsContext())
            {
                Console.WriteLine("Set Data to Speed DTOs...");
                var speedAllDto = new List<SpeedAllDto>();
                var speedWarningsDto = new List<SpeedWarningsDto>();

                var ssdPrepare = ctx.SpeedSensorDatas
                    .Include("SpeedSensor")
                    .Select(s => new
                    {
                        s.DTCollected,
                        s.Speed,
                        s.SpeedSensorId,
                        Description = s.SpeedSensor.Description,
                        s.Status
                    });

                var val = new SpeedAllDto();
                var valW = new SpeedWarningsDto();

                foreach (var item in ssdPrepare)
                {
                    val.SensorName = $"SpeedSensor {item.SpeedSensorId} - {item.Description}";
                    val.Speed = $"{item.Speed:F2} m/s";
                    val.TimeCollected = item.DTCollected.ToString("yyyy-MM-dd  hh:mm:ss");
                    speedAllDto.Add(val);

                    if (item.Status > 1)
                    {
                        valW.SensorName = val.SensorName;
                        valW.Speed = val.Speed;
                        valW.TimeCollected = val.TimeCollected;
                        valW.Warning = "";

                        switch (item.Status)
                        {
                            case 2:
                                valW.Warning = "Too Low Speed!";
                                break;
                            case 8:
                                valW.Warning = "Too High Speed!";
                                break;
                            case 64:
                                valW.Warning = "The sensor is damaged or the connection with him is interrupted!";
                                break;
                        }

                        speedWarningsDto.Add(valW);
                    }
                }
                Console.WriteLine($"Records in speedAllDto : {speedAllDto.Count}");
                Console.WriteLine($"Records in speedWarningsDto : {speedWarningsDto.Count}");
                Console.WriteLine();
            }

        }


        public static void SetDataToTensionDtos()
        {
            using (var ctx = new ExcavatorsContext())
            {
                Console.WriteLine("Set Data to Tension DTOs...");
                var tensionAllDto = new List<TensionAllDto>();
                var tensionWarningsDto = new List<TensionWarningsDto>();

                var tsdPrepare = ctx.TensionSensorDatas
                    .Include("TensionSensor")
                    .Select(s => new
                    {
                        s.DTCollected,
                        s.Tension,
                        s.TensionSensorId,
                        Description = s.TensionSensor.Description,
                        s.Status
                    });

                var val = new TensionAllDto();
                var valW = new TensionWarningsDto();

                foreach (var item in tsdPrepare)
                {
                    val.SensorName = $"TensionSensor {item.TensionSensorId} - {item.Description}";
                    val.Tension = $"{item.Tension:F3} t";
                    val.TimeCollected = item.DTCollected.ToString("yyyy-MM-dd  hh:mm:ss");
                    tensionAllDto.Add(val);

                    if (item.Status > 1)
                    {
                        valW.SensorName = val.SensorName;
                        valW.Tension = val.Tension;
                        valW.TimeCollected = val.TimeCollected;
                        valW.Warning = "";

                        switch (item.Status)
                        {
                            case 2:
                                valW.Warning = "Too Low Tension - danger of slippage!";
                                break;
                            case 8:
                                valW.Warning = "Too High Tension!";
                                break;
                            case 16:
                                valW.Warning = "Emergency High Tension - risk of accident!";
                                break;
                            case 64:
                                valW.Warning = "The sensor is damaged or the connection with him is interrupted!";
                                break;
                        }

                        tensionWarningsDto.Add(valW);
                    }
                }
                Console.WriteLine($"Records in tensionAllDto : {tensionAllDto.Count}");
                Console.WriteLine($"Records in tensionWarningsDto : {tensionWarningsDto.Count}");
                Console.WriteLine();
            }

        }


    }
}
