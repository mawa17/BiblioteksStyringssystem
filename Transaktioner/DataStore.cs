using LibraryManagementSystem.Datatypes;

namespace LibraryManagementSystem.Transactions
{
    public static class DataStore
    {
        //Primary-Key;(Name;Email;MemberId)
        public static Dictionary<uint, Member> Members = new();
        //Primary-Key;(BookQuantity;(Title;Author))
        public static Dictionary<uint, KeyValuePair<uint, Book>> Books = new();
    }
}