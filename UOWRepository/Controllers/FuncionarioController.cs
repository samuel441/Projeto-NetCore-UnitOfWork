using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UOWRepository.Data;
using UOWRepository.Model;

namespace UOWRepository.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FuncionarioController> _logger;

        public FuncionarioController(IUnitOfWork unitOfWork, ILogger<FuncionarioController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            if (id <= 0)
            {
                _logger.LogInformation("invalid id: {id}", id);
                return BadRequest();
            }

            var funcioanario = await _unitOfWork.FuncionarioRepository.GetByIdAsync(id);

            if (funcioanario is null)
                return NotFound();

            return Ok(funcioanario);
        }

        [HttpPost]
        public IActionResult NovoFuncionario(Funcioanario funcioanario)
        {
            _unitOfWork.FuncionarioRepository.Add(funcioanario);
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
