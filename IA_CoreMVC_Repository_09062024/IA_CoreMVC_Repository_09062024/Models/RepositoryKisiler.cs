namespace IA_CoreMVC_Repository_09062024.Models
{
    public class RepositoryKisiler : IRepository<Kisiler>
    {
        private readonly TelefonDbContext db;

        public RepositoryKisiler()
        {
            db = DBSingleton.GetInstance();
        }

        public RepositoryKisiler(TelefonDbContext context)
        {
            db = context;
        }

        public void Add(Kisiler entity)
        {
            db.Kisilers.Add(entity);
        }

        public void Delete(Kisiler entity)
        {
            db.Kisilers.Remove(GetById(entity.KisiID));
        }

        public IEnumerable<Kisiler> GetAll()
        {
            return db.Kisilers.ToList();
        }

        public Kisiler GetById(int id)
        {
            return db.Kisilers.Where(x => x.KisiID == id).First();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Kisiler entity)
        {
            db.Entry(GetById(entity.KisiID)).CurrentValues.SetValues(entity);
        }
    }
}
