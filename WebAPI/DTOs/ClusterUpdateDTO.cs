namespace WebAPI.DTOs
{
    public class ClusterUpdateDTO
    {
        public string? Denominazione { get; set; }
        public ICollection<ClusterStuttureUpdateDTO>? ClusterStrutture { get; set; }
        public ICollection<ClusterUtentiUpdateDTO>? ClusterUtenti { get; set; }


    }
}
