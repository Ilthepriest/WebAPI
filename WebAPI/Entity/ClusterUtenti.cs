namespace WebAPI.Entity
{
    public partial class ClusterUtenti
    {
        public long ID { get; set; }
        public long IDCluster { get; set; }
        public long IDUtente { get; set; }

        public virtual Cluster Cluster { get; set; } = null!;
    }
}
