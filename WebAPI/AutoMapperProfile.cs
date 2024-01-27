using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Entity;

namespace WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cluster, ClusterDTO>().ReverseMap();
            CreateMap<ClusterStrutture, ClusterStruttureDTO>().ReverseMap();
            CreateMap<ClusterUtenti, ClusterUtentiDTO>().ReverseMap();


            CreateMap<ClusterStuttureUpdateDTO, ClusterStrutture>();
            CreateMap<ClusterUtentiUpdateDTO, ClusterUtenti>();


            CreateMap<ClusterUpdateDTO, Cluster>();

        }
    }
}
