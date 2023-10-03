using AutoMapper;

using RoleBased.Shared;
using RoleBased.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using RoleBased.Infrastructure.Persistance;
using System.Linq.Expressions;

namespace RoleBased.Repository.Concrete;

public class RepositoryBase<TEntity,IModel,T>: IRepository<TEntity, IModel, T>
    where TEntity : class, IEntity<T>, new()
    where IModel : class, IVM<T>, new()
    where T : IEquatable<T>
{
    private readonly RoleBasedDbContext _dbContext;
    private readonly IMapper _mapper;

    public RepositoryBase(RoleBasedDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        Dbset = _dbContext.Set<TEntity>();
    }
    public DbSet<TEntity> Dbset { get; }

    public async Task DeleteAsync(TEntity entity)
    {
        Dbset.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IModel> DeleteAsync(T Id)
    {
        var data = await Dbset.FindAsync(Id);
        if(data != null)
        {
            Dbset.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
        return _mapper.Map<IModel>(data);
    }

    public async Task<IEnumerable<IModel>> GetAllAsync()
    {
        var data = await Dbset.ToListAsync();
        return _mapper.Map<IEnumerable<IModel>>(data);
    }

    public async Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        var data = await includes.Aggregate(
            Dbset.AsQueryable(),
            (current,include)=>current.Include(include))
            .ToListAsync()
            .ConfigureAwait(false);
        return _mapper.Map<List<IModel>>(data);
    }

    public async Task<IModel> GetByIdAsync(T Id)
    {
        var data = await Dbset.FindAsync(Id);
        return _mapper.Map<IModel>(data);
    }

    public async Task<IModel> InsertAsync(TEntity entity)
    {
        await Dbset.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<IModel>(entity);
    }

    public async Task<IModel> UpdateAsync(T Id, TEntity entity)
    {
        if(entity == null)
        {
            throw new ArgumentNullException("Empty");
        }

        var data = await Dbset.FindAsync(Id);
        if(data != null)
        {
            data = entity;
            Dbset.Entry(data).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        return _mapper.Map<IModel>(entity);
    }
}
