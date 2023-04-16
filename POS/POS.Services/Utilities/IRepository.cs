using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public partial interface IRepository <T> where T:BaseEntity
    {
       
        T GetById(object id);       
        int Insert(T entity);       
        int Insert(IEnumerable<T> entities);       
        int Update(T entity);
        int Update(IEnumerable<T> entities);
        void Delete(T entity);       
        void Delete(IEnumerable<T> entities);      
        IQueryable<T> GetAll { get; }

    }
}
