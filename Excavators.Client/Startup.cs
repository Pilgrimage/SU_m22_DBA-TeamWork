namespace Excavators.Client
{
    using Excavators.Data;
    using Excavators.Models;
    using Excavators.Data.ImportExcavators;

    class Startup
    {
        static void Main()
        {
            // Initialize database
            //====================

            //using (var ctx = new ExcavatorsContext())
            //{
            //    ctx.Database.Initialize(true);
            //}


            // Seed Inventar in "...Type" models
            //==================================

            //Seeds.SeedMotorTypes();
            //Seeds.SeedReducerTypes();
            //Seeds.SeedCurrentSensorTypes();
            //Seeds.SeedTempSensorTypes();
            //Seeds.SeedSpeedSensorTypes();
            //Seeds.SeedVolumeSensorTypes();
            //Seeds.SeedTensionSensorTypes();
            //Seeds.SeedShiftingSensorTypes();


            // Create excavator RS2000 B243
            //=============================

            ImportRs2000.CreateRs2000();


        }
    }
}
