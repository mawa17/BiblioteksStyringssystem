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
        public static void AddBook(Book book, uint quantity) => DataHelper.Add(ref DataStore.Books, new((uint)(DataStore.Books.Count > 0 ? DataStore.Books.Count + 1 : 0), new(quantity, book)));
        public static void SetBookQuantity(Book book, uint quantity)
        {
            var bookSearch = DataStore.Books.Search(b => b.Value.Value == book).FirstOrDefault();
            if (bookSearch.Equals(default)) AddBook(book, quantity);
            DataStore.Books[bookSearch.Key] = new(quantity, bookSearch.Value.Value);
        }
        public static void RemoveBook(Book book)
        {
            var bookSearch = DataStore.Books.Search(b => b.Value.Value == book).FirstOrDefault();
            if (bookSearch.Equals(default)) return;
            DataStore.Books.Remove(bookSearch.Key);
        }

        public static void LendBook(Book book, Member member, ushort maxLendDays = 7)
        {
            var memberSearch = DataStore.Members.Search(m => m.Value.Key == member).FirstOrDefault();
            if (memberSearch.Equals(default))
            {
                DataLogger.Log($"Medlem ved navn: {member.Name} er ikke registeret hos biblioteket", awaitKey: true);
                return;
            }

            var bookSearch = DataStore.Books.Search(b => b.Value.Value == book).FirstOrDefault();
            if (bookSearch.Equals(default))
            {
                DataLogger.Log($"Bogen ved titel: {book.Title} eller forfatter: {book.Author} er ikke registeret hos biblioteket", awaitKey: true);
                return;
            }

            if(memberSearch.Value.Value.Contains(b => b.book == bookSearch.Value.Value))
            {
                DataLogger.Log($"Medlemmet ved navn: {member.Name} har allreade lånt bogen ved titel: {book.Title}", awaitKey: true);
                return;
            }

            if(bookSearch.Key < 1)
            {
                DataLogger.Log($"Desværre har biblioteket ikke flere bøger med titel: {book.Title} til udlån", awaitKey: true);
                return;
            }

            SetBookQuantity(book, DataStore.Books[bookSearch.Key].Key - 1);/*Lower book quantity by 1*/
            BookLog bookLog = new(bookSearch.Value.Value, memberSearch.Value.Key, maxLendDays);
            DataStore.Members[memberSearch.Key].Value.Add(bookLog);
            DataLogger.Log($"Medlem har nu lånt bogen med titel: {book.Title} af forfatter: {book.Author}");
            DataLogger.Log($"Bogen må være udlånt i {maxLendDays} dage fra den: {bookLog.lendDate.ToString("yyyy/MM/dd")} til den: {bookLog.returnDate.ToString("yyyy/MM/dd")}", awaitKey: true);
        }
        public static void ReturnBook(Book book, Member member)
        {
            var memberSearch = DataStore.Members.Search(m => m.Value.Key == member).FirstOrDefault();
            if (memberSearch.Equals(default))
            {
                DataLogger.Log($"Medlem ved navn: {member.Name} er ikke registeret hos biblioteket", awaitKey: true);
                return;
            }

            var bookSearch = DataStore.Books.Search(b => b.Value.Value == book).FirstOrDefault();
            if (bookSearch.Equals(default))
            {
                DataLogger.Log($"Bogen ved titel: {book.Title} eller forfatter: {book.Author} er ikke registeret hos biblioteket", awaitKey: true);
                return;
            }

            if (!memberSearch.Value.Value.Any(b => b.book == bookSearch.Value.Value))
            {
                DataLogger.Log($"Medlemmet ved navn: {member.Name} har IKKE lånt bogen ved titel: {book.Title} og kan derfor ikke aflevere den", awaitKey: true);
                return;
            }
        }

    }
}
