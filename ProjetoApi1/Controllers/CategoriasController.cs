using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoApi1.Context;
using ProjetoApi1.Models;
using ProjetoApi1.Repository;
using ProjetoApi1.Services;

namespace ProjetoApi1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        public CategoriasController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("categorias")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _context.CategoriaRepository.GetCategoriasProdutos().ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.CategoriaRepository.Get().ToList();
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.CategoriaRepository.GetById(p => p.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound($"Categoria com id = {id} não encontrada...");
            }
            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            _context.CategoriaRepository.Add(categoria);
            _context.Commit();

            return new CreatedAtRouteResult("Obtercategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.CategoriaRepository.Update(categoria);
            _context.Commit();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.CategoriaRepository.GetById(p => p.CategoriaId == id);
            //var produto = _context.Produtos.Find(id);
            if (categoria == null)
            {
                return NotFound($"Categoria com id={id} não localizada...");
            }
            _context.CategoriaRepository.Delete(categoria);
            _context.Commit();

            return Ok(categoria);
        }
    }
}

