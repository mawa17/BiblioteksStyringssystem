﻿namespace LibraryManagementSystem.Transactions
{
    public static class DataLogger
    {
#if BUILD_CONSOLE
        public static void Log(string text, bool newLine = true, bool awaitKey = false, char arraySplit = default)
        {
            if(arraySplit != default)
            {
                string[] array = text.Split(Environment.NewLine);

                foreach (string item in array)
                {
                    string[] curr = item.Split(arraySplit);
                    for (int i = 0; i < curr.Length; i++)
                    {
                        Console.Write($"{curr[i]}".PadRight(30));
                    }
                    Console.Write(Environment.NewLine);
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