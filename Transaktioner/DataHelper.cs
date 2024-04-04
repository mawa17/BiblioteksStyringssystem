namespace LibraryManagementSystem.Transactions
{
    public static class DataHelper
    {
        public static bool Add<TKey, TValue>(ref Dictionary<TKey, TValue> dict, KeyValuePair<TKey, TValue> kvp) where TKey : notnull => dict.TryAdd(kvp.Key, kvp.Value);

        public static IEnumerable<KeyValuePair<TKey, TValue>> Search<TKey, TValue>(this Dictionary<TKey, TValue> dict, Predicate<KeyValuePair<TKey, TValue>> predicate) where TKey : notnull
        {
            foreach (var kvp in dict)
            {
                if (predicate(kvp)) yield return kvp;
            }
        }
        public static void Show<TData>(in TData data)
        {
#if BUILD_CONSOLE

#elif BUILD_WINFORMS

#endif
        }
    }
}