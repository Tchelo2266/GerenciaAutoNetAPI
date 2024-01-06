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
    public class TipoDespesaController : ControllerBase
    {
        private DBContext _context;
        private IMapper _mapper;

        public TipoDespesaController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTipoDespesaDto tipoDedspesaDto)
        {
            TipoDespesa tipoDespesa = _mapper.Map<TipoDespesa>(tipoDedspesaDto);
            tipoDespesa.data_cadastro = DateTime.Now;
            _context.Add(tipoDespesa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { tipoDespesa.id }, tipoDespesa);
        }

        [HttpGet("{id}")]
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
