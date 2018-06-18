using BooksApi.DataLayer;
using BooksApi.Domain.Interfaces;
using BooksApi.Domain.DataObjects;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using BooksApi.Domain.Extensions;

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
                throw new ArgumentException("只能輸入中英文字", "kind");
            }
        }

        public async Task<List<BookKind>> ReadBookKind(string kind = "")
        {
            if (Regex.IsMatch(kind, StringRegularPattrns.OnlyChineseAndEnglish))
            {
                var bookKinds = await _BookKindRepository.GetAllAsync();

                if (kind.HasValue())
                {
                    bookKinds = bookKinds.Where(m => m.Name.Contains(kind)).ToList();
                }

                return bookKinds;
            }
            else
            {
                throw new ArgumentException("只能輸入中英文字", "kind");
            }
        }

        public async Task<BookKind> ReadBookKindByGuid(string guid)
        {
            if(guid.HasValue())
            {
                BookKind bookKind = await _BookKindRepository.GetAsync(m => m.Guid == guid);

                return bookKind;
            }
            else
            {
                throw new ArgumentNullException("guid");
            }
        }

        public async Task DestroyBookKind(string guid)
        {
            if(guid.HasValue())
            {
                BookKind bookKind = await ReadBookKindByGuid(guid);

                if(bookKind != null)
                {
                    await _BookKindRepository.DeleteAsync(bookKind);
                }
                else
                {
                    throw new ArgumentException($"根據索引鍵{guid}找不到資料");
                }
            }
            else
            {
                throw new ArgumentNullException("guid");
            }
        }

        public async Task UpdateBookKind(BookKind bookKind)
        {
            if(bookKind != null)
            {
                await _BookKindRepository.UpdateAsync(bookKind);
            }
            else
            {
                throw new ArgumentNullException("bookKind");
            }
        }
    }
}