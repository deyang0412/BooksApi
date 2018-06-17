using Xunit;
using BooksApi.DataLayer;
using BooksApi.BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Moq;
using BooksApi.Tests;
using BooksApi.Domain.Interfaces;

namespace BooksApi.Tests.BookKindServiceTests
{
    public class BookKindService_AddBookKind : IClassFixture<DatabaseFixture>
    {
        private DatabaseFixture _DatabaseFixture { get; set; }

        public BookKindService_AddBookKind(DatabaseFixture databaseFixture)
        {
            _DatabaseFixture = databaseFixture;
        }

        [Fact]
        public void AddBookKind_Characters()
        {
            //arrange
            BookKindService service = new BookKindService(
                new StubRepository<BookKind>()
            );
            string kind = "%#$^$&&\\'\"{}#";

            //act
            Func<Task> act = async () => await service.AddBookKind(kind);

            //assert
            Assert.ThrowsAsync<ArgumentException>(act);
        }

        [Fact]
        public void AddBookKind_ChineseAndEnglish()
        {
            //arrange
            string kind = "中文English";

            var repository = new Mock<StubRepository<BookKind>>();
            //repository.Setup(mock => mock.CreateAsync(bookKind));

            var service = new BookKindService(repository.Object);

            //act
            service.AddBookKind(kind).Wait();

            //assert
            repository.Verify(mock => mock.CreateAsync(It.Is<BookKind>(bk => bk.Name == kind)));
        }
    }
}