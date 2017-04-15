namespace Excavators.Data.ImportExcavators
{
    using System;

    public static class ImportRs1200
    {
        public static void CreateRs1200()
        {
            Console.WriteLine("Creating Rs1200 B239...");

            // Add Excavator
            int exId = Utilities.AddExcavator("Rs1200 B239", "Rs1200", "MMI, Rudnik Troyanovo-Sever, RTNK-4");

            // Add Rotor Wheel
            int rwId = Utilities.AddRotorWheel(exId);
            int mrgRwId = Utilities.AddMrGroup(rwId, "500kW", "MRGroup of RW", "toRW");
            Utilities.AddSensorsToMRGroup(mrgRwId);

            // Add Rotor Belt
            int rotorBeltId = Utilities.AddBeltWithSensors(exId, "Rotor Belt");
            int driveDrumRbId = Utilities.AddDrumWithSensors(rotorBeltId, "Drive Drum of Rotor Belt");
            int leftMrgDdRbId = Utilities.AddMrGroup(driveDrumRbId, "230kW", "Left MRGroup of Rotor Belt", "toDrum");
            int rightMrgDdRbId = Utilities.AddMrGroup(driveDrumRbId, "230kW", "Right MRGroup of Rotor Belt", "toDrum");
            Utilities.AddSensorsToMRGroup(leftMrgDdRbId);
            Utilities.AddSensorsToMRGroup(rightMrgDdRbId);
            int passiveDrumRbId = Utilities.AddDrumWithSensors(rotorBeltId, "Passive Drum of Rotor Belt");

            // Add Middle Belt
            int middleBeltId = Utilities.AddBeltWithSensors(exId, "Middle Belt");
            int driveDrumMbId = Utilities.AddDrumWithSensors(middleBeltId, "Drive Drum of Middle Belt");
            int leftMrgDdMbId = Utilities.AddMrGroup(driveDrumMbId, "380kW", "Left MRGroup of Middle Belt", "toDrum");
            Utilities.AddSensorsToMRGroup(leftMrgDdMbId);
            int passiveDrumMbId = Utilities.AddDrumWithSensors(middleBeltId, "Passive Drum of Middle Belt");

            // Add Unload Belt
            int unloadBeltId = Utilities.AddBeltWithSensors(exId, "Unload Belt");
            int driveDrumUbId = Utilities.AddDrumWithSensors(unloadBeltId, "Drive Drum of Unload Belt");
            int leftMrgDdUbId = Utilities.AddMrGroup(driveDrumUbId, "180kW", "Left MRGroup of Unload Belt", "toDrum");
            Utilities.AddSensorsToMRGroup(leftMrgDdUbId);
            int passiveDrumUbId = Utilities.AddDrumWithSensors(unloadBeltId, "Passive Drum of Unload Belt");

        }

    }
}
