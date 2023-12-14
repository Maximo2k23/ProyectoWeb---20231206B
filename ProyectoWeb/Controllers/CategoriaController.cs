using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly TiendaContext _dbcontext;

        public CategoriaController(TiendaContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> listar()
        {
            List<Categorium> lista =
                await _dbcontext.Categoria.OrderByDescending(c => c.Nombre).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("guardar")]
        public async Task<IActionResult> guardar([FromBody] Categorium request)
        {
            await _dbcontext.Categoria.AddAsync(request);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "OK");
        }

        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> actualizar([FromBody] Categorium request)
        {
            _dbcontext.Categoria.Update(request);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "OK");

        }

        [HttpGet]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> eliminar(int id)
        {
            Categorium categoria = _dbcontext.Categoria.Find(id);

            _dbcontext.Categoria.Remove(categoria);
            await _dbcontext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "OK");
        }
    }

}
