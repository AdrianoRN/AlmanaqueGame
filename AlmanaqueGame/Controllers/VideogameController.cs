using Microsoft.AspNetCore.Mvc;
using AlmanaqueGame.Models;
 
namespace AlmanaqueGame.Controllers
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

        [HttpGet]
        public Videogame Visualizar(string Fabricante)
        {
            return contexto.Videogames.FirstOrDefault(p => p.Fabricante == Fabricante);
        }

        [HttpPost]
        public string Cadastrar([FromBody] Videogame novoVideogame)
        {
            contexto.Add(novoVideogame);
            contexto.SaveChanges();
            return "Game cadastrado com sucesso!";
        }
   

        [HttpDelete]
        public string Excluir([FromBody] int id)
        {
            Videogame dados = contexto.Videogames.FirstOrDefault(p => p.Id == id);
            
            if(dados == null)
            {
                return"Não encontramos nenhum game com este ID, sorry!!!";
            }
            else
            {
                contexto.Remove(dados);
                contexto.SaveChanges();
                
                return "Game removido com sucesso!";
            }
        }
    }
}
