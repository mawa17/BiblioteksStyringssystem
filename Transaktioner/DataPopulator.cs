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
            DataHandler.AddBook(new("The Midnight Mirage", "Penelope Evergreen"), GetRandomQuantity());
            DataHandler.AddBook(new("Whispers in the Mist", "Maxwell Hawthorne"), GetRandomQuantity());
            DataHandler.AddBook(new("The Forgotten Chronicles", "Arabella Nightingale"), GetRandomQuantity());
            DataHandler.AddBook(new("Echoes of Destiny", "Jasper Blackwood"), GetRandomQuantity());
            DataHandler.AddBook(new("The Secret Key of Serendipity", "Eliza Moonstone"), GetRandomQuantity());
            DataHandler.AddBook(new("Shadows of Redemption", "Nathaniel Silver"), GetRandomQuantity());
            DataHandler.AddBook(new("The Enigmatic Enchantress", "Gwendolyn Thorne"), GetRandomQuantity());
            DataHandler.AddBook(new("The Last Ember", "Oliver Ravenscroft"), GetRandomQuantity());
            DataHandler.AddBook(new("Lost in Time and Space", "Matilda Whitaker"), GetRandomQuantity());
            DataHandler.AddBook(new("Echoes of the Evergreen", "Theodore Everhart"), GetRandomQuantity());   
            DataHandler.AddBook(new("The Emerald Isle Conspiracy", "Rosalind Winters"), GetRandomQuantity());
            DataHandler.AddBook(new("Sands of Solitude", "Sebastian Ashford"), GetRandomQuantity());
            DataHandler.AddBook(new("The Silver Serpent's Secret", "Adelaide Sterling"), GetRandomQuantity());
            DataHandler.AddBook(new("The Sapphire Cipher", "Felix Hawthorne"), GetRandomQuantity());
            DataHandler.AddBook(new("Fragments of Fate", "Arabella Davenport"), GetRandomQuantity());
            DataHandler.AddBook(new("The Phantom's Lament", "Montgomery Fairfax"), GetRandomQuantity());
            DataHandler.AddBook(new("The Celestial Chronicles", "Isadora Nightshade"), GetRandomQuantity());
            DataHandler.AddBook(new("The Golden Gatekeeper", "Winston Ashcroft"), GetRandomQuantity());
            DataHandler.AddBook(new("Whispers of the Wind", "Seraphina Ravenscroft"), GetRandomQuantity());
            DataHandler.AddBook(new("The Amethyst Amulet", "Bartholomew Sinclair"), GetRandomQuantity());
            DataHandler.AddBook(new("The Shadowed Sanctuary", "Ophelia Ravenscroft"), GetRandomQuantity());
            DataHandler.AddBook(new("Echoes of Elysium", "Archibald Beaumont"), GetRandomQuantity());
            DataHandler.AddBook(new("The Cursed Crown", "Cordelia Thornwood"), GetRandomQuantity());
            DataHandler.AddBook(new("The Crystal Codex", "Reginald Montague"), GetRandomQuantity());
            DataHandler.AddBook(new("Echoes of Emberglow", "Octavia Whitaker"), GetRandomQuantity());


        }
    }
}