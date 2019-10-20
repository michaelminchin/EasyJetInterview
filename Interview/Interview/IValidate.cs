using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public interface IValidate<T, I> where T : IStoreable<I>
    {
        void ValidateIdNull(I id, string methodName);

        void ValidateItemNull(T item, string methodName);

        void ValidateItemExists(T item, string methodName, ICollection<T> items);

        void IdDoesntExist(I id, string methodName, ICollection<T> items);
    }
}
