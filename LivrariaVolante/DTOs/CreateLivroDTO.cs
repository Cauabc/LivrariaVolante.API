namespace LivrariaVolante.DTOs
{
    public record struct CreateLivroDTO(string name, string description, Guid autorId);
}
