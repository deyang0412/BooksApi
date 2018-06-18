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
    public class BookKindService_DestroyBookKind
    {
        [Fact]
        public void DestroyBookKind_GuidIsEmpty()
        {
            //arrange
            var service = new BookKindService(
                new StubRepository<BookKind>()
            );
            var guid = string.Empty;

            //act
            Func<Task> act = async () => await service.DestroyBookKind(guid);

            //assert

            Assert.ThrowsAsync<ArgumentNullException>(act);
        }

        [Fact]
        public void DestroyBookKind_BookKindNotFound()
        {
            //arrange
            var service = new BookKindService(
                new StubRepository<BookKind>()
            );
            var guid = "112233";

            //act
            Func<Task> act = async () => await service.DestroyBookKind(guid);

            //assert

            Assert.ThrowsAsync<ArgumentException>(act);
        }
    }
}