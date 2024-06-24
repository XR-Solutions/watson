using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watson.Adapter.SqlServer.Contexts;
using Watson.Application.Interfaces;

namespace Watson.Adapter.SqlServer.Repositories
{
	public class GenericRepository<T>(ApplicationDbContext dbContext)
		: IGenericRepository<T> where T : class
	{
		private readonly ApplicationDbContext _dbContext = dbContext;

		public async Task<T> AddAsync(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task UpdateAsync(T entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<IReadOnlyList<T>> GetAllAsync()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<int> GetCountAsync()
		{
			return await _dbContext.Set<T>().CountAsync();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await _dbContext.Set<T>().FindAsync(id);
		}

		public async Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int pageSize)
		{
			return await _dbContext
				.Set<T>()
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.AsNoTracking()
				.ToListAsync();
		}
	}
}
