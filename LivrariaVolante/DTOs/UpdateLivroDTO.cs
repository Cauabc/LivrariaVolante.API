namespace LivrariaVolante.DTOs
{
    public record struct UpdateLivroDTO(Guid id, string name, string description, Guid autorId);
}