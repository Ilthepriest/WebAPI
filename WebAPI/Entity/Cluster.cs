using Newtonsoft.Json;

namespace WebAPI.Entity
{
    public partial class Cluster
    {
        public Cluster()
        {
            ClusterStrutture = new HashSet<ClusterStrutture>();
            ClusterUtenti = new HashSet<ClusterUtenti>();
        }

        public long ID { get; set; }
        public string Denominazione { get; set; } = null!;


        [JsonIgnore]
        public virtual ICollection<ClusterStrutture> ClusterStrutture { get; set; }

        [JsonIgnore]
        public virtual ICollection<ClusterUtenti> ClusterUtenti { get; set; }
    }
}
