namespace LibraryManagementSystem.Transactions
{
    public static class DataLogger
    {
#if BUILD_CONSOLE
        public static void Log(string text, bool newLine = true, bool awaitKey = false)
        {
            if (newLine) Console.WriteLine(text);
            else Console.Write(text);
            if (awaitKey) Console.ReadKey();
        }
#elif BUILD_WINFORMS

#endif
    }
}