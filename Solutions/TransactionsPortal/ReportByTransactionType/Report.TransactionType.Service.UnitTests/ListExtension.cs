using System.Collections.Generic;

namespace Report.TransactionType.Service.UnitTests
{
    public static class ListExtension
    {
        public static bool TryGetElement<T>(this List<T> array, int index, out T element)
        {
            if (index < array.Count)
            {
                element = array[index];
                return true;
            }
            element = default;
            return false;
        }
    }
}
