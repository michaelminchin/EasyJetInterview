using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public interface IValidate<T, I> where T : IStoreable<I>
    {
        void ValidateIdParameter(I id, string methodName);

        void ValidateItemParameter(T item, string methodName);
    }
}
