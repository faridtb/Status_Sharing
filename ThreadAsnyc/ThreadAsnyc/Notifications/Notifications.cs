using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadAsnyc
{
    public static class Notifications
    {
        public static void Notification(ConsoleColor color, string notMessage)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(notMessage);
            Console.ResetColor();
        }
    }
}
