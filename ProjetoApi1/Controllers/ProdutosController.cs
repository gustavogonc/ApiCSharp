using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using ProjetoApi1.Context;
using ProjetoApi1.Filters;
using ProjetoApi1.Models;
using ProjetoApi1.Repository;
using System.Xml.Linq;

namespace ProjetoApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        public ProdutosController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPrecos()
        {
            return _context.ProdutoRepository.GetProdutosPorPreco().ToList();
        }

        [HttpGet]
        [ServiceFilter(typeof(ApilogginFilter))]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return _context.ProdutoRepository.Get().ToList();
        }

        [HttpGet("{id}", Name="ObterProduto")]
        public ActionResult<Produto> Get([FromQuery]int id)
        {
            var produto = _context.ProdutoRepository.GetById(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return produto;
        }

        [HttpGet("/{id}")]
        public ActionResult<Produto> GetPrimeiro(int id)
        {
            var produto = _context.ProdutoRepository.GetById(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return produto;
        }

        
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                return BadRequest();
            }

            _context.ProdutoRepository.Add(produto);
            _context.Commit();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.ProdutoRepository.Update(produto);
            _context.Commit();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.ProdutoRepository.GetById(p => p.ProdutoId == id);
            //var produto = _context.Produtos.Find(id);
            if (produto is null)
            {
                return NotFound("Produto não localizado...");
            }
            _context.ProdutoRepository.Delete(produto);
            _context.Commit();

            return Ok(produto);
        }
    }
}
