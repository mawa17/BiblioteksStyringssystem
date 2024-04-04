namespace LibraryManagementSystem.Transactions
{
    public static class DataLogger
    {
#if BUILD_CONSOLE
        public static void Log(string text, bool newLine = true, bool awaitKey = false, char arraySplit = default)
        {
            if(arraySplit != default)
            {
                var array = text.Split(arraySplit);
                ushort buffer = (ushort)Math.Clamp(text.Length, 0, Console.WindowWidth);
                for (int i = 0; i < array.Length; i++)
                {
                    if(i == 0)
                    {
                        Console.WriteLine(array[i]);
                        continue;
                    }

             
                }
            }
            else
            {
                if (newLine) Console.WriteLine(text);
                else Console.Write(text);
                if (awaitKey) Console.ReadKey();
            }
        }
#elif BUILD_WINFORMS

#endif
    }
}