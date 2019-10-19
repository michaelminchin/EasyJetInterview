using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview;

namespace Interview
{
    public class Repository<T, I> : IRepository<T, I> where T : IStoreable<I>
    {
        private ICollection<T> items;

        public Repository(ICollection<T> items)
        {
            if (items == null) throw new ArgumentNullException("Items collection cannot be null");

            this.items = items;
        }

        public void Delete(I id)
        {
            throw new NotImplementedException();
        }

        public T Get(I id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            try
            {
                items.Add(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
