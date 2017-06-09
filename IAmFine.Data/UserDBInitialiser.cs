
using IAmFine.Data;

namespace IAmFine.Data
{
    public class UserDBInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<AmFineContext>
    {
        protected override void Seed(AmFineContext context)
        {

        }
    }

}
