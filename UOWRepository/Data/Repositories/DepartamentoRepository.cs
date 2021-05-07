using UOWRepository.Data.Context;
using UOWRepository.Data.Repositories.Base;
using UOWRepository.Model;

namespace UOWRepository.Data.Repositories
{
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(AplicacaoContext aplicacaoContext) : base(aplicacaoContext)
        {

        }
    }
}
