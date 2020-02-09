using System.Linq;

namespace InMemoryDatabase.Models
{
    public interface ILibraryRepository
    {
        public IQueryable<Book> Books { get; }
        public IQueryable<Author> Authors { get; }

        void Add<EntityType>(EntityType entity);

        void SaveChanges();
    }
}
