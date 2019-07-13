using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OpenBudget.Application.Infrastructure.Persistence;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Infrastructure.UseCases
{
  public abstract class GetItemRequestHandler<TEntity, TRepository, TRequest, TResponse> 
    : RequestHandlerBase<TEntity, TRepository>, IRequestHandler<TRequest, TResponse>
      where TEntity : EntityBase
      where TRepository : IRepository<TEntity>
      where TRequest : GetItemRequest<TResponse>
  {
    public GetItemRequestHandler(TRepository repository, IMapper mapper)
      : base(repository, mapper)
    {
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
      TEntity requestedEntity = await this.Repository.GetAsync(request.Id);
      return this.Mapper.Map<TResponse>(requestedEntity);
    }
  }
}