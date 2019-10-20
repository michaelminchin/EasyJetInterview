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
            T itemToDelete;

            try
            {
                ValidateIdParameter(id, "Delete");
                if (FindItem(id, out itemToDelete))
                {
                    RemoveItem(itemToDelete);
                    logger.LogInfo($"Item Id = {id} removed from items collection");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e);
                throw;
            }
        }

        public T Get(I id)
        {
            T itemToReturn;

            try
            {
                ValidateIdParameter(id, "Get");
                if (FindItem(id, out itemToReturn))
                {
                    return itemToReturn;
                }

                return default(T);
            }
            catch (Exception e)
            {
                logger.LogError(e);
                throw;
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
                logger.LogError(e);
                return default(IEnumerable<T>);
            }
        }

        public void Save(T item)
        {
            try
            {
                ValidateItemParameter(item, "Save");
                SaveItem(item);
                logger.LogInfo($"Item {item.Id} added to repository");
                        
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
                    throw new ArgumentNullException(methodName, $"id cannot be null when calling {methodName} on repository");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e);
                throw;
            }
        }

        private void ValidateItemParameter(T item, string methodName)
        {
            try
            {
                if (item == null)
                {
                    logger.LogError(new ArgumentNullException(methodName, $"item parameter cannot be null when calling {methodName}"));
                    throw new ArgumentNullException(methodName, $"item cannot be null when calling {methodName} on repository");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e);
                throw;
            }
        }

        private bool FindItem(I id, out T returnItem)
        {
            foreach (var item in items)
            {
                if (item.Id.Equals(id))
                {
                    returnItem = item;
                    return true;
                }
            }
            returnItem = default(T);
            return false;
        }

        private void RemoveItem(T item)
        {
            items.Remove(item);
        }

        private void SaveItem(T item)
        {
            items.Add(item);
        }
    }
}
