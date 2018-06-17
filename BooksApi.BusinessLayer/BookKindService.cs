using BooksApi.DataLayer;
using BooksApi.Domain.Interfaces;
using BooksApi.Domain.DataObjects;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BooksApi.BusinessLayer
{
    public class BookKindService
    {
        private IRepository<BookKind> _BookKindRepository { get; set; }

        public BookKindService(IRepository<BookKind> repository)
        {
            _BookKindRepository = repository;
        }

        public async Task AddBookKind(string kind)
        {
            if (Regex.IsMatch(kind, StringRegularPattrns.OnlyChineseAndEnglish))
            {
                BookKind bookKind = new BookKind();
                bookKind.Guid = Guid.NewGuid().ToString();
                bookKind.Name = kind;

                await _BookKindRepository.CreateAsync(bookKind);
            }
            else
            {
                throw new ArgumentException("只能輸入中英文字","kind");
            }
        }
    }
}