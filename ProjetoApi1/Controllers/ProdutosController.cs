using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using ProjetoApi1.Context;
using ProjetoApi1.Filters;
using ProjetoApi1.Models;
using System.Xml.Linq;

namespace ProjetoApi1.Controllers
{
    [Route("api/[controller]")]//produtos
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [ServiceFilter(typeof(ApilogginFilter))]
        public async Task<ActionResult<IEnumerable<Produto>>> Get2()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        /*[HttpGet]
        public ActionResult<Produto> Get()
        {

            var produto = _context.Produtos.ToList();
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return Ok(produto);
        }*/
        // /api/produtos/id
        [HttpGet("{id}", Name="ObterProduto")]
        public async Task<ActionResult<Produto>> GetAsync([FromQuery]int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return produto;
        }
        // api/produtos/primeiro
        //[HttpGet("primeiro")]
        //[HttpGet("teste")]
        [HttpGet("/{id}")]
        public ActionResult<Produto> GetPrimeiro(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return produto;
        }

        // api/produtos
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                return BadRequest();
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            //var produto = _context.Produtos.Find(id);
            if (produto is null)
            {
                return NotFound("Produto não localizado...");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
