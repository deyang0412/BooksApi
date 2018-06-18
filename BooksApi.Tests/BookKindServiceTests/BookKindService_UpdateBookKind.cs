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
    public class BookKindService_UpdateBookKind
    {
        [Fact]
        public void UpdateBookKind_NullInstance()
        {
            //arrange
            var service = new BookKindService(
                new StubRepository<BookKind>()
            );
            BookKind bookKind = null;

            //act
            Func<Task> act = async () => await service.UpdateBookKind(bookKind);

            //assert
            Assert.ThrowsAsync<ArgumentNullException>(act);
        }
    }
}