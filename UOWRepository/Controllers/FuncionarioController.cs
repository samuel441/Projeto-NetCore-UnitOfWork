using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UOWRepository.Data;
using UOWRepository.Model;

namespace UOWRepository.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public FuncionarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
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
		
		 [HttpPost]
        public IActionResult Delete(Funcioanario funcioanario)
        {
            _unitOfWork.FuncionarioRepository.Add(funcioanario);
            _unitOfWork.Commit();

            return Ok();
        }
    }
}
