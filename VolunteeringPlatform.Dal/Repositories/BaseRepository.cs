using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VolunteeringPlatform.Common.Models.PagedRequest;
using VolunteeringPlatform.Dal.Extentions;
using VolunteeringPlatform.Dal.Interfaces;
using VolunteeringPlatform.Domain.Auth;
using VolunteeringPlatform.Domain.Entities;

namespace VolunteeringPlatform.Dal.Repositories
{
    public class BaseRepository : IRepository
    {
        private readonly VolunteeringPlatformDbContext _volunteeringPlatformDbContext;
        private readonly IMapper _mapper;

        public BaseRepository(VolunteeringPlatformDbContext volunteeringPlatformDbContext, IMapper mapper)
        {
            _volunteeringPlatformDbContext = volunteeringPlatformDbContext;
            _mapper = mapper;
        }

        public async Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return await _volunteeringPlatformDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class
        {
            return await _volunteeringPlatformDbContext.FindAsync<TEntity>(id);
        }

        public async Task<TEntity> GetByIdWithIncludeAsync<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _volunteeringPlatformDbContext.SaveChangesAsync();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _volunteeringPlatformDbContext
                .Set<TEntity>()
                .Add(entity);
        }

        public async Task<TEntity> DeleteAsync<TEntity>(int id) where TEntity : class
        {
            var entity = await _volunteeringPlatformDbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new ValidationException($"Object of type {typeof(TEntity)} with id { id } not found");
            }

            _volunteeringPlatformDbContext.Set<TEntity>().Remove(entity);

            return entity;
        }

        public async Task<PaginatedResult<TDto>> GetPagedDataAsync<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : class
                                                                                                        where TDto : class
        {
            return await _volunteeringPlatformDbContext.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, _mapper);
        }

        private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            IQueryable<TEntity> entities = _volunteeringPlatformDbContext.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }
        public async Task<TEntity> GetUserByIdWithIncludeAsync<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : User
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }
    }
}
