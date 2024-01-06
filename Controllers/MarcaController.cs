using AutoMapper;
using GerenciaAutoNetAPI.Data;
using GerenciaAutoNetAPI.Data.Dtos.Marca;
using GerenciaAutoNetAPI.Data.Dtos.TipoDespesa;
using GerenciaAutoNetAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAutoNetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult Post([FromBody] CreateMarcaDto createMarcaDto)
        {
            Marca marca = _mapper.Map<Marca>(createMarcaDto);
            marca.data_cadastro = DateTime.Now;
            _context.Marca.Add(marca);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { marca.id }, marca);
        }

        /// <summary>
        /// Retorna a lista com todos os registros
        /// </summary>
        /// <returns>Marcas</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReadMarcaDto>), StatusCodes.Status200OK)]
        public IEnumerable<ReadMarcaDto> GetAll()
        {
            IEnumerable<ReadMarcaDto> listaMarcas = _mapper.Map<IEnumerable<ReadMarcaDto>>(_context.Marca);
            return listaMarcas;
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
        public IActionResult GetById(int id)
        {
            Marca? marca = _context.Marca.FirstOrDefault(x => x.id == id);
            if (marca != null)
            {
                ReadMarcaDto readMarcaDto = _mapper.Map<ReadMarcaDto>(marca);
                return Ok(readMarcaDto);
            }
            return NotFound();
        }
    }
}
