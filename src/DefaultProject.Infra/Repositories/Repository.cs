using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DefaultProject.Domain.Repositories;
using DefaultProject.Infra.Context;
using DefaultProject.Shared.Entities;

namespace DefaultProject.Infra.Repositories
{
	public class Repository<T> : IRepository<T> where T : Entity
	{
		protected readonly DefaultProjectDbContext DbContext;
		protected readonly DbSet<T> DbSet;

		public Repository(DefaultProjectDbContext dbContext)
		{
			DbContext = dbContext;
			DbSet = DbContext.Set<T>();
		}
		
		public virtual async Task Create(T entity)
		{
			await DbSet.AddAsync(entity);
		}

		public virtual void Update(T entity)
		{
			DbSet.Attach(entity);
			DbContext.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Remove(T entity)
		{
			DbSet.Remove(entity);
		}
		
		public virtual async Task<IList<T>> GetAll()
		{
			return await DbSet.ToListAsync();
		}

		public virtual async Task<T> GetById(Guid id)
		{
			return await DbSet.SingleOrDefaultAsync(e => e.Id == id);
		}
		
		public async Task Commit()
		{
			await DbContext.SaveChangesAsync();
		}

	}
}