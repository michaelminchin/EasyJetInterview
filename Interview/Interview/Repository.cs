using System;
using System.Collections.Generic;


namespace Interview
{
    public class Repository<T, I> : IRepository<T, I> where T : IStoreable<I>
    {
        private ICollection<T> items;
        private ILogger logger;
        private IValidate<T, I> validate;

        public Repository(ICollection<T> items, ILogger logger, IValidate<T, I> validate)
        {
            if (items == null) throw new ArgumentNullException("Items collection cannot be null");
            if (logger == null) throw new ArgumentNullException("Logger cannot be null");
            if (logger == null) throw new ArgumentNullException("Logger cannot be null");

            this.items = items;
            this.logger = logger;
            this.validate = validate;
        }

        public void Delete(I id)
        {
            T itemToDelete;

            try
            {
                validate.ValidateIdParameter(id, "Delete");
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
                validate.ValidateIdParameter(id, "Get");
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
                validate.ValidateItemParameter(item, "Save");
                SaveItem(item);
                logger.LogInfo($"Item {item.Id} added to repository");
                        
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
