using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GerenciaAutoNetAPI.Data;
using GerenciaAutoNetAPI.Data.Dtos.TipoDespesa;
using GerenciaAutoNetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciaAutoNetAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoDespesaController : ControllerBase
    {
        private DBContext _context;
        private IMapper _mapper;

        public TipoDespesaController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um novo registro
        /// </summary>
        /// <param name="tipoDedspesaDto"></param>
        /// <returns>Objeto recém criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(typeof(ReadTipoDespesaDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<ReadTipoDespesaDto>> Post([FromBody] CreateTipoDespesaDto tipoDedspesaDto)
        {
            TipoDespesa tipoDespesa = _mapper.Map<TipoDespesa>(tipoDedspesaDto);
            tipoDespesa.data_cadastro = DateTime.Now;
            await _context.TipoDespesa.AddAsync(tipoDespesa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { tipoDespesa.id }, tipoDespesa);
        }

        /// <summary>
        /// Retorna a lista com todos os registros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReadTipoDespesaDto>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<ReadTipoDespesaDto>> GetAll() 
        {
            IEnumerable<ReadTipoDespesaDto> listaTipoDespesaDto = _mapper.Map<IEnumerable<ReadTipoDespesaDto>>(await _context.TipoDespesa.ToListAsync());
            return listaTipoDespesaDto;
        }

        /// <summary>
        /// Obtém um único tipo de despesa
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tipo de despesa</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Nada encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadTipoDespesaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadTipoDespesaDto>> GetById(int id)
        {
            TipoDespesa? tipoDespesa = await _context.TipoDespesa.FindAsync(id);
            if (tipoDespesa != null)
            {
                ReadTipoDespesaDto readTipodespesaDto = _mapper.Map<ReadTipoDespesaDto>(tipoDespesa);
                return Ok(readTipodespesaDto);
            }
            return NotFound();
        }


    }
}
