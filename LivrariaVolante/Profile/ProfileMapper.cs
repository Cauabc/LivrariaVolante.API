using LivrariaVolante.DTOs;
using LivrariaVolante.Models;

namespace LivrariaVolante.Profile
{
    public class ProfileMapper : AutoMapper.Profile
    {
        public ProfileMapper()
        {
            CreateMap<CreateAutorDTO, Autor>();
            CreateMap<UpdateAutorDTO, Autor>();
            CreateMap<CreateLivroDTO, Livro>();
            CreateMap<UpdateLivroDTO, Livro>();
        }
    }
}
