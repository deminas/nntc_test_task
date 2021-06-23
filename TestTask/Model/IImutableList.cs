using System.Collections.Generic;

namespace TestTask.Data
{
    public interface IImutableList<T> : IEnumerable<T>
    {
        IImutableList<T> Add(T value);

        IImutableList<T> Pop();

        IImutableList<T> Join(IImutableList<T> other);

        IImutableList<T> Delete(int index);
    }
}
