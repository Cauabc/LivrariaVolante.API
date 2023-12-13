namespace LivrariaVolante.Models
{
    public class Autor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public List<Livro>? Livros { get; set; }
    }
}
