using AutoMapper;
using OpenBudget.Application.Infrastructure.Persistence;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Infrastructure.UseCases
{
  public abstract class RequestHandlerBase<TEntity, TRepository>
    where TEntity : EntityBase
    where TRepository : IRepository<TEntity>
  {
    protected TRepository Repository { get; }
    protected IMapper Mapper { get; }

    public RequestHandlerBase(TRepository repository, IMapper mapper)
    {
      this.Mapper = mapper;
      this.Repository = repository;
    }
  }
}