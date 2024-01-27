namespace WebAPI.DTOs
{
    public class ClusterDTO
    {
        public long Id { get; set; }
        public string? Denominazione { get; set; }

        public ICollection<ClusterStruttureDTO>? ClusterStrutture { get; set; }
        public ICollection<ClusterUtentiDTO>? ClusterUtenti { get; set; }

    }
}
