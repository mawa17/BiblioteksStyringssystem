namespace LibraryManagementSystem.Transactions
{
    public static class DataPopulator
    {
        public static void PopulateMembers()
        {
            DataHandler.Add(ref DataStore.Members, new(0, new("Ava", "ava@mail.com")));
            DataHandler.Add(ref DataStore.Members, new(1, new("Max", "max@mail.com")));
            DataHandler.Add(ref DataStore.Members, new(2, new("Leo", "leo@mail.com")));
            DataHandler.Add(ref DataStore.Members, new(3, new("Mia", "mia@mail.com")));
            DataHandler.Add(ref DataStore.Members, new(4, new("Zoe", "zoe@mail.com")));
            DataHandler.Add(ref DataStore.Members, new(5, new("Kai", "kai@mail.com")));
            DataHandler.Add(ref DataStore.Members, new(6, new("Eva", "eva@mail.com")));
            DataHandler.Add(ref DataStore.Members, new(7, new("Jay", "jay@mail.com")));
            DataHandler.Add(ref DataStore.Members, new(8, new("Ivy", "ivy@mail.com")));
            DataHandler.Add(ref DataStore.Members, new(9, new("Sam", "sam@mail.com")));
        }

        private static Random rand = new Random();
        private static uint GetRandomQuantity(uint maxBooks = 10) => (uint)rand.Next(0, (int)maxBooks);
        public static void PopulateBooks()
        {
            DataHandler.Add(ref DataStore.Books, new(0, new(GetRandomQuantity(), new("The Hidden Key", "Alex Stone"))));
            DataHandler.Add(ref DataStore.Books, new(1, new(GetRandomQuantity(), new("Echoes of Eternity", "Emily Rivers"))));
            DataHandler.Add(ref DataStore.Books, new(2, new(GetRandomQuantity(), new("Beyond the Horizon", "Benjamin Knight"))));
            DataHandler.Add(ref DataStore.Books, new(3, new(GetRandomQuantity(), new("Whispers in the Dark", "Sarah Clarke"))));
            DataHandler.Add(ref DataStore.Books, new(4, new(GetRandomQuantity(), new("Lost in Time", "Jason Brooks"))));
            DataHandler.Add(ref DataStore.Books, new(5, new(GetRandomQuantity(), new("Shadow of the Crescent", "Natalie Reed"))));
            DataHandler.Add(ref DataStore.Books, new(6, new(GetRandomQuantity(), new("The Enigma Chronicles", "Daniel Parker"))));
            DataHandler.Add(ref DataStore.Books, new(7, new(GetRandomQuantity(), new("Sands of Destiny", "Olivia Hayes"))));
            DataHandler.Add(ref DataStore.Books, new(8, new(GetRandomQuantity(), new("In the Realm of Shadows", "Matthew Evans"))));
            DataHandler.Add(ref DataStore.Books, new(9, new(GetRandomQuantity(), new("The Forgotten Prophecy", "Rachel Carter"))));
        }
    }
}