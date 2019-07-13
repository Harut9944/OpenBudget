using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OpenBudget.Application.Infrastructure.Persistence;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Infrastructure.UseCases
{
  public abstract class UpdateRequestHandler<TEntity, TRepository, TRequest, TResponse> 
    : RequestHandlerBase<TEntity, TRepository>, IRequestHandler<TRequest, TResponse>
      where TEntity : EntityBase
      where TRepository : IRepository<TEntity>
      where TRequest : IRequest<TResponse>
  {
    public UpdateRequestHandler(TRepository repository, IMapper mapper)
      : base(repository, mapper)
    {
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
      TEntity entityToCreate = this.Mapper.Map<TEntity>(request);
      TEntity createdEntity = await this.Repository.UpdateAsync(entityToCreate);

      await this.Repository.SaveChangesAsync();

      return this.Mapper.Map<TResponse>(createdEntity);
    }
  }
}