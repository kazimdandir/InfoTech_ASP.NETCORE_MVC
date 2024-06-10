using System.Runtime.ConstrainedExecution;

namespace IA_CoreMVC_Repository_09062024.Models
{
    public class DBSingleton
    {
        //Bu tasarım kalıbı aynı nesnenin her bir istek için bellekte yeniden oluşturulmasını önlemek amacı ile kullanılmaktadır.Peki neden böyle bir şeye ihtiyaç duyuyoruz?Çünkü yazdığımız uygulamalarda tanımladığımız nesneler bellekte yer kaplar ve her seferinde aynı nesneyi oluşturmak performans kaybına sebep olacaktır.Örneğin; veritabanı bağlantıları yada dosya işlemleri.

        //Singleton ile oluşturulan nesneler tek bir örnek üzerinde kalır, her istemci bu örneği kullanır.Aynı zamanda nesnenin kopyalanmasını yada yeni bir nesne oluşturmasını engeller ve nesneye ihtiyaç duyulduğunda o nesnenin daha önceden oluşturulan örneği çağrılır.

        //https://medium.com/@SevgiAlkan/singleton-pattern-nedir-1c2d7d09a3c

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
