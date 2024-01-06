using AutoMapper;
using GerenciaAutoNetAPI.Data;
using GerenciaAutoNetAPI.Data.Dtos.Combustivel;
using GerenciaAutoNetAPI.Data.Dtos.TipoDespesa;
using GerenciaAutoNetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAutoNetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CombustivelController : ControllerBase
    {
        private DBContext _context;
        private IMapper _mapper;
        public CombustivelController(DBContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um novo registro
        /// </summary>
        /// <param name="combustivelDto"></param>
        /// <returns>Objeto recém criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCombustivelDto combustivelDto) 
        { 
            Combustivel combustivel = _mapper.Map<Combustivel>(combustivelDto); 
            combustivel.data_cadastro = DateTime.Now;
            _context.Combustivel.Add(combustivel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { combustivel.id }, combustivel);
        }

        /// <summary>
        /// Retorna a lista com todos os registros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ReadCombustivelDto> GetAll()
        {
            IEnumerable<ReadCombustivelDto> listaCombustivel = _mapper.Map<IEnumerable<ReadCombustivelDto>>(_context.Combustivel);
            return listaCombustivel;
        }

        /// <summary>
        /// Busca um único registro pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Combustível</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Nada encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadCombustivelDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            Combustivel? combustivel = _context.Combustivel.FirstOrDefault(x => x.id == id);
            if (combustivel != null)
            {
                ReadCombustivelDto readCombustivelDto = _mapper.Map<ReadCombustivelDto>(combustivel);
                return Ok(readCombustivelDto);
            }
            return NotFound();
        }
    }
}
