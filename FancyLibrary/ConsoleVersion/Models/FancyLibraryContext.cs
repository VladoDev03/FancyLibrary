using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsoleVersion.Models
{
    public partial class FancyLibraryContext : DbContext
    {
        public FancyLibraryContext()
        {
        }

        public FancyLibraryContext(DbContextOptions<FancyLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<LogData> LogData { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserBook> UsersBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=T0rta@s@marmaladi7;database=fancy_library");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.HasIndex(e => e.CountryId)
                    .HasName("country_id");

                entity.HasIndex(e => e.Nickname)
                    .HasName("nickname")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("authors_ibfk_1");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("author_id");

                entity.HasIndex(e => e.InspiredById)
                    .HasName("inspired_by_id");

                entity.HasIndex(e => e.Title)
                    .HasName("title")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnName("genre")
                    .HasMaxLength(50);

                entity.Property(e => e.InspiredById).HasColumnName("inspired_by_id");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("books_ibfk_1");

                entity.HasOne(d => d.InspiredBy)
                    .WithMany(p => p.InverseInspiredBy)
                    .HasForeignKey(d => d.InspiredById)
                    .HasConstraintName("books_ibfk_2");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contacts");

                entity.HasIndex(e => e.Email)
                    .HasName("email")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("phone")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LogData>(entity =>
            {
                entity.ToTable("log_data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsOnline)
                    .HasColumnName("is_online")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.LastTimeLoggedIn)
                    .HasColumnName("last_time_logged_in")
                    .HasColumnType("date");

                entity.Property(e => e.RegisterDate)
                    .HasColumnName("register_date")
                    .HasColumnType("date");

                entity.Property(e => e.TimesLoggedIn).HasColumnName("times_logged_in");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.ContactId)
                    .HasName("contact_id")
                    .IsUnique();

                entity.HasIndex(e => e.CountryId)
                    .HasName("country_id");

                entity.HasIndex(e => e.LogDataId)
                    .HasName("log_data_id")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LogDataId).HasColumnName("log_data_id");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.Users)
                    .HasForeignKey<User>(d => d.ContactId)
                    .HasConstraintName("users_ibfk_1");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("users_ibfk_3");

                entity.HasOne(d => d.LogData)
                    .WithOne(p => p.Users)
                    .HasForeignKey<User>(d => d.LogDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_ibfk_2");
            });

            modelBuilder.Entity<UserBook>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BookId })
                    .HasName("PRIMARY");

                entity.ToTable("users_books");

                entity.HasIndex(e => e.BookId)
                    .HasName("book_id")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.HasOne(d => d.Book)
                    .WithOne(p => p.UsersBooks)
                    .HasForeignKey<UserBook>(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_books_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UsersBooks)
                    .HasForeignKey<UserBook>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_books_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
