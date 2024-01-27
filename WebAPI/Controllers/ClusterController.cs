using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;
using Newtonsoft.Json;
using WebAPI.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClusterController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClusterController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        // GET: api/<ClusterController>
        [HttpGet]
        public async Task<IEnumerable<ClusterDTO>> GetAll()
        {
            var clusters = await context.Cluster
                .Include(s => s.ClusterStrutture)
                .Include(u => u.ClusterUtenti).ToListAsync();

            var clustersDTO = mapper.Map<List<ClusterDTO>>(clusters);

            return clustersDTO;
        }


        // PUT api/<ClusterController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ClusterUpdateDTO clusterUpdateDTO, int id)
        {
            var cluster = await context.Cluster
                .Include(s => s.ClusterStrutture)
                .Include(u => u.ClusterUtenti).FirstOrDefaultAsync(c => c.ID == id);

            if (cluster is null)
            {
                return NotFound();
            }

            Console.WriteLine("Antes del mapeo");
            Console.WriteLine(JsonConvert.SerializeObject(cluster));
            Console.WriteLine(JsonConvert.SerializeObject(cluster.ClusterStrutture));
            Console.WriteLine(JsonConvert.SerializeObject(cluster.ClusterUtenti));

            cluster = mapper.Map(clusterUpdateDTO, cluster);

            Console.WriteLine("después del mapeo");
            Console.WriteLine(JsonConvert.SerializeObject(cluster));
            Console.WriteLine(JsonConvert.SerializeObject(cluster.ClusterStrutture));
            Console.WriteLine(JsonConvert.SerializeObject(cluster.ClusterUtenti));


            //Las estructuras de clúster y los clústeres de usuarios pierden la relación con su clúster durante el mapeo y el programa falla.
            //El error es que no se puede eliminar el clúster porque primero tengo que eliminar sus entidades relacionadas porque tengo la siguiente configuración(.OnDelete(DeleteBehavior.ClientSetNull).
            //El error tiene sentido lo que no entiendo es por qué se pierde la relación durante el mapeo causando el error...

            await context.SaveChangesAsync();
            return Ok();

        }

        
    }
}
