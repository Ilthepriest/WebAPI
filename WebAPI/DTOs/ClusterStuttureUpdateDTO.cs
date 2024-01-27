using WebAPI.Entity;

namespace WebAPI.DTOs
{
    public class ClusterStuttureUpdateDTO
    {
        public long Id { get; set; }
        public long IDStruttura { get; set; }

        public long IDCluster { get; set; }

        public long Ordine { get; set; }



    }
}
