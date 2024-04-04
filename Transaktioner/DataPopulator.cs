namespace LibraryManagementSystem.Transactions
{
    public static class DataPopulator
    {
        public static void PopulateMembers()
        {
            DataHelper.Add(ref DataStore.Members, new(0, new(new("Ava", "ava@mail.com"), new())));
            DataHelper.Add(ref DataStore.Members, new(1, new(new("Max", "max@mail.com"), new())));
            DataHelper.Add(ref DataStore.Members, new(2, new(new("Leo", "leo@mail.com"), new())));
            DataHelper.Add(ref DataStore.Members, new(3, new(new("Mia", "mia@mail.com"), new())));
            DataHelper.Add(ref DataStore.Members, new(4, new(new("Zoe", "zoe@mail.com"), new())));
            DataHelper.Add(ref DataStore.Members, new(5, new(new("Kai", "kai@mail.com"), new())));
            DataHelper.Add(ref DataStore.Members, new(6, new(new("Eva", "eva@mail.com"), new())));
            DataHelper.Add(ref DataStore.Members, new(7, new(new("Jay", "jay@mail.com"), new())));
            DataHelper.Add(ref DataStore.Members, new(8, new(new("Ivy", "ivy@mail.com"), new())));
            DataHelper.Add(ref DataStore.Members, new(9, new(new("Sam", "sam@mail.com"), new())));
        }

        private static Random rand = new Random();
        private static uint GetRandomQuantity(uint maxBooks = 10) => (uint)rand.Next(0, (int)maxBooks);
        public static void PopulateBooks()
        {
            DataHandler.AddBook(new("The Hidden Key",           "Alex Stone"),      GetRandomQuantity());
            DataHandler.AddBook(new("Echoes of Eternity",       "Emily Rivers"),    GetRandomQuantity());
            DataHandler.AddBook(new("Beyond the Horizon",       "Benjamin Knight"), GetRandomQuantity());
            DataHandler.AddBook(new("Whispers in the Dark",     "Sarah Clarke"),    GetRandomQuantity());
            DataHandler.AddBook(new("Lost in Time",             "Jason Brooks"),    GetRandomQuantity());
            DataHandler.AddBook(new("Shadow of the Crescen",    "Natalie Reed"),    GetRandomQuantity());
            DataHandler.AddBook(new("The Enigma Chronicles",    "Daniel Parker"),   GetRandomQuantity());
            DataHandler.AddBook(new("Sands of Destiny",         "Olivia Hayes"),    GetRandomQuantity());
            DataHandler.AddBook(new("In the Realm of Shadows",  "Matthew Evans"),   GetRandomQuantity());
            DataHandler.AddBook(new("In the Realm of Shadows",  "Rachel Carter"),   GetRandomQuantity());
        }
    }
}