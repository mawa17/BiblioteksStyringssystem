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
            DataHandler.AddBook(new("Whispers in Twilight"), GetRandomQuantity());
            DataHandler.AddBook(new("Secrets of the Abyss"), GetRandomQuantity());
            DataHandler.AddBook(new("Echoes of Eternity"), GetRandomQuantity());
            DataHandler.AddBook(new("Shadows of the Past"), GetRandomQuantity());
            DataHandler.AddBook(new("Lost in Reflection"), GetRandomQuantity());
            DataHandler.AddBook(new("Mysteries Unveiled"), GetRandomQuantity());
            DataHandler.AddBook(new("Forgotten Memories"), GetRandomQuantity());
            DataHandler.AddBook(new("Dreams of Tomorrow"), GetRandomQuantity());
            DataHandler.AddBook(new("Spirits of the Night"), GetRandomQuantity());
            DataHandler.AddBook(new("Journey to the Unknown"), GetRandomQuantity());

            DataHandler.AddBook(new("A book", "A author"), GetRandomQuantity());
            DataHandler.AddBook(new("A book", "A author"), GetRandomQuantity());
            DataHandler.AddBook(new("A book", "A author"), GetRandomQuantity());
            DataHandler.AddBook(new("A book", "A author"), GetRandomQuantity());
            DataHandler.AddBook(new("A book", "A author"), GetRandomQuantity());
            DataHandler.AddBook(new("A book", "A author"), GetRandomQuantity());
            DataHandler.AddBook(new("A book", "A author"), GetRandomQuantity());
            DataHandler.AddBook(new("A book", "A author"), GetRandomQuantity());
            DataHandler.AddBook(new("A book", "A author"), GetRandomQuantity());
            DataHandler.AddBook(new("A book", "A author"), GetRandomQuantity());

    

            DataHandler.AddBook(new("The last book", "the last author"),   GetRandomQuantity());
        }
    }
}