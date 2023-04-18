using MedPos.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Infrastructure
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly MedPosDbContext _context;
		private readonly DbSet<T> _dbSet;

        public Repository(MedPosDbContext context )
        {
            _context = context;
			_dbSet = context.Set<T>();
        }
        public void Add(T entity)
		{
			_dbSet.Add(entity);
		}

		public void AddAsync(T entity)
		{
			_ = _dbSet.AddAsync(entity);
		}

		public T Create(T entity)
		{
			_dbSet.Add(entity);
			return entity;
		}

		public async Task<T> CreateAsync(T entity)
		{
			await  _dbSet.AddAsync(entity);
			return entity;

		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void DeleteAsync(T entity)
		{
			_dbSet.Remove(entity);
		}

		public T Get(Expression<Func<T, bool>> predicate, string? includeProperties = null)
		{
			IQueryable<T> query = _dbSet;
			query = query.Where(predicate);
			if (includeProperties != null)
			{
				var items = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var item in items)
				{
					query = query.Include(item);
				}
			}
			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null)
		{
			IQueryable<T> query = _dbSet;
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			if (includeProperties != null)
			{
				var items = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var item in items)
				{
					query = query.Include(item);
				}
			}
			return query.ToList();
		}

		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null)
		{
			IQueryable<T> query = _dbSet;
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			if (includeProperties != null)
			{
				var items = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var item in items)
				{
					query = query.Include(item);
				}
			}
			return await query.ToListAsync();
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, string? includeProperties = null)
		{
			IQueryable<T> query = _dbSet;
			query = query.Where(predicate);
			if (includeProperties != null)
			{
				var items = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var item in items)
				{
					query = query.Include(item);
				}
			}
			return await query.FirstOrDefaultAsync();
		}

		public T Update(T entity, object key)
		{
			if (entity == null)
				return null;
			var exist = _context.Set<T>().Find(key);
			if (exist != null)
			{
				_context.Entry(exist).CurrentValues.SetValues(entity);
			}
			return exist;
		}

		public async Task<T> UpdateAsync(T entity, object key)
		{
			if (entity == null)
				return null;
			var exist = await _context.Set<T>().FindAsync(key);
			if (exist != null)
			{
				 _context.Entry(exist).CurrentValues.SetValues(entity);
			}
			return exist;
		}
	}
}
