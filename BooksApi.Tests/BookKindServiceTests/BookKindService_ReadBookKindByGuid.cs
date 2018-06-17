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
    public class BookKindService_ReadBookKindByGuid : IClassFixture<DatabaseFixture>
    {
        private DatabaseFixture _databaseFixture { get; set; }

        public BookKindService_ReadBookKindByGuid(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
        }

        [Fact]
        public void ReadBookKindByGuid_QuerySuccess()
        {
             //arrange
            BookKindService service = new BookKindService(
                new GenericRepository<BookKind>(
                    _databaseFixture.DbContext
                )
            );

            //act
            var result = service.ReadBookKindByGuid("79bd9ef9-3ac8-4e70-95b6-33d5af9f95a3").Result;

            //assert
            Assert.NotNull(result);

            
        }
    }
}