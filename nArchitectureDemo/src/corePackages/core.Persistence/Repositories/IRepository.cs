using System.Linq.Expressions;
using core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace core.Persistence.Repositories;
public interface IRepository<TEntity, TEntityId> : IQueryable<TEntity> where TEntity : Entity<TEntityId> 
{
  Task<TEntity> Get(

      Expression<Func<TEntity, bool>> predicate,
      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
      bool withDeleted = false,
      bool enableTracking = true);


  Task<Paginate<TEntity>> GetList(

      Expression<Func<TEntity, bool>> predicate = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
      int index = 0,
      int size = 10,
      bool withDeleted = false,
      bool enableTracking = true);

  Task<Paginate<TEntity>> GetListByDynamic(
    DynamicQuery dynamic,
    Expression<Func<TEntity, bool>>? predicate = null,
    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
    int index = 0,
    int size = 10,
    bool withDeleted = false,
    bool enableTracking = true);

  Task<bool> Any(
    Expression<Func<TEntity, bool>>? predicate = null,
    bool withDeleted = false,
    bool enableTracking = true);

  Task<TEntity> Add(TEntity entity);
  Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entity);
  Task<TEntity> Update(TEntity entity);
  Task<ICollection<TEntity>> UpdateRange(ICollection<TEntity> entity);
  Task<TEntity> Delete(TEntity entity, bool permanent = false);
  Task<ICollection<TEntity>> DeleteRange(ICollection<TEntity> entity, bool permanent = false);
}
