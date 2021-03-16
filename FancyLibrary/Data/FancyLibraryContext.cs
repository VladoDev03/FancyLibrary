using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.Entities
{
    public partial class FancyLibraryContext : IdentityDbContext<User, Role, int>
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
        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBook> UsersBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=T0rta@s@marmaladi7;database=fancy_library_official;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.HasIndex(e => e.CountryId, "country_id");

                entity.HasIndex(e => e.Nickname, "nickname")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .HasColumnName("nickname");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("authors_ibfk_1");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.HasIndex(e => e.AuthorId, "author_id");

                entity.HasIndex(e => e.InspiredById, "inspired_by_id");

                entity.HasIndex(e => e.Title, "title")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("genre");

                entity.Property(e => e.InspiredById).HasColumnName("inspired_by_id");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");

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

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "phone")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<LogData>(entity =>
            {
                entity.ToTable("log_data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsOnline)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_online");

                entity.Property(e => e.LastTimeLoggedIn)
                    .HasColumnType("date")
                    .HasColumnName("last_time_logged_in");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("register_date");

                entity.Property(e => e.TimesLoggedIn).HasColumnName("times_logged_in");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.ContactId, "contact_id")
                    .IsUnique();

                entity.HasIndex(e => e.CountryId, "country_id");

                entity.HasIndex(e => e.LogDataId, "log_data_id")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UserName")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.LogDataId).HasColumnName("log_data_id");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("UserName");

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.ContactId)
                    .HasConstraintName("users_ibfk_1");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("users_ibfk_3");

                entity.HasOne(d => d.LogData)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.LogDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_ibfk_2");
            });

            modelBuilder.Entity<UserBook>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BookId })
                    .HasName("PRIMARY");

                entity.ToTable("users_books");

                entity.HasIndex(e => e.BookId, "book_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.UsersBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_books_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersBooks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_books_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
