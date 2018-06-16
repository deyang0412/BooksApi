using Xunit;
using BooksApi.DataLayer;
using BooksApi.BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Tests
{
    public class BookKindService_AddBookKind : IClassFixture<DatabaseFixture>
    {
        private DatabaseFixture _DatabaseFixture { get; set; }
        private BookKindService _Service { get; set; }

        public BookKindService_AddBookKind(DatabaseFixture databaseFixture)
        {
            _DatabaseFixture = databaseFixture;

            _Service = new BookKindService(
                new GenericRepository<BookKind>(_DatabaseFixture.DbContext));
        }

        
    }
}