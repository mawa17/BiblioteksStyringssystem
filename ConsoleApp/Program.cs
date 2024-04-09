using LibraryManagementSystem.Datatypes;
using LibraryManagementSystem.Transactions;
using System.Linq;

#region Init
DataPopulator.PopulateMembers();
DataPopulator.PopulateBooks();
#endregion

#region MenuHelper
static void PrintCenter(string text) => Console.WriteLine(new string('=', (((text.Length % 2 != 0) ? (Console.WindowWidth - 1) : Console.WindowWidth) / 2) - (text.Length / 2)) + text + new string('=', (Console.WindowWidth / 2) - (text.Length / 2)));
static void PrintLine() => Console.WriteLine(new string('=', Console.WindowWidth));
#endregion
#region Menu
static ConsoleKey RootMenu()
{
    Console.Clear();
    PrintCenter("Biblioteks Styringssystem");
    DataLogger.Log("(Tryk 1) Bogstyring");
    DataLogger.Log("(Tryk 2) Medlemsstyring");
    return Console.ReadKey(true).Key;
}
static ConsoleKey BookMenu()
{
    Console.Clear();
    PrintCenter("Bogstyring");
    DataLogger.Log("(Tryk 1) Tilføj bog");
    DataLogger.Log("(Tryk 2) Fjern bog");
    DataLogger.Log("(Tryk 3) Vis alle bøger");
    DataLogger.Log("(Tryk 4) Søg efter bog");
    DataLogger.Log("(Tryk 5) Udlån bog");
    DataLogger.Log("(Tryk 6) Aflever bog");
    DataLogger.Log("(Tryk 7) Ændre antal af bøger på lager");
    return Console.ReadKey(true).Key;
}
static ConsoleKey MemberMenu()
{
    Console.Clear();
    PrintCenter("Medlemsstyring");
    DataLogger.Log("(Tryk 1) Tilføj medlem");
    DataLogger.Log("(Tryk 2) Fjern medlem");
    DataLogger.Log("(Tryk 3) Vis alle medlemmere");
    DataLogger.Log("(Tryk 4) Søg efter medlem");
    DataLogger.Log("(Tryk 5) Ændre medlemsoplysninger");
    DataLogger.Log("(Tryk 6) Vis medlemmer med bøger som har overskredet returdatoen");
    return Console.ReadKey(true).Key;
}

while (true)
{
    ConsoleKey rootKey = RootMenu();
    ConsoleKey bookKey = default;
    ConsoleKey memberKey = default;
    switch (rootKey)
    {
        case ConsoleKey.D1:
        case ConsoleKey.NumPad1: bookKey = BookMenu(); break;

        case ConsoleKey.D2:
        case ConsoleKey.NumPad2: memberKey = MemberMenu(); break;
    }

    if (bookKey != default)
    {
        Console.Clear();
        switch (bookKey)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1: {
                PrintCenter("Bogstyring : Tilføj bog");
                var bookTitle = DataHelper.Ask<string>("Skriv bog titel: ");
                if (bookTitle is null) { DataLogger.Log("Bogens titel må ikke være tom prøv igen", awaitKey: true); return; }
                var bookAuthor = DataHelper.Ask<string>("Skriv bog forfatter: ");
                var bookQuantity = DataHelper.Ask<uint>("Skriv antallet af bøger: ");
                if(!DataHandler.AddBook(new(bookTitle, bookAuthor), bookQuantity)) { DataLogger.Log("Kunne ikke tilføje bogen (Noget gik galt)", awaitKey: true); return; }
                DataLogger.Log($"Bogen med titel: {bookTitle} af forfatter: {bookAuthor} blev tilføjet {bookQuantity} gange", awaitKey: true);
            } break;

            case ConsoleKey.D2:
            case ConsoleKey.NumPad2: {
                PrintCenter("Bogstyring : Fjern bog");
                var bookTitle = DataHelper.Ask<string>("Skriv bog titel: ");
                if (bookTitle is null) { DataLogger.Log("Bogens titel må ikke være tom prøv igen", awaitKey: true); return; }
                var bookAuthor = DataHelper.Ask<string>("Skriv bog forfatter: ");
                if(!DataHandler.RemoveBook(new(bookTitle, bookAuthor))) { DataLogger.Log("Kunne ikke fjerne bogen (Noget gik galt)", awaitKey: true); return; }
                DataLogger.Log($"Bogen med titel: {bookTitle} af forfatter: {bookAuthor} blev fjernet", awaitKey: true);
            } break;

            case ConsoleKey.D3:
            case ConsoleKey.NumPad3: {
                PrintCenter("Bogstyring : Vis alle bøger");
                ushort totalPages = 0;
                ushort pageIndex = 0;
                do {
                    Console.Clear();
                    DataLogger.Log("[Bog Id],[Antal],[Titel],[Forfatter]", arraySplit: ',');
                    DataStore.Books.Show(x => !x.Equals(null), out totalPages, pageIndex);
                    ++pageIndex;
                    if(pageIndex - 1 < totalPages) DataLogger.Log("Næste side?", awaitKey: true);
                } while (pageIndex-1 < totalPages);
            } break;

            case ConsoleKey.D4:
            case ConsoleKey.NumPad4: {
                PrintCenter("Bogstyring : Søg efter bog");
                var bookTitle = DataHelper.Ask<string>("Skriv bog titel: ");
                if (bookTitle is null) { DataLogger.Log("Bogens titel må ikke være tom prøv igen", awaitKey: true); return; }
                var bookAuthor = DataHelper.Ask<string>("Skriv bog forfatter: ");

                var searchBooks = DataStore.Books.Search(b => b.Value.Value.Equals(new(bookTitle, bookAuthor))).ToDictionary(x => x.Key, x => x.Value);
                ushort totalPages = 0;
                ushort pageIndex = 0;
                do
                {
                    Console.Clear();
                    DataLogger.Log("[Bog Id],[Antal],[Titel],[Forfatter]", arraySplit: ',');
                    searchBooks.Show(x => !x.Equals(null), out totalPages, pageIndex);

                     ++pageIndex;
                    if (pageIndex - 1 < totalPages) DataLogger.Log("Næste side?", awaitKey: true);
                } while (pageIndex - 1 < totalPages);
            } break;

            case ConsoleKey.D5:
            case ConsoleKey.NumPad5:  {
                PrintCenter("Bogstyring : Udlån bog");
                var bookTitle = DataHelper.Ask<string>("Skriv bog titel: ");
                if (bookTitle is null) { DataLogger.Log("Bogens titel må ikke være tom prøv igen", awaitKey: true); return; }
                var bookAuthor = DataHelper.Ask<string>("Skriv bog forfatter: ");

                var memberName = DataHelper.Ask<string>("Skriv medlem navn: ");
                if (memberName is null) { DataLogger.Log("medlem navn må ikke være tom prøv igen", awaitKey: true); return; }
                var memberEmail = DataHelper.Ask<string>("Skriv medlem email: ");

                var lendDays = DataHelper.Ask<ushort>("Skriv date bogen må lånes: ");
                DataHandler.LendBook(new(bookTitle, bookAuthor), new(memberName, memberEmail), lendDays);
            } break;

            case ConsoleKey.D6:
            case ConsoleKey.NumPad6:{
                PrintCenter("Bogstyring : Aflever bog");
                var bookTitle = DataHelper.Ask<string>("Skriv bog titel: ");
                if (bookTitle is null) { DataLogger.Log("Bogens titel må ikke være tom prøv igen", awaitKey: true); return; }
                var bookAuthor = DataHelper.Ask<string>("Skriv bog forfatter: ");

                var memberName = DataHelper.Ask<string>("Skriv medlem navn: ");
                if (memberName is null) { DataLogger.Log("medlem navn må ikke være tom prøv igen", awaitKey: true); return; }
                var memberEmail = DataHelper.Ask<string>("Skriv medlem email: ");

                DataHandler.ReturnBook(new(bookTitle, bookAuthor), new(memberName, memberEmail));

                }
                break;

            case ConsoleKey.D7:
            case ConsoleKey.NumPad7: {
                PrintCenter("Bogstyring : Ændre antal af bøger på lager");

                var bookTitle = DataHelper.Ask<string>("Skriv bog titel: ");
                if (bookTitle is null) { DataLogger.Log("Bogens titel må ikke være tom prøv igen", awaitKey: true); return; }
                var bookAuthor = DataHelper.Ask<string>("Skriv bog forfatter: ");

                var newQuantity = DataHelper.Ask<ushort>("Skriv det nye antal: ");

                if (!DataHandler.SetBookQuantity(new(bookTitle, bookAuthor), newQuantity)) { DataLogger.Log("Kunne ikke ændre bogens antal (Noget gik galt)", awaitKey: true); return; }
                DataLogger.Log($"Bogens antal er nu ændret", awaitKey: true);

            }break;
        }
    }
    else if (memberKey != default)
    {
        Console.Clear();
        switch (memberKey)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1: {
                PrintCenter("Medlemsstyring : Tilføj medlem");

                var memberName = DataHelper.Ask<string>("Skriv navn: ");
                if (memberName is null) { DataLogger.Log("medlemmets navn må ikke være tom prøv igen", awaitKey: true); return; }
                var memberEmail = DataHelper.Ask<string>("Skriv email: ");
                if (!DataHandler.AddMember(new(memberName, memberEmail))) { DataLogger.Log($"Kunne ikke tilføje medlem (Noget gik galt)", awaitKey: true); return; }
                DataLogger.Log($"Medlem tilføjet", awaitKey: true);
                }break;

            case ConsoleKey.D2:
            case ConsoleKey.NumPad2: {
                PrintCenter("Medlemsstyring : Fjern medlem");
                var memberName = DataHelper.Ask<string>("Skriv navn: ");
                if (memberName is null) { DataLogger.Log("medlemmets navn må ikke være tom prøv igen", awaitKey: true); return; }
                var memberEmail = DataHelper.Ask<string>("Skriv email: ");
                if (!DataHandler.RemoveMember(new(memberName, memberEmail))) { DataLogger.Log($"Kunne ikke fjerne medlem (Noget gik galt)", awaitKey: true); return; }
                DataLogger.Log($"Medlem fjernet", awaitKey: true);
                }break;

            case ConsoleKey.D3:
            case ConsoleKey.NumPad3: {
                PrintCenter("Medlemsstyring : Vis alle medlemmere");
                ushort totalPages = 0;
                ushort pageIndex = 0;
                do
                {
                    Console.Clear();
                    DataLogger.Log("[Medlem Id],[Navn],[Email]", arraySplit: ',');
                    DataStore.Members.Show(x => !x.Equals(null), out totalPages, pageIndex);
                    ++pageIndex;
                    if (pageIndex - 1 < totalPages) DataLogger.Log("Næste side?", awaitKey: true);
                } while (pageIndex - 1 < totalPages);
                }break;

            case ConsoleKey.D4:
            case ConsoleKey.NumPad4: {
                PrintCenter("Medlemsstyring : Søg efter medlem");
                var memberName = DataHelper.Ask<string>("Skriv navn: ");
                if (memberName is null) { DataLogger.Log("medlemmets navn må ikke være tom prøv igen", awaitKey: true); return; }
                var memberEmail = DataHelper.Ask<string>("Skriv email: ");

                var searchMembers = DataStore.Members.Search(b => b.Value.Key.Equals(new(memberName, memberEmail))).ToDictionary(x => x.Key, x => x.Value);
                ushort totalPages = 0;
                ushort pageIndex = 0;
                do
                {
                    Console.Clear();
                    DataLogger.Log("[Bog Id],[Antal],[Titel],[Forfatter]", arraySplit: ',');
                    searchMembers.Show(x => !x.Equals(null), out totalPages, pageIndex);

                    ++pageIndex;
                    if (pageIndex - 1 < totalPages) DataLogger.Log("Næste side?", awaitKey: true);
                } while (pageIndex - 1 < totalPages);
                }break;

            case ConsoleKey.D5:
            case ConsoleKey.NumPad5: {
                PrintCenter("Medlemsstyring : Ændre medlemsoplysninger");

                var memberName = DataHelper.Ask<string>("Skriv navn: ");
                if (memberName is null) { DataLogger.Log("medlemmets navn må ikke være tom prøv igen", awaitKey: true); return; }
                var memberEmail = DataHelper.Ask<string>("Skriv email: ");

                var memberNameNew = DataHelper.Ask<string>("Skriv NYE navn: ");
                if (memberNameNew is null) { DataLogger.Log("medlemmets navn må ikke være tom prøv igen", awaitKey: true); return; }
                var memberEmailNew = DataHelper.Ask<string>("Skriv NYE email: ");
                if(!DataHandler.SetMemberData(new(memberName, memberEmail), new(memberNameNew, memberEmailNew))) { DataLogger.Log($"Kunne ikke ændre medlem (Noget gik galt)", awaitKey: true); return; }
            }break;

            case ConsoleKey.D6:
            case ConsoleKey.NumPad6:
                {
                    PrintCenter("Medlemsstyring : Vis medlemmer med bøger som har overskredet returdatoen");
                    var searchMembers = DataStore.Members.Search(b => b.Value.Value.Count > 0).Where(x => x.Value.Value.Any(y => y.DaysExceededReturnDate > 0.0)).ToDictionary(x => x.Key, x => x.Value);
                    ushort totalPages = 0;
                    ushort pageIndex = 0;
                    do
                    {
                        Console.Clear();
                        DataLogger.Log("[Bog Id],[Antal],[Titel],[Forfatter]", arraySplit: ',');
                        searchMembers.Show(x => !x.Equals(null), out totalPages, pageIndex);

                        ++pageIndex;
                        if (pageIndex - 1 < totalPages) DataLogger.Log("Næste side?", awaitKey: true);
                    } while (pageIndex - 1 < totalPages);
                } break;
        }
    }
    Console.ReadKey();
}
#endregion