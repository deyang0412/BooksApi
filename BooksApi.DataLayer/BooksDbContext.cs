using Microsoft.EntityFrameworkCore;

namespace BooksApi.DataLayer
{
    public class BooksDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookKind> BookKinds { get; set; }

        public DbSet<Inventory> Inventories { get; set; }
        public BooksDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasKey(m => m.Guid)
                        .HasName("PrimaryKey_UserGuid");
            modelBuilder.Entity<User>()
                        .Property(m => m.Guid)
                        .HasMaxLength(36);
            modelBuilder.Entity<User>()
                        .Property(m => m.Account)
                        .HasMaxLength(20)
                        .IsRequired();
            modelBuilder.Entity<User>()
                        .Property(m => m.Password)
                        .IsRequired()
                        .HasMaxLength(64);
            modelBuilder.Entity<User>()
                        .Property(m => m.Name)
                        .HasMaxLength(40);

            modelBuilder.Entity<BookKind>()
                        .HasKey(m => m.Guid);
            modelBuilder.Entity<BookKind>()
                        .Property(m => m.Guid)
                        .HasMaxLength(36);
            modelBuilder.Entity<BookKind>()
                        .Property(m => m.Name)
                        .HasMaxLength(20);
            modelBuilder.Entity<BookKind>()
                        .HasMany(m => m.Books)
                        .WithOne();


            modelBuilder.Entity<Book>()
                        .HasKey(m => m.Guid);
            modelBuilder.Entity<Book>()
                        .Property(m => m.Guid)
                        .HasMaxLength(36);
            modelBuilder.Entity<Book>()
                        .Property(m => m.ISBN)
                        .HasMaxLength(13)
                        .IsRequired();
            modelBuilder.Entity<Book>()
                        .Property(m => m.Name)
                        .HasMaxLength(50);
            modelBuilder.Entity<Book>()
                        .Property(m => m.Author)
                        .HasMaxLength(30);
            modelBuilder.Entity<Book>()
                        .Property(m => m.PublishDate);
            modelBuilder.Entity<Book>()
                        .Property(m => m.BookKindGuid)
                        .HasMaxLength(36);
            modelBuilder.Entity<Book>()
                        .HasOne(m => m.BookKind)
                        .WithMany(bk => bk.Books)
                        .HasForeignKey(m => m.BookKindGuid);
            modelBuilder.Entity<Book>()
                        .HasOne(m => m.Inventory)
                        .WithOne(I => I.Book)
                        .HasForeignKey<Inventory>(I => I.BookGuid);


            modelBuilder.Entity<Inventory>()
                        .HasKey(m => m.Guid);
            modelBuilder.Entity<Inventory>()
                        .Property(m => m.Guid)
                        .HasMaxLength(36);
            modelBuilder.Entity<Inventory>()
                        .Property(m => m.BookGuid)
                        .HasMaxLength(36)
                        .IsRequired(); 
            modelBuilder.Entity<Inventory>()
                        .Property(m => m.Quantity)
                        .HasDefaultValue(0);
            modelBuilder.Entity<Inventory>()
                        .Property(m => m.ReplenishDate)
                        .ValueGeneratedOnAddOrUpdate();      


            modelBuilder.Entity<Order>()
                        .HasKey(m => m.Guid);
            modelBuilder.Entity<Order>()
                        .Property(m => m.Guid)
                        .HasMaxLength(36);
            modelBuilder.Entity<Order>()
                        .HasOne(m => m.User)
                        .WithMany(u => u.Orders)
                        .HasForeignKey(m => m.UserGuid);
            modelBuilder.Entity<Order>()
                        .Property(m => m.OrderNo)
                        .HasMaxLength(10)
                        .IsRequired();
            modelBuilder.Entity<Order>()
                        .Property(m => m.Quantity)
                        .HasDefaultValue(1);
            modelBuilder.Entity<Order>()
                        .Property(m => m.OrderDate)
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>()
                        .Property(m => m.EstimateToDelivery)
                        .HasColumnName("ETD");

            
            modelBuilder.Entity<BookOrder>()
                        .HasKey(m => new { m.BookGuid,m.OrderGuid });
            modelBuilder.Entity<BookOrder>()
                        .HasOne(m => m.Book)
                        .WithMany(b => b.BookOrders)
                        .HasForeignKey(m => m.BookGuid);
            modelBuilder.Entity<BookOrder>()
                        .HasOne(m => m.Order)
                        .WithMany(o => o.BookOrders)
                        .HasForeignKey(m => m.OrderGuid);
        }
    }
}