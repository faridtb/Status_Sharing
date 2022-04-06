using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadAsnyc.Exceptions
{
    class Exception
    {
        public static void NotFoundException(int? id)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\aSorry we haven't found any book in that {id} ID");
            Console.ResetColor();
        }
    }
}
