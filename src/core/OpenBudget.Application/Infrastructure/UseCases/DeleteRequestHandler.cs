using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OpenBudget.Application.Infrastructure.Persistence;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Infrastructure.UseCases
{
  public abstract class DeleteRequestHandler<TEntity, TRepository, TRequest> 
    : RequestHandlerBase<TEntity, TRepository>, IRequestHandler<TRequest, Unit>
      where TEntity : EntityBase
      where TRepository : IRepository<TEntity>
      where TRequest : IRequest
  {
    public DeleteRequestHandler(TRepository repository, IMapper mapper)
      : base(repository, mapper)
    {
    }

    public async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
    {
      TEntity entityToDelete = this.Mapper.Map<TEntity>(request);
      TEntity deletedEntity = await this.Repository.DeleteAsync(entityToDelete);

      await this.Repository.SaveChangesAsync();

      return Unit.Value;
    }
  }
}