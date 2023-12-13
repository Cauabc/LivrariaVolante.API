using LivrariaVolante.Models;

namespace LivrariaVolante.Interfaces
{
    public interface IAutorRepository
    {
        void CreateAutor(Autor autor);
        void DeleteAutor(Autor autor);
        Task<Autor> GetAutorById(Guid id);
        Task<List<Autor>> GetAutores();
        Task<bool> SaveAllChangesAsync();
        void UpdateAutor(Autor autor);
    }
}