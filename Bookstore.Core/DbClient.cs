using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Book> _books;
        public DbClient(IOptions<BookstoreDbContext> booksotoreDbContext)
        {
            var client = new MongoClient(booksotoreDbContext.Value.Connection_String);
            var database = client.GetDatabase(booksotoreDbContext.Value.Database_Name);
            _books = database.GetCollection<Book>(booksotoreDbContext.Value.Books_Collection_Name);
        }
        public IMongoCollection<Book> GetBooksCollection() => _books;
    }
}
