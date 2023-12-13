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
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public LivroController(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Livro>>> Get()
        {
            return Ok(await _livroRepository.GetLivros());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivroById(Guid id)
        {
            return Ok(await _livroRepository.GetLivroById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLivroDTO request)
        {
            try
            {
                var livro = _mapper.Map<Livro>(request);
                _livroRepository.CreateLivro(livro);
                if (await _livroRepository.SaveAllChangesAsync())
                {
                    return Ok("Criado com sucesso.");
                }
                return BadRequest("Erro, tente novamente.");
            }
            catch (Exception)
            {
                return BadRequest("Erro, tente novamente.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                Livro livroToDelete = await _livroRepository.GetLivroById(id);
                _livroRepository.DeleteLivro(livroToDelete);
                if (await _livroRepository.SaveAllChangesAsync())
                {
                    return Ok("Livro removido com sucesso.");
                }
                return BadRequest("Erro, tente novamente.");
            }catch (Exception)
            {
                return BadRequest("Erro, tente novamente.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLivroDTO request)
        {
            try
            {
                var livro = _mapper.Map<Livro>(request);
                _livroRepository.UpdateLivro(livro);
                if (await _livroRepository.SaveAllChangesAsync())
                {
                    return Ok("Livro atualizado com sucesso.");
                }
                return BadRequest("Erro, tente novamente.");
            }
            catch (Exception)
            {
                return BadRequest("Erro, tente novamente.");
            }
        }
    }
}
