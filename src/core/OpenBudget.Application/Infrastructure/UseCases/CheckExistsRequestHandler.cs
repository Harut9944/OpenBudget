using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OpenBudget.Application.Infrastructure.Persistence;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Infrastructure.UseCases
{
  public abstract class CheckExistsRequestHandler<TEntity, TRepository, TRequest>
    : RequestHandlerBase<TEntity, TRepository>, IRequestHandler<TRequest, bool>
      where TEntity : EntityBase
      where TRepository : IRepository<TEntity>
      where TRequest : CheckExistsRequest
  {
    public CheckExistsRequestHandler(TRepository repository, IMapper mapper) 
      : base(repository, mapper)
    {
    }

    public Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
    {
      return this.Repository.CheckExistsAsync(request.Id);
    }
  }
}