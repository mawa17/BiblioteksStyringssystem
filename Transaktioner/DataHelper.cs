using System.Text;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem.Transactions
{
    public static class DataHelper
    {
        public static bool Add<TKey, TValue>(ref Dictionary<TKey, TValue> dict, KeyValuePair<TKey, TValue> kvp) where TKey : notnull => dict.TryAdd(kvp.Key, kvp.Value);

        public static IEnumerable<KeyValuePair<TKey, TValue>> Search<TKey, TValue>(this Dictionary<TKey, TValue> dict, Func<KeyValuePair<TKey, TValue>, bool> predicate) where TKey : notnull
        {
            foreach (var kvp in dict)
            {
                if (predicate(kvp)) yield return kvp;
            }
        }

        public static void Show<TKey, TValue>(this Dictionary<TKey, TValue> dict, Func<KeyValuePair<TKey, TValue>, bool> predicate, out ushort totalPages, ushort pageIndex = 0, ushort colPerPage = 10, string? format = null) where TKey : notnull
        {
            var searchDict = dict.Search(predicate);
            if (searchDict == null)
            {
                totalPages = 0;
                return;
            }
            totalPages = (ushort)Math.Ceiling((decimal)(searchDict.Count() / colPerPage));

            foreach (var kvp in searchDict.Skip(pageIndex * colPerPage).Take(colPerPage))
            {
                StringBuilder sb = new StringBuilder(kvp.ToString());
                sb.Replace(" ", String.Empty);
                sb.Replace("[", String.Empty);
                sb.Replace("]", String.Empty);

                string result = Regex.Replace(sb.ToString(), "(\\b\\,(\\w+)(\\{\\w+.)|(\\,\\w+\\=)\\b)", ",");
                result = Regex.Replace(result, "(\\}.*)", String.Empty);


                DataLogger.Log(result);
            }
        }
    }
}