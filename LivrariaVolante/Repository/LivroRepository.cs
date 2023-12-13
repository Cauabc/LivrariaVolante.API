using LivrariaVolante.Data;
using LivrariaVolante.Interfaces;
using LivrariaVolante.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaVolante.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LibraryDataContext _libraryDataContext;

        public LivroRepository(LibraryDataContext libraryDataContext)
        {
            _libraryDataContext = libraryDataContext;
        }
        public async Task<List<Livro>> GetLivros()
        {
            return await _libraryDataContext.Livros.ToListAsync();
        }

        public async Task<Livro> GetLivroById(Guid id)
        {
            return await _libraryDataContext.Livros.FirstOrDefaultAsync(l => l.Id == id) ?? throw new Exception("Verifique os dados informados e tente novamente.");
        }

        public void CreateLivro(Livro livro)
        {
            _libraryDataContext.Livros.Add(livro);
        }

        public void DeleteLivro(Livro livro)
        {
            _libraryDataContext.Livros.Remove(livro);
        }

        public void UpdateLivro(Livro livro)
        {
            _libraryDataContext.Livros.Entry(livro).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _libraryDataContext.SaveChangesAsync() > 0;
        }
    }
}
