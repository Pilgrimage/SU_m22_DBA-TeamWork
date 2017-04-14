namespace Excavators.Client
{
    using Excavators.Data;
    using Excavators.Models;
    using Excavators.Data.ImportExcavators;

    class Startup
    {
        static void Main()
        {
            using (var ctx = new ExcavatorsContext())
            {
                ctx.Database.Initialize(true);
            }

            // Seed Inventar in "...Type" models
            Seeds.SeedMotorTypes();
            Seeds.SeedReducerTypes();
            Seeds.SeedCurrentSensorTypes();
            Seeds.SeedTempSensorTypes();
            Seeds.SeedSpeedSensorTypes();
            Seeds.SeedVolumeSensorTypes();
            Seeds.SeedTensionSensorTypes();
            Seeds.SeedShiftingSensorTypes();
        }
    }
}
