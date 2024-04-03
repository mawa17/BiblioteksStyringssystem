using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Transactions
{
    public static class DataHelper
    {
        public static void Add<TKey, TValue>(ref Dictionary<TKey, TValue> dict, KeyValuePair<TKey, TValue> kvp) where TKey : notnull => dict.TryAdd(kvp.Key, kvp.Value);

        public static IEnumerable<KeyValuePair<TKey, TValue>> Search<TKey, TValue>(this Dictionary<TKey, TValue> dict, Predicate<KeyValuePair<TKey, TValue>> predicate) where TKey : notnull
        {
            foreach (var kvp in dict)
            {
                if (predicate(kvp)) yield return kvp;
            }
        }
        public static void Show<TData>(in TData data)
        {
        }
    }
}
