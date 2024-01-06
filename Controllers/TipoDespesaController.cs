using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GerenciaAutoNetAPI.Data;
using GerenciaAutoNetAPI.Data.Dtos.TipoDespesa;
using GerenciaAutoNetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAutoNetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        /// Cadastrar um tipo de despesa
        /// </summary>
        /// <param name="tipoDedspesaDto"></param>
        /// <returns>Objeto recém criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(typeof(ReadTipodespesaDto), StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] CreateTipoDespesaDto tipoDedspesaDto)
        {
            TipoDespesa tipoDespesa = _mapper.Map<TipoDespesa>(tipoDedspesaDto);
            tipoDespesa.data_cadastro = DateTime.Now;
            _context.Add(tipoDespesa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { tipoDespesa.id }, tipoDespesa);
        }

        /// <summary>
        /// Obtém um único tipo de despesa
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tipo de despesa</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Nada encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadTipodespesaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            TipoDespesa? tipoDespesa = _context.TipoDespesa.FirstOrDefault(x => x.id == id);
            if (tipoDespesa != null)
            {
                ReadTipodespesaDto tipodespesaDto = _mapper.Map<ReadTipodespesaDto>(tipoDespesa);
                return Ok(tipodespesaDto);
            }
            return NotFound();
        }


    }
}
