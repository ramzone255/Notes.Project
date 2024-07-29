namespace Notes.Identity.Data
{
    public class DbInitializer
    {
        public static void Initialze(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
