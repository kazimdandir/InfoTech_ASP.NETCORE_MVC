using IA_CoreMVC_FluentAPI_Repository_Library.Models.Context;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Abstract
{
    public class DBSingleton
    {
        private static LibraryContext _instance = null;

        public static LibraryContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LibraryContext();
            }

            return _instance;
        }
    }
}
