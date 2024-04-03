using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Transactions
{
    public static class DataLogger
    {
        public static void Log(string text, bool newLine = true, bool awaitKey = false)
        {
            if (newLine) Console.WriteLine(text);
            else Console.Write(text);
            if (awaitKey) Console.ReadKey();
        }
    }
}
