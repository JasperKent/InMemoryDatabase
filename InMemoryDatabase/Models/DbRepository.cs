using System.Linq;

namespace InMemoryDatabase.Models
{
    public class DbRepository : ILibraryRepository
    {
        private readonly LibraryContext _db;

        public DbRepository(LibraryContext db)
        {
            _db = db;
        }

        public IQueryable<Book> Books => _db.Books;
        public IQueryable<Author> Authors => _db.Authors;

        public void Add<EntityType>(EntityType entity) => _db.Add(entity);
        public void SaveChanges() => _db.SaveChanges();
    }
}
