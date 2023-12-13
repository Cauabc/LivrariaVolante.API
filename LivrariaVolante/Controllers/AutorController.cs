using AutoMapper;
using LivrariaVolante.DTOs;
using LivrariaVolante.Interfaces;
using LivrariaVolante.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaVolante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public AutorController(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return Ok(await _autorRepository.GetAutores());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutorById(Guid id)
        {
            return Ok(await _autorRepository.GetAutorById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAutorDTO request)
        {
            try
            {
                var autor = _mapper.Map<Autor>(request);
                _autorRepository.CreateAutor(autor);
                if (await _autorRepository.SaveAllChangesAsync())
                {
                    return Ok("Autor criado com sucesso.");
                }

                return BadRequest("Não foi possível salvar o autor.");
            } catch (Exception)
            {
                return BadRequest("Erro ao criar autor, tente novamente.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var autor = await _autorRepository.GetAutorById(id);
                _autorRepository.DeleteAutor(autor);
                if (await _autorRepository.SaveAllChangesAsync())
                {
                    return Ok("Autor deletado com sucesso");
                }

                return BadRequest("Erro, tente novamente.");
            } catch (Exception)
            {
                   return BadRequest("Erro, tente novamente.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAutorDTO request)
        {
            try
            {
                var autor = _mapper.Map<Autor>(request);
                _autorRepository.UpdateAutor(autor);
                if (await _autorRepository.SaveAllChangesAsync())
                {
                    return Ok("Autor alterado com sucesso");
                }
                return BadRequest("Erro, tente novamente.");

            } catch (Exception)
                {
                    return BadRequest("Erro, tente novamente.");
                }
        }
    }
}
