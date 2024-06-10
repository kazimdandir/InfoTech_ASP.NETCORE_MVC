using NuGet.Protocol.Core.Types;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Runtime.ConstrainedExecution;

namespace IA_CoreMVC_Repository_09062024.Models
{
    public interface IRepository<T> where T : class
    {
        //C# GenericRepository, bir ORM (Object-Relational Mapping) aracılığıyla veritabanı işlemlerini yapmak için genel bir sınıf yapılandırmasıdır. Genellikle Entity Framework, NHibernate veya Dapper gibi ORM araçlarıyla kullanılır.

        //Bu sınıf yapısı, temel CRUD(Create, Read, Update, Delete) işlemlerinin gerçekleştirilebileceği genel bir yapı sağlar.Böylece, veritabanı işlemlerini yapmak için her bir entity için ayrı bir repository sınıfı yazmak yerine, GenericRepository sınıfından türetilecek bir sınıf kullanarak kod tekrarını önleyebilirsiniz.

        //https://medium.com/@smtcoder/c-generic-repository-nedir-art%C4%B1lar%C4%B1-ve-eksileri-nelerdir-4f9ea8306b28

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();

        void Save();
    }
}
