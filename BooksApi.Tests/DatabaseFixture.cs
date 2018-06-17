using Microsoft.EntityFrameworkCore;
using System;
using BooksApi.DataLayer;

namespace BooksApi.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public BooksDbContext DbContext { get; private set; }

        public DatabaseFixture()
        {
            var sqlitePath = @"..\..\..\..\BooksApi.HttpHost\Database\TestBooks.db";
            this.DbContext = new BooksDbContext(
                new DbContextOptionsBuilder().UseSqlite($"Data Source={sqlitePath}").Options);
            this.DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}