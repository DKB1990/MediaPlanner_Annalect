using Microsoft.EntityFrameworkCore;

namespace MediaPlanner.Database.Models
{
    public partial class MediaPlannerDBContext : DbContext
    {
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CampaignDetail> CampaignDetail { get; set; }
        public virtual DbSet<Channel> Channel { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=dbmedia.database.windows.net;Database=MediaPlannerDB;User ID=db_admin;Password=db@12345;Trusted_Connection=False;Encrypt=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.Property(e => e.Budget).HasColumnType("decimal(19, 6)");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Campaign__Client__5812160E");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Campaign__Countr__571DF1D5");
            });

            modelBuilder.Entity<CampaignDetail>(entity =>
            {
                entity.Property(e => e.Budget).HasColumnType("decimal(19, 6)");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignDetail)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK__CampaignD__Campa__5AEE82B9");
                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.CampaignDetail)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__CampaignD__Suppl__5BE2A6F2");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK__Supplier__Channe__5441852A");
            });
        }
    }
}
