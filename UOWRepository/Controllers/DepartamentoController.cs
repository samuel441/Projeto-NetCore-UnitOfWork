using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using UOWRepository.Data;
using UOWRepository.Model;

namespace UOWRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartamentoController> _logger;

        public DepartamentoController(IUnitOfWork unitOfWork, ILogger<DepartamentoController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            if (id <= 0)
            {
                _logger.LogInformation("invalid id");
                return NotFound();
            }

            var departamento = await _unitOfWork.DepartamentoRepository.GetDataAsync(x => x.Id == id, x => x.Include(f => f.Funcioanarios));

            if (departamento is null)
            {
                _logger.LogInformation("departamento not found");
                return NotFound();
            }

            return Ok(departamento);
        }

        [HttpGet]

        public IActionResult NovoDepartamento(Departamento departamento)
        {
            _unitOfWork.DepartamentoRepository.Add(departamento);
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
