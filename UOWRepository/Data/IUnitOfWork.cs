using System;
using UOWRepository.Data.Repositories;

namespace UOWRepository.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        IDepartamentoRepository DepartamentoRepository { get; }
        IFuncionarioRepository FuncionarioRepository { get; }
    }
}
