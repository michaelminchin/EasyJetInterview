using System;
using System.Collections.Generic;


namespace Interview
{
    public class Repository<T, I> : IRepository<T, I> where T : IStoreable<I>
    {
        private ICollection<T> items;
        private ILogger logger;

        public Repository(ICollection<T> items, ILogger logger)
        {
            if (items == null) throw new ArgumentNullException("Items collection cannot be null");
            if (logger == null) throw new ArgumentNullException("Logger cannot be null");

            this.items = items;
            this.logger = logger;
        }

        public void Delete(I id)
        {
            try
            {
                if (id == null)
                {
                    logger.Log(LogLevel.Error, "id cannot be null when calling Delete on repository");
                    throw new ArgumentNullException("Delete", "id cannot be null when calling Delete on repository");
                }

                foreach (var item in items)
                {
                    if (item.Id.Equals(id))
                    {
                        items.Remove(item);
                        logger.Log(LogLevel.Information, $"Item Id = {id} removed from items collection");
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, "Error calling Delete on repository", e);
                throw;
            }
        }

        public T Get(I id)
        {
            try
            {
                foreach (var item in items)
                {
                    if (item.Id.Equals(id))
                    {
                        return item;
                    }
                }

                return default(T);
            }
            catch (ArgumentNullException ane)
            {
                logger.Log(LogLevel.Error, "id cannot be null when calling Get on repository", ane);
                return default(T);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, "Error calling Get on repository", e);
                return default(T);
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return items;
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, "Error calling GetAll on repository", e);
                return default(IEnumerable<T>);
            }
        }

        public void Save(T item)
        {
            try
            {
                items.Add(item);
                logger.Log(LogLevel.Error, $"Item {item.Id} added to repository");
            }
            catch (ArgumentNullException ane)
            {
                logger.Log(LogLevel.Error, "Item cannot be null when calling Save on repository", ane);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, "Error calling Save on repository", e);
            }
        }
    }
}
