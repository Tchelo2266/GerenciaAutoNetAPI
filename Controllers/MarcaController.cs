using AutoMapper;
using GerenciaAutoNetAPI.Data;
using GerenciaAutoNetAPI.Data.Dtos.Marca;
using GerenciaAutoNetAPI.Data.Dtos.TipoDespesa;
using GerenciaAutoNetAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciaAutoNetAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MarcaController : ControllerBase
    {
        private DBContext _context;
        private IMapper _mapper;

        public MarcaController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um novo registro
        /// </summary>
        /// <param name="createMarcaDto"></param>
        /// <returns>Objeto recém criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(typeof(ReadMarcaDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<ReadMarcaDto>> Post([FromBody] CreateMarcaDto createMarcaDto)
        {
            Marca marca = _mapper.Map<Marca>(createMarcaDto);
            marca.data_cadastro = DateTime.Now;
            await _context.Marca.AddAsync(marca);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { marca.id }, marca);
        }

        /// <summary>
        /// Retorna a lista com todos os registros
        /// </summary>
        /// <returns>Marcas</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReadMarcaDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReadMarcaDto>>> GetAll()
        {
            IEnumerable<ReadMarcaDto> listaMarcas = _mapper.Map<IEnumerable<ReadMarcaDto>>(await _context.Marca.ToListAsync());
            return Ok(listaMarcas);
        }

        /// <summary>
        /// Busca um único registro pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Marca</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Nada encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadMarcaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadMarcaDto>> GetById(int id)
        {
            Marca? marca = await _context.Marca.FindAsync(id);
            if (marca != null)
            {
                ReadMarcaDto readMarcaDto = _mapper.Map<ReadMarcaDto>(marca);
                return Ok(readMarcaDto);
            }
            return NotFound();
        }
    }
}
