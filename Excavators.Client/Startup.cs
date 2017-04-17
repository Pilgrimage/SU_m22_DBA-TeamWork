using System;
using Excavators.Data.SeedSensorDatas;

namespace Excavators.Client
{
    using Excavators.Data;
    using Excavators.Models;
    using Excavators.Data.ImportExcavators;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            // Initialize database
            //====================
            using (var ctx = new ExcavatorsContext())
            {
                ctx.Database.Initialize(true);
            }


            // Seed Inventar in "...Type" models
            //==================================
            using (var ctx = new ExcavatorsContext())
            {
                if (ctx.MotorTypes.Count() == 0)
                {
                    Seeds.SeedMotorTypes();
                    Seeds.SeedReducerTypes();
                    Seeds.SeedCurrentSensorTypes();
                    Seeds.SeedTempSensorTypes();
                    Seeds.SeedSpeedSensorTypes();
                    Seeds.SeedVolumeSensorTypes();
                    Seeds.SeedTensionSensorTypes();
                    Seeds.SeedShiftingSensorTypes();
                }
            };


            // Create excavators RS2000 B243 and Rs1200 B239
            //==============================================

            using (var ctx = new ExcavatorsContext())
            {
                if (ctx.Excavators.FirstOrDefault(n => n.Name == "Rs2000 B243") == null)
                {
                    ImportRs2000.CreateRs2000();
                }

                if (ctx.Excavators.FirstOrDefault(n => n.Name == "Rs1200 B239") == null)
                {
                    ImportRs1200.CreateRs1200();
                }
            };


            // Seed measurement's Values
            using (var ctx = new ExcavatorsContext())
            {
                if (!ctx.TempSensorDatas.Any())
                {
                    SeedMeasurementDatas.FillTempSensors();
                    SetDataToDto.SetDataToTempDtos();
                    // There are two tables (objects): 
                    // tempAllDto as List<TempAllDto>
                    // tempWarningsDto as List<TempWarningsDto>
                }

                if (!ctx.CurrentSensorDatas.Any())
                {
                    SeedMeasurementDatas.FillCurrentSensors();
                    SetDataToDto.SetDataToCurrentDtos();
                    // There are two tables (objects): 
                    // currentAllDto as List<CurrentAllDto>
                    // currentWarningsDto as List<CurrentWarningsDto>
                }

                if (!ctx.SpeedSensorDatas.Any())
                {
                    SeedMeasurementDatas.FillSpeedSensors();
                    SetDataToDto.SetDataToSpeedDtos();
                    // There are two tables (objects): 
                    // speedAllDto as List<SpeedAllDto>
                    // speedWarningsDto as List<SpeedWarningsDto>
                }

                if (!ctx.TensionSensorDatas.Any())
                {
                    SeedMeasurementDatas.FillTensionSensors();
                    SetDataToDto.SetDataToTensionDtos();
                    // There are two tables (objects): 
                    // tensionAllDto as List<TensionAllDto>
                    // tensionWarningsDto as List<TensionWarningsDto>
                }

                if (!ctx.VolumeSensorDatas.Any())
                {
                    //SeedMeasurementDatas.FillTensionSensors();
                    //SetDataToDto.SetDataToTensionDtos();
                    //// There are two tables (objects): 
                    //// tensionAllDto as List<TensionAllDto>
                    //// tensionWarningsDto as List<TensionWarningsDto>
                }

                if (!ctx.ShiftingSensorDatas.Any())
                {
                    //SeedMeasurementDatas.FillTensionSensors();
                    //SetDataToDto.SetDataToTensionDtos();
                    //// There are two tables (objects): 
                    //// tensionAllDto as List<TensionAllDto>
                    //// tensionWarningsDto as List<TensionWarningsDto>
                }


            }
        }
}
}
