using Microsoft.EntityFrameworkCore;
using System;
using BooksApi.DataLayer;

namespace BooksApi.Tests
{
    public class DatabaseFixture:IDisposable
    {
        public BooksDbContext DbContext { get; private set; }

        public DatabaseFixture()
        {
            this.DbContext = new BooksDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=DataBase\\TestBooks.db").Options);
            this.DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}