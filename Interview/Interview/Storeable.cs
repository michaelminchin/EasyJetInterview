﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview;

namespace Interview
{
    public class Storeable<T> : IStoreable<T>
    {
        private T id;

        public T Id
        {
            get => id;

            set => id = value;
        }
    }
}
