using LibraryManagementSystem.Datatypes;

namespace LibraryManagementSystem.Transactions
{
    public static class DataHandler
    {
        #region Book
        public static bool AddBook(Book book, uint quantity)
        {
            uint bookId = (uint)(DataStore.Books.Count > 0 ? DataStore.Books.Count + 1 : 0);
            return DataHelper.Add(ref DataStore.Books, new(bookId, new(quantity, book)));
        }
        public static bool SetBookQuantity(Book book, uint quantity)
        {
            var bookSearch = DataStore.Books.Search(b => b.Value.Value == book).FirstOrDefault();
            if (bookSearch.Equals(default)) return false;
            DataStore.Books[bookSearch.Key] = new(quantity, bookSearch.Value.Value);
            return true;
        }
        public static bool RemoveBook(Book book)
        {
            var bookSearch = DataStore.Books.Search(b => b.Value.Value == book).FirstOrDefault();
            if (bookSearch.Equals(default)) return false;
            return DataStore.Books.Remove(bookSearch.Key);
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

            if(memberSearch.Value.Value.Any(b => b.book == bookSearch.Value.Value))
            {
                DataLogger.Log($"Medlemmet ved navn: {member.Name} har allreade lånt bogen ved titel: {book.Title}", awaitKey: true);
                return;
            }

            if(bookSearch.Key < 1)
            {
                DataLogger.Log($"Desværre har biblioteket ikke flere bøger med titel: {book.Title} til udlån", awaitKey: true);
                return;
            }

            SetBookQuantity(book, DataStore.Books[bookSearch.Key].Key - 1);/*Decrease book quantity by 1*/
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

            int booksLended = DataStore.Members[memberSearch.Key].Value.RemoveWhere(b => b.book.Equals(bookSearch.Value));
            SetBookQuantity(book, (uint)(DataStore.Books[bookSearch.Key].Key + booksLended)); /*Increase book quantity by quantity member has lended (Should be 1 as we restrict the quantity in lendBook)*/

            var bookLog = memberSearch.Value.Value.FirstOrDefault(b => b.book == book);
            if(bookLog?.DaysExceededReturnDate > 0.0) 
            {
                DataLogger.Log($"Medlem har overtrådt sidste returdag med {bookLog.DaysExceededReturnDate} dage!");
                DataLogger.Log($"Bogen med titel: {book.Title} blev lånt den: {bookLog.lendDate.ToString("yyyy/MM/dd")} til idag: {bookLog.returnDate.ToString("yyyy/MM/dd")}");
            }
            DataLogger.Log($"Medlem har nu returneret den udlånte bog med titel: {book.Title}", awaitKey: true);
        }
        #endregion

        #region Member
        public static bool AddMember(Member member)
        {
            uint memberId = (uint)(DataStore.Members.Count > 0 ? DataStore.Members.Count + 1 : 0);
            return DataHelper.Add(ref DataStore.Members, new(memberId, new(member, new())));
        }
        public static bool RemoveMember(Member member)
        {
            var memberSearch = DataStore.Members.Search(m => m.Value.Key == member).FirstOrDefault();
            if (memberSearch.Equals(default)) return false;
            return DataStore.Members.Remove(memberSearch.Key);
        }

        public static bool SetMemberData(Member member, Member newMember)
        {
            var memberSearch = DataStore.Members.Search(m => m.Value.Key == member).FirstOrDefault();
            if (memberSearch.Equals(default)) return false;
            Member updatedMember = DataStore.Members[memberSearch.Key].Key with 
            { 
                Name = newMember?.Name ?? memberSearch.Value.Key.Name,
                Email = newMember?.Email ?? memberSearch.Value.Key.Email 
            };
            DataStore.Members[memberSearch.Key] = new(updatedMember, memberSearch.Value.Value);
            return true;
        }
        #endregion
    }
}