namespace Excavators.Data.SeedSensorDatas
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Excavators.Models.DTO;
    using Newtonsoft.Json;

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

                foreach (var item in tsdPrepare)
                {
                    var val = new TempAllDto();

                    val.SensorName = $"TempSensor {item.TempSensorId} - {item.Description}";
                    val.Temperature = $"{item.Temperature:F2} °C";
                    val.TimeCollected = item.DTCollected.ToString("yyyy-MM-dd  hh:mm:ss");
                    tempAllDto.Add(val);

                    if (item.Status > 1)
                    {
                        var valW = new TempWarningsDto();

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

                Console.WriteLine($"Create temperature JSON files...");
                string tempAllDtoJson = JsonConvert.SerializeObject(tempAllDto, Formatting.Indented);
                string tempWarningsDtoJson = JsonConvert.SerializeObject(tempWarningsDto, Formatting.Indented);
                File.WriteAllText("../../../ExportJson/tempAllDto.json", tempAllDtoJson);
                File.WriteAllText("../../../ExportJson/tempWarningsDto.json", tempWarningsDtoJson);

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


                foreach (var item in csdPrepare)
                {
                    var val = new CurrentAllDto();

                    val.SensorName = $"CurrentSensor {item.CurrentSensorId} - {item.Description}";
                    val.Current = $"{item.Current:F2} A";
                    val.TimeCollected = item.DTCollected.ToString("yyyy-MM-dd  hh:mm:ss");
                    currentAllDto.Add(val);

                    if (item.Status > 1)
                    {
                        var valW = new CurrentWarningsDto();

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

                Console.WriteLine($"Create current JSON files...");
                string currentAllDtoJson = JsonConvert.SerializeObject(currentAllDto, Formatting.Indented);
                string currentWarningsDtoJson = JsonConvert.SerializeObject(currentWarningsDto, Formatting.Indented);
                File.WriteAllText("../../../ExportJson/currentAllDto.json", currentAllDtoJson);
                File.WriteAllText("../../../ExportJson/currentWarningsDto.json", currentWarningsDtoJson);

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

                foreach (var item in ssdPrepare)
                {
                    var val = new SpeedAllDto();

                    val.SensorName = $"SpeedSensor {item.SpeedSensorId} - {item.Description}";
                    val.Speed = $"{item.Speed:F2} m/s";
                    val.TimeCollected = item.DTCollected.ToString("yyyy-MM-dd  hh:mm:ss");
                    speedAllDto.Add(val);

                    if (item.Status > 1)
                    {
                        var valW = new SpeedWarningsDto();

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

                Console.WriteLine($"Create speed JSON files...");
                string speedAllDtoJson = JsonConvert.SerializeObject(speedAllDto, Formatting.Indented);
                string speedWarningsDtoJson = JsonConvert.SerializeObject(speedWarningsDto, Formatting.Indented);
                File.WriteAllText("../../../ExportJson/speedAllDto.json", speedAllDtoJson);
                File.WriteAllText("../../../ExportJson/speedWarningsDto.json", speedWarningsDtoJson);
                
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

                foreach (var item in tsdPrepare)
                {
                    var val = new TensionAllDto();

                    val.SensorName = $"TensionSensor {item.TensionSensorId} - {item.Description}";
                    val.Tension = $"{item.Tension:F3} t";
                    val.TimeCollected = item.DTCollected.ToString("yyyy-MM-dd  hh:mm:ss");
                    tensionAllDto.Add(val);

                    if (item.Status > 1)
                    {
                        var valW = new TensionWarningsDto();

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

                Console.WriteLine($"Create tension JSON files...");
                string tensionAllDtoJson = JsonConvert.SerializeObject(tensionAllDto, Formatting.Indented);
                string tensionWarningsDtoJson = JsonConvert.SerializeObject(tensionWarningsDto, Formatting.Indented);
                File.WriteAllText("../../../ExportJson/tensionAllDto.json", tensionAllDtoJson);
                File.WriteAllText("../../../ExportJson/tensionWarningsDto.json", tensionWarningsDtoJson);

                Console.WriteLine($"Records in tensionAllDto : {tensionAllDto.Count}");
                Console.WriteLine($"Records in tensionWarningsDto : {tensionWarningsDto.Count}");
                Console.WriteLine();
            }

        }

        public static void SetDataToVolumeDtos()
        {
            using (var ctx = new ExcavatorsContext())
            {
                Console.WriteLine("Set Data to Volume DTOs...");
                var volumeAllDto = new List<VolumeAllDto>();
                var volumeWarningsDto = new List<VolumeWarningsDto>();

                var vsdPrepare = ctx.VolumeSensorDatas
                    .Include("VolumeSensor")
                    .Select(s => new
                    {
                        s.DTCollected,
                        s.Volume,
                        s.VolumeSensorId,
                        Description = s.VolumeSensor.Description,
                        s.Status
                    });

                foreach (var item in vsdPrepare)
                {
                    var val = new VolumeAllDto();

                    val.SensorName = $"VolumeSensor {item.VolumeSensorId} - {item.Description}";
                    val.Volume = $"{item.Volume:F3} m³/hour";
                    val.TimeCollected = item.DTCollected.ToString("yyyy-MM-dd  hh:mm:ss");
                    volumeAllDto.Add(val);

                    if (item.Status > 1)
                    {
                        var valW = new VolumeWarningsDto();

                        valW.SensorName = val.SensorName;
                        valW.Volume = val.Volume;
                        valW.TimeCollected = val.TimeCollected;
                        valW.Warning = "";

                        switch (item.Status)
                        {
                            case 64:
                                valW.Warning = "The sensor is damaged or the connection with him is interrupted!";
                                break;
                        }

                        volumeWarningsDto.Add(valW);
                    }
                }

                Console.WriteLine($"Create volume JSON files...");
                string volumeAllDtoJson = JsonConvert.SerializeObject(volumeAllDto, Formatting.Indented);
                string volumeWarningsDtoJson = JsonConvert.SerializeObject(volumeWarningsDto, Formatting.Indented);
                File.WriteAllText("../../../ExportJson/volumeAllDto.json", volumeAllDtoJson);
                File.WriteAllText("../../../ExportJson/volumeWarningsDto.json", volumeWarningsDtoJson);
                
                Console.WriteLine($"Records in volumeAllDto : {volumeAllDto.Count}");
                Console.WriteLine($"Records in volumeWarningsDto : {volumeWarningsDto.Count}");
                Console.WriteLine();
            }
        }

        public static void SetDataToShiftingDtos()
        {
            using (var ctx = new ExcavatorsContext())
            {
                Console.WriteLine("Set Data to Shifting DTOs...");
                var shiftingAllDto = new List<ShiftingAllDto>();
                var shiftingWarningsDto = new List<ShiftingWarningsDto>();

                var ssdPrepare = ctx.ShiftingSensorDatas
                    .Include("ShiftingSensor")
                    .Select(s => new
                    {
                        s.DTCollected,
                        s.IsShifted,
                        s.ShiftingSensorId,
                        Description = s.ShiftingSensor.Description,
                        s.Status
                    });

                foreach (var item in ssdPrepare)
                {
                    var val = new ShiftingAllDto();

                    val.SensorName = $"ShiftingSensor {item.ShiftingSensorId} - {item.Description}";
                    val.IsShifted = item.IsShifted ? "Belt is shifted!" : "Belt is OK";
                    val.TimeCollected = item.DTCollected.ToString("yyyy-MM-dd  hh:mm:ss");
                    shiftingAllDto.Add(val);

                    if (item.Status > 1)
                    {
                        var valW = new ShiftingWarningsDto();

                        valW.SensorName = val.SensorName;
                        valW.IsShifted = val.IsShifted;
                        valW.TimeCollected = val.TimeCollected;
                        valW.Warning = "";

                        switch (item.Status)
                        {
                            case 128:
                                valW.Warning = "Attention: the belt is shifted and can be damaged!";
                                break;
                        }

                        shiftingWarningsDto.Add(valW);
                    }
                }

                Console.WriteLine($"Create shifting JSON files...");
                string shiftingAllDtoJson = JsonConvert.SerializeObject(shiftingAllDto, Formatting.Indented);
                string shiftingWarningsDtoJson = JsonConvert.SerializeObject(shiftingWarningsDto, Formatting.Indented);
                File.WriteAllText("../../../ExportJson/shiftingAllDto.json", shiftingAllDtoJson);
                File.WriteAllText("../../../ExportJson/shiftingWarningsDto.json", shiftingWarningsDtoJson);

                Console.WriteLine($"Records in shiftingAllDto : {shiftingAllDto.Count}");
                Console.WriteLine($"Records in shiftingWarningsDto : {shiftingWarningsDto.Count}");
                Console.WriteLine();
            }

        }


        public static List<CurrentGrafDto> GetCurrentDataById(int currentId)
        {
            List<CurrentGrafDto> currentGrafDtos = new List<CurrentGrafDto>();

            using (var ctx = new ExcavatorsContext())
            {
                currentGrafDtos = ctx.CurrentSensorDatas
                    .Where(s => s.CurrentSensorId == currentId)
                    .Select(s => new CurrentGrafDto
                    {
                        Time = s.DTCollected,
                        Current = s.Current

                    }).ToList();

                string currentGrafDtosJson = JsonConvert.SerializeObject(currentGrafDtos, Formatting.Indented);
                File.WriteAllText("../../../ExportJson/currentGrafDto.json", currentGrafDtosJson);

            }
            return currentGrafDtos;
        }

    }
}
