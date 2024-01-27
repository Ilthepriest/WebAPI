using Microsoft.EntityFrameworkCore;
using WebAPI.Entity;

namespace WebAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cluster>(entity =>
            {
                entity.ToTable("Cluster");

                entity.Property(e => e.Denominazione).HasMaxLength(100);
            });

            modelBuilder.Entity<ClusterStrutture>(entity =>
            {
                entity.ToTable("ClusterStrutture");

                entity.HasOne(d => d.Cluster)
                    .WithMany(p => p.ClusterStrutture)
                    .HasForeignKey(d => d.IDCluster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClusterStrutture_Cluster");
            });

            modelBuilder.Entity<ClusterUtenti>(entity =>
            {
                entity.ToTable("ClusterUtenti");

                entity.HasOne(d => d.Cluster)
                    .WithMany(p => p.ClusterUtenti)
                    .HasForeignKey(d => d.IDCluster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClusterUtenti_Cluster");
            });


            //seed
            var cluster1 = new Cluster()
            {
                ID = 1,
                Denominazione = "ASD"
            };

            var clusterStruttura1 = new ClusterStrutture()
            {
                ID = 1,
                IDCluster = 1,
                IDStruttura = 20,
                Ordine = 0
            };

            var clusterStruttura2 = new ClusterStrutture()
            {
                ID = 2,
                IDCluster = 1,
                IDStruttura = 34,
                Ordine = 0
            };

            var clusterUtente1= new ClusterUtenti()
            {
                ID = 1,
                IDCluster = 1,
                IDUtente = 18
            };

            modelBuilder.Entity<Cluster>().HasData(cluster1);
            modelBuilder.Entity<ClusterStrutture>().HasData(clusterStruttura1, clusterStruttura2);
            modelBuilder.Entity<ClusterUtenti>().HasData(clusterUtente1);


        }

        public DbSet<Cluster> Cluster { get; set; }
        public DbSet<ClusterStrutture> ClusterStrutture { get; set; }
        public DbSet<ClusterUtenti> ClusterUtenti { get; set; }
    }
}
