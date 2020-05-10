using DevFramework.Nort.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Nort.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities; 

        EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entities;

        protected IDbSet<T> Entities
        {
            get
            {
                if(_entities==null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }
    }
}
