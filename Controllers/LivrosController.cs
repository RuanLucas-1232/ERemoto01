using ERemoto01.Models;
using ERemoto01.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERemoto01.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosRepository _repository;
        public LivrosController(LivrosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarColecao()
        {
            return Ok(_repository.ListarLivros());
        }

        [HttpGet("{Id:int}")]
        public IActionResult ListarLivro(int Id)
        {
            return Ok(_repository.ListarLivroPesquisado(Id));
        }

        [HttpPost]
        public IActionResult CadastrarLivro(Livro livro)
        {
            _repository.CadastarLivro(livro);
            return StatusCode(201);
        }

        [HttpPut("{Id:int}")]
        public IActionResult AtualizarLivro(int Id, Livro livro)
        {
            if (livro != null)
            {
                _repository.AtualizarLivro(Id, livro);
                return StatusCode(204);
            }
            return StatusCode(400);
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeletarLivro(int Id)
        {
            _repository.Deletar(Id);
            return StatusCode(204);
        }
    }
}
