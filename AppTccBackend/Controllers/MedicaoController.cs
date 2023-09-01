using AppTccBackend.Models;
using AppTccBackend.Models.Dtos;
using AppTccBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppTccBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicaoController : Controller
    {

        private readonly IMedicaoService _medicaoService;

        public MedicaoController(IMedicaoService medicaoService)
        {
            _medicaoService = medicaoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medicao>> Get(Guid id)
        {
            var medicao = await _medicaoService.ObterMedicaoPorId(id);
            if (medicao == null)
            {
                return NotFound();
            }

            return medicao;
        }
        [HttpGet]
        public async Task<ActionResult<List<Medicao>>> Get(Guid? pacienteId)
        {
            if (pacienteId.HasValue)
            {
                var medicoesDopaciente = await _medicaoService.ObterMedicoesDoPaciente(pacienteId.Value);
                return medicoesDopaciente;
            }
            else
            {
                var medicaos = await _medicaoService.ObterMedicoes();
                return medicaos;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Medicao>> Post(Medicao medicao)
        {
            try
            {
                var novamedicao = await _medicaoService.AdicionarMedicao(medicao);
                return CreatedAtAction(nameof(Get), new { id = novamedicao.Id }, novamedicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Medicao medicao)
        {
            if (id != medicao.Id)
            {
                return BadRequest();
            }

            try
            {
                await _medicaoService.AtualizarMedicao(medicao, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _medicaoService.RemoverMedicao(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
        /*
        [HttpGet("dia/{pacienteId}")]
        public async Task<ActionResult<List<MedicaoPorDiaDto>>> ObterMedicoesPorDia(Guid pacienteId)
        {
            var medicoes = await _medicaoService.ObterMedicoesDoPaciente(pacienteId);

            var medicoesPorDia = medicoes
                .GroupBy(m => m.DataMedicao.Date)
                .Select(group => new MedicaoPorDiaDto
                {
                    DataDia = group.Key,
                    Medicoes = group.ToList()
                })
                .OrderByDescending(dto => dto.DataDia)
                .ToList();

            return medicoesPorDia;
        }
        */
        [HttpGet("dia/{pacienteId}")]
        public async Task<ActionResult<List<MedicaoPorDiaDto>>> ObterMedicoesPorDia(Guid pacienteId)
        {
            try
            {
                var medicoes = await _medicaoService.ObterMedicoesDoPaciente(pacienteId);

                var medicoesPorDia = medicoes
                    .GroupBy(m => m.DataMedicao.Date)
                    .Select(group => new MedicaoPorDiaDto
                    {
                        DataDia = group.Key,
                        Medicoes = group.ToList()
                    })
                    .OrderByDescending(dto => dto.DataDia)
                    .ToList();

                return medicoesPorDia;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
