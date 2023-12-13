using System.Text.Json.Serialization;

namespace LivrariaVolante.Models
{
    public class Livro
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public Guid AutorId { get; set; }
        [JsonIgnore]
        public Autor? Autor { get; set; }
    }
}
