using ERemoto01.Contexts;
using ERemoto01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERemoto01.Repository
{
    public class LivrosRepository
    {
        private readonly ChapterContexts _contexts;
        public LivrosRepository(ChapterContexts contexts)
        {
            _contexts = contexts;
        }
        public List<Livro> ListarLivros()
        {
            return _contexts.Livros.ToList();
        }
        public Livro ListarLivroPesquisado(int Id)
        {
            var livroEncrontrado = _contexts.Livros.Find(Id);
            return livroEncrontrado;
        }
        public async Task CadastarLivro(Livro livro)
        {
            await _contexts.Livros.AddAsync(livro);
            _contexts.SaveChanges();
            //Não precisa receber Id, pois o banco cria um Id para o livro adicionado.
        }
        public async Task AtualizarLivro(int Id, Livro livroAtualizado)
        {
            Livro livroProcurado = _contexts.Livros.Find(Id);
            if (livroProcurado != null)
            {
                livroProcurado.Titulo = livroAtualizado.Titulo;
                livroProcurado.QuantidadePaginas = livroAtualizado.QuantidadePaginas;
                livroProcurado.Disponivel = livroAtualizado.Disponivel;
            }
            _contexts.Livros.Update(livroProcurado);
            await _contexts.SaveChangesAsync();
        }
        public void Deletar(int Id)
        {
            Livro livroBuscado = _contexts.Livros.Find(Id);
            _contexts.Livros.Remove(livroBuscado);
            _contexts.SaveChanges();
        }
    }
}
