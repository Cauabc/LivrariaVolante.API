using LivrariaVolante.Models;

namespace LivrariaVolante.Interfaces
{
    public interface ILivroRepository
    {
        void CreateLivro(Livro livro);
        void DeleteLivro(Livro livro);
        Task<Livro> GetLivroById(Guid id);
        Task<List<Livro>> GetLivros();
        Task<bool> SaveAllChangesAsync();
        void UpdateLivro(Livro livro);
    }
}