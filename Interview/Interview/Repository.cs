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
                ValidateIdParameter(id, "Delete");
                if (FindAndRemoveItem(id))
                        logger.LogInfo($"Item Id = {id} removed from items collection");
            }
            catch (Exception e)
            {
                logger.LogError(e);
                throw;
            }
        }

        private void ValidateIdParameter(I id, string methodName)
        {
            try
            {
                if (id == null)
                {
                    logger.LogError(new ArgumentNullException(methodName, $"id parameter cannot be null when calling {methodName}"));
                    throw new ArgumentNullException(methodName, "id cannot be null when calling Delete on repository");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e);
                throw;
            }
        }

        private bool FindAndRemoveItem(I id)
        {
            foreach (var item in items)
            {
                if (item.Id.Equals(id))
                {
                    items.Remove(item);
                    return true;
                }
            }
            return false;
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
                //logger.Log(LogLevel.Error, "id cannot be null when calling Get on repository", ane);
                logger.LogError(ane);
                return default(T);
            }
            catch (Exception e)
            {
                //logger.Log(LogLevel.Error, "Error calling Get on repository", e);
                logger.LogError(e);
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
                //logger.Log(LogLevel.Error, "Error calling GetAll on repository", e);
                logger.LogError(e);
                return default(IEnumerable<T>);
            }
        }

        public void Save(T item)
        {
            try
            {
                items.Add(item);
                //logger.Log(LogLevel.Error, $"Item {item.Id} added to repository");
                logger.LogInfo($"Item {item.Id} added to repository");
            }
            catch (ArgumentNullException ane)
            {
                //logger.Log(LogLevel.Error, "Item cannot be null when calling Save on repository", ane);
                logger.LogError(ane);
            }
            catch (Exception e)
            {
                //logger.Log(LogLevel.Error, "Error calling Save on repository", e);
                logger.LogError(e);
            }
        }
    }
}
