﻿using LibraryManagementSystem.Datatypes;
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

        public static IEnumerable<KeyValuePair<TKey, TValue>> Search2<TKey, TValue>(Dictionary<TKey, TValue> dict, Predicate<KeyValuePair<TKey, TValue>> predicate) where TKey : notnull
        {
            foreach (var kvp in dict)
            {
                if(predicate(kvp)) yield return kvp;
            }
        }
        public static void Show<TData>(in TData data)
        {
        }

        public static bool LendBook(Book book, Member member)
        {
            Search2(DataStore.Books, kvp => kvp.)
            var searchBook = Search(DataStore.Books, book);
            if (searchBook.Equals(default)) return false;
            var bookResult = DataStore.Books.FirstOrDefault(b => b.Value.Value == book);
        }
        public static void ReturnBook(Book book, Member member)
        {

        }

    }
}
