using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public DepartamentoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var departamento = await _unitOfWork.DepartamentoRepository.GetDataAsync(x => x.Id == id, x => x.Include(f => f.Funcioanarios));

            if (departamento is null)
                return NotFound();

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
