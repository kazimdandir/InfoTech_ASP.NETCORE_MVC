namespace IA_CoreMVC_Repository_09062024.Models
{
    public class DBSingleton
    {
        private static TelefonDbContext instance = null;

        public static TelefonDbContext GetInstance()
        {
            if (instance == null)
            {
                instance = new TelefonDbContext();
            }

            return instance;
        }
    }
}
