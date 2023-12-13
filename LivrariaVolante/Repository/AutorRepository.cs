using LivrariaVolante.Data;
using LivrariaVolante.Interfaces;
using LivrariaVolante.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaVolante.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly LibraryDataContext _libraryDataContext;

        public AutorRepository(LibraryDataContext libraryDataContext)
        {
            _libraryDataContext = libraryDataContext;
        }

        public async Task<List<Autor>> GetAutores()
        {
            return await _libraryDataContext.Autores.Include(a => a.Livros).ToListAsync();
        }

        public void CreateAutor(Autor autor)
        {
            _libraryDataContext.Autores.Add(autor);
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _libraryDataContext.SaveChangesAsync() > 0;
        }

        public async Task<Autor> GetAutorById(Guid id)
        {
            return await _libraryDataContext.Autores.Include(a => a.Livros)
                .FirstOrDefaultAsync(a => a.Id == id) ?? throw new Exception("Verifique os dados informados e tente novamente.");
        }

        public void DeleteAutor(Autor autor)
        {
            _libraryDataContext.Autores.Remove(autor);
        }

        public void UpdateAutor(Autor autor)
        {
            _libraryDataContext.Autores.Entry(autor).State = EntityState.Modified;
        }
    }
}
