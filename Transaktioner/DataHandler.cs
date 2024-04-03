using LibraryManagementSystem.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Transactions
{
    public static class DataHandler
    {
        public static void Add<TKey, TValue>(ref Dictionary<TKey, TValue> dict, KeyValuePair<TKey, TValue> kvp) where TKey : notnull => dict.TryAdd(kvp.Key, kvp.Value);

        public static IEnumerable<KeyValuePair<TKey, TValue>> Search<TKey, TValue>(this Dictionary<TKey, TValue> dict, Predicate<KeyValuePair<TKey, TValue>> predicate) where TKey : notnull
        {
            foreach (var kvp in dict)
            {
                if(predicate(kvp)) yield return kvp;
            }
        }
        public static void Show<TData>(in TData data)
        {
        }

        pub

        public static void LendBook(Book book, Member member)
        {
            var memberSearch = DataStore.Members.Search(m => m.Value.Key == member).FirstOrDefault();
            if (memberSearch.Equals(default))
            {
                DataLogger.Log($"Medlem ved navn: {member.Name} findes ikke", awaitKey: true);
                return;
            }

            var bookSearch = DataStore.Books.Search(b => b.Value.Value == book).FirstOrDefault();
            if (bookSearch.Equals(default))
            {
                DataLogger.Log($"Bogen ved titel: {book.Title} eller forfatter: {book.Author} findes ikke", awaitKey: true);
                return;
            }

            if(memberSearch.Value.Value.Contains(bookSearch.Value.Value))
            {
                DataLogger.Log($"Medlemmet ved navn: {member.Name} har allreade lånt bogen ved titel: {book.Title}", awaitKey: true);
                return;
            }

            if(bookSearch.Key < 1)
            {
                DataLogger.Log($"Desværre har biblioteket ikke flere bøger med titel: {book.Title} til udlån", awaitKey: true);
                return;
            }

            DataStore.Books[bookSearch.Key] = new(DataStore.Books[bookSearch.Key].Key - 1, bookSearch.Value.Value); /*Lower book quantity by 1*/
            DataStore.Members[memberSearch.Key].Value.Add(bookSearch.Value.Value);
            DataLogger.Log($"Desværre har biblioteket ikke flere bøger med titel: {book.Title} til udlån", awaitKey: true);


        }
        public static void ReturnBook(Book book, Member member)
        {

        }

    }
}
