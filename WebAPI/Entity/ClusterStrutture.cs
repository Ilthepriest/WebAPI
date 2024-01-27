namespace WebAPI.Entity
{
    public partial class ClusterStrutture
    {
        public long ID { get; set; }
        public long IDCluster { get; set; }
        public long IDStruttura { get; set; }
        public long Ordine { get; set; }

        public virtual Cluster Cluster { get; set; } = null!;
    }
}
