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
        public T Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
