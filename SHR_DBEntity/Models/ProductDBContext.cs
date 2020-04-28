using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductManagementDBEntity.Models
{
    public partial class ProductDBContext : DbContext
    {
        public ProductDBContext()
        {
        }

        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JC6IUA3\\SQLEXPRESS;Database=ProductDB;User Id=sa; Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Productid)
                    .HasName("PK__Products__2D172D3214D924EF");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Createddatetime)
                    .HasColumnName("createddatetime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Noofitems).HasColumnName("noofitems");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnName("productname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__Products__userid__1B0907CE");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__UserDeta__CBA1B257AC76A7C7");

                entity.HasIndex(e => e.Contactnumber)
                    .HasName("UQ__UserDeta__DF8655CCFA2B8605")
                    .IsUnique();

                entity.HasIndex(e => e.Emailid)
                    .HasName("UQ__UserDeta__8734520B606BB246")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__UserDeta__F3DBC5723FCB8D30")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Contactnumber)
                    .IsRequired()
                    .HasColumnName("contactnumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Registereddatetime)
                    .HasColumnName("registereddatetime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
