using Microsoft.AspNetCore.Mvc;
using AlmanaqueGame.Models;
 
namespace ProjetoMySQL.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VideogameController : ControllerBase
    {
        private BDContexto contexto;
 
        public VideogameController(BDContexto bdContexto)
        {
            contexto = bdContexto;
        }
 
        [HttpGet]
        public List<Videogame> Listar()
        {
            return contexto.Videogames.ToList();
        }
    }
}
