﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Validate<T, I> : IValidate<T, I> where T : IStoreable<I>
    {
        private ILogger logger;

        public Validate(ILogger logger)
        {
            if (logger == null) throw new ArgumentNullException("Logger cannot be null");

            this.logger = logger;
        }

        public void ValidateIdParameter(I id, string methodName)
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

        public void ValidateItemParameter(T item, string methodName)
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
    }
}
