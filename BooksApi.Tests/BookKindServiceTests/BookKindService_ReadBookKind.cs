using Xunit;
using BooksApi.DataLayer;
using BooksApi.BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Moq;
using BooksApi.Tests;
using BooksApi.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Tests.BookKindServiceTests
{
    public class BookKindService_ReadBookKind : IClassFixture<DatabaseFixture>
    {
        private DatabaseFixture _databaseFixture { get; set; }

        public BookKindService_ReadBookKind(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
        }

        [Fact]
        public void ReadBookKind_OnlyQueryForChineseAndEnglish()
        {
            //arrange
            BookKindService service = new BookKindService(
                new StubRepository<BookKind>()
            );
            string kind = "%#$^$&&\\'\"{}#";

            //act
            Func<Task> act = async () => await service.ReadBookKind(kind);

            //assert
            Assert.ThrowsAsync<ArgumentException>(act);
        }

        [Fact]
        public void ReadBookKind_QuerySuccess()
        {
            //arrange
            BookKindService service = new BookKindService(
                new GenericRepository<BookKind>(
                    _databaseFixture.DbContext
                )
            );
            string kind = "WebApi";
            service.AddBookKind(kind).Wait();

            //act
            var result = service.ReadBookKind(kind).Result;

            //assert
            Assert.True(result.Where(m => m.Name == kind).Any());

        }
    }
}