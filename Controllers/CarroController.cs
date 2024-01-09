using AutoMapper;
using GerenciaAutoNetAPI.Data;
using GerenciaAutoNetAPI.Data.Dtos.Carro;
using Microsoft.AspNetCore.Mvc;
using GerenciaAutoNetAPI.Models;
using GerenciaAutoNetAPI.Data.Dtos.Combustivel;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GerenciaAutoNetAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CarroController : ControllerBase
    {
        private DBContext _context;
        private IMapper _mapper;
        public CarroController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um novo registro
        /// </summary>
        /// <param name="carroDto"></param>
        /// <returns>Objeto recém criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(typeof(ReadCarroDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<ReadCarroDto>> Post([FromBody] CreateCarroDto carroDto)
        {
            Carro carro = _mapper.Map<Carro>(carroDto);
            carro.data_cadastro = DateTime.Now;
            await _context.AddAsync(carro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { carro.id }, carro);
        }

        /// <summary>
        /// Retorna a lista com todos os registros
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(ActionResult<IEnumerable<ReadCarroDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadCarroDto>>> Get()
        {
            IEnumerable<ReadCarroDto> listaCarro = _mapper.Map<IEnumerable<ReadCarroDto>>( await _context.Carro.Include(carro => carro.marca).ToListAsync());
            return Ok(listaCarro);
        }

        /// <summary>
        /// Busca um único registro pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Carro</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Nada encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Carro), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Carro> GetById(int id)
        {
            Carro? carro = await _context.Carro.FindAsync(id);
            if (carro != null)
            {
            }
            return _mapper.Map<Carro>(carro);
        }

        /// <summary>
        /// Busca um único registro pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carroDto"></param>
        /// <returns>Carro</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Erro</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ReadCarroDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReadCarroDto>> Put(int id, [FromBody] UpdateCarroDto carroDto)
        {
            if (id != carroDto.id)
            {
                return BadRequest();
            }
            Carro carro = _mapper.Map<Carro>(await GetById(id));
            _mapper.Map(carroDto, carro);
            //_context.Entry(carro).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ReadCarroDto>(await GetById(id)));
        }

        /// <summary>
        /// IMPLEMENTAR DEPOIS
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
