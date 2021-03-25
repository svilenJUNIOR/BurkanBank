using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BurkanBankFinalEdition.database
{
    public partial class naMalkiqBankataContext : DbContext
    {
        public naMalkiqBankataContext()
        {
        }

        public naMalkiqBankataContext(DbContextOptions<naMalkiqBankataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=;Integrated Security=true;Database=naMalkiqBankata");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account__ClientI__2A4B4B5E");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.LastName, "UQ__Client__7449F3990B25AEBF")
                    .IsUnique();

                entity.HasIndex(e => e.Password, "UQ__Client__87909B152BD38439")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Client__A9D10534B192BAF8")
                    .IsUnique();

                entity.HasIndex(e => e.FirstName, "UQ__Client__B31331C94F0A37D0")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
