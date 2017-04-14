using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excavators.Models;

namespace Excavators.Data.ImportExcavators
{
    public static class ImportRs2000
    {
        public static void CreateRs2000()
        {
            var context = new ExcavatorsContext();
            int exId = AddExcavator();
            int rwId = AddRotorWheel(exId);




        }

        public static int AddExcavator()
        {
            using (var ctx = new ExcavatorsContext())
            {
                Excavator item = new Excavator()
                {
                    Name = "Rs2000 N243",
                    Type = "Rs2000",
                    Location = "MMI, Rudnik Troyanovo-Sever, RTNK-5"
                };
                ctx.Excavators.Add(item);
                ctx.SaveChanges();
                return item.Id;
            }
        }


        public static int AddRotorWheel(int exId)
        {
            using (var ctx = new ExcavatorsContext())
            {
                RotorWheel item = new RotorWheel()
                {
                    Name = "RW for Rs2000 N243",
                    ExcavatorId = exId,
                };
                ctx.RotorWheels.Add(item);
                ctx.SaveChanges();
                return item.Id;
            }

        }




        public static void AddBelt()
        {
            using (var ctx = new ExcavatorsContext())
            {
                RotorWheel item = new RotorWheel()
                {
                    Name = "RW for Rs2000 N243",
                    ExcavatorId = ctx.Excavators.SingleOrDefault(e => e.Name == "Rs2000 N243").Id,
                };
                ctx.RotorWheels.Add(item);
                ctx.SaveChanges();
            }

        }





        


    }
}
