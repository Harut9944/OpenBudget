using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OpenBudget.Application.Infrastructure.Persistence;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Infrastructure.UseCases
{
  public abstract class GetItemsRequestHandler<TEntity, TRepository, TRequest, TResponse> 
    : RequestHandlerBase<TEntity, TRepository>, IRequestHandler<TRequest, TResponse>
      where TEntity : EntityBase
      where TRepository : IRepository<TEntity>
      where TRequest : IRequest<TResponse>
  {
    public GetItemsRequestHandler(TRepository repository, IMapper mapper)
      : base(repository, mapper)
    {
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
      List<TEntity> result = await this.Repository.GetAsync();
      return this.Mapper.Map<TResponse>(result);
    }
  }
}