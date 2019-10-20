﻿using System;
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
