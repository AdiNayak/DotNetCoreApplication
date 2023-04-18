using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Infrastructure
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
		T Get(Expression<Func<T, bool>> predicate, string? includeProperties = null);
		void Add(T entity);
		T Update(T entity, object key);
		void Delete(T entity);
		Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
		Task<T> GetAsync(Expression<Func<T, bool>> predicate, string? includeProperties = null);
		void AddAsync(T entity);
		Task<T> UpdateAsync(T entity, object key);
		void DeleteAsync(T entity);
	}
}
