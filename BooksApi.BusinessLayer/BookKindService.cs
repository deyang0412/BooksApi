using BooksApi.DataLayer;
using BooksApi.Domain.Interfaces;

namespace BooksApi.BusinessLayer
{
    public class BookKindService
    {
        private IRepository<BookKind> _BookKindRepository { get; set; }

        public BookKindService(IRepository<BookKind> repository)
        {
            _BookKindRepository = repository;
        }
    }
}