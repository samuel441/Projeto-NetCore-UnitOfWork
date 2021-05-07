using UOWRepository.Data.Context;
using UOWRepository.Data.Repositories;

namespace UOWRepository.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AplicacaoContext _aplicacaoContext;

        public UnitOfWork(AplicacaoContext aplicacaoContext)
        {
            _aplicacaoContext = aplicacaoContext;
        }


        private IDepartamentoRepository _departamentoRepository;

        public IDepartamentoRepository DepartamentoRepository
        {
            get => _departamentoRepository ?? new DepartamentoRepository(_aplicacaoContext);
        }

        private IFuncionarioRepository _funcionarioRepository;

        public IFuncionarioRepository FuncionarioRepository
        {
            get => _funcionarioRepository ?? new FuncionarioRepository(_aplicacaoContext);
        }

        public bool Commit()
        {
            return _aplicacaoContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _aplicacaoContext.Dispose();
        }
    }
}
