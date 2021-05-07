using UOWRepository.Data.Context;
using UOWRepository.Data.Repositories.Base;
using UOWRepository.Model;

namespace UOWRepository.Data.Repositories
{
    public class FuncionarioRepository : Repository<Funcioanario>, IFuncionarioRepository
    {
        public FuncionarioRepository(AplicacaoContext aplicacaoContext) :base(aplicacaoContext)
        {

        }
    }
}
