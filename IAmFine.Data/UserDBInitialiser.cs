
using IAmFine.Data;

namespace IAmFine.Data
{
    public class UserDBInitialiser : System.Data.Entity.DropCreateDatabaseAlways<AmFineContext>
    {
        protected override void Seed(AmFineContext context)
        {
            context.Users.AddRange(new []
            {
                new User
                {
                    FirstName = "Joe", LastName = "Bloggs"
                },
                new User
                {
                    FirstName = "John", LastName = "Bloggs"
                },
                new User
                {
                    FirstName = "Anne", LastName = "Bloggs"
                }

            });

            context.SaveChanges();
        }
    }

}
