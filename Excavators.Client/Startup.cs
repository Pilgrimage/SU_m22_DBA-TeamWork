using Excavators.Data;

namespace Excavators.Client
{
    class Startup
    {
        static void Main()
        {
            using (var ctx = new ExcavatorsContext())
            {
                ctx.Database.Initialize(true);
            }
        }
    }
}
