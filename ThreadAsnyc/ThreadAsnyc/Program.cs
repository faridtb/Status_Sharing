using System;

namespace ThreadAsnyc
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[0];
            Status[] statuses = new Status[0];
            int input;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ==  Menu == \n");
                Console.WriteLine("1)Creating new User\n" +
                    "2)For sharing new status \n" +
                    "3)Get all status \n" +
                    "4)Get status by status id\n" +
                    "5)Filter by sharing date\n" +
                    "6)Show All users And their Statuses\n" +
                    "0)Quit");
                Console.ResetColor();
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("User Name:");
                        string name = Console.ReadLine();
                        User user = new User(name);
                        Array.Resize(ref users, users.Length + 1);
                        users[users.Length - 1] = user;
                       Notifications.Notification(ConsoleColor.Blue,$"Good to see you {name} !");
                        break;

                    case 2:
                        Console.Clear();
                        if (users.Length > 0)
                        {
                            foreach (User item in users)
                            {
                                Console.WriteLine(item);
                            }
                            Console.Write("Please choose the user for sharing status\n" +
                                "User ID:");
                            int choice = int.Parse(Console.ReadLine());
                            foreach (User item in users)
                            {
                                if (item.ID == choice)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please write the Title of Status");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("Now,you able to write your own status, Write below..");
                                    string content = Console.ReadLine();
                                    Status status = new Status(title, content);
                                    item.ShareStatus(status);
                                    Array.Resize(ref statuses, statuses.Length + 1);
                                    statuses[statuses.Length - 1] = status;

                                }
                            }
                        }
                        else
                            Notifications.Notification(ConsoleColor.Red, "Firs you must create user ! ");
                        break;
                    case 3:
                        Console.Clear();
                        if (users.Length == 0 || statuses.Length == 0)
                            Notifications.Notification(ConsoleColor.Red, $"We havent found any status");
                        if (users.Length > 0 && statuses.Length>0)
                        {
                            foreach (User item in users)
                            {
                                Console.WriteLine(item);
                            }
                            Console.Write("Please choose the user for show their statuses: ");
                            int choice2 = int.Parse(Console.ReadLine());
                            bool test = false;
                            foreach (User item in users)
                            {
                                if (item.ID == choice2)
                                {
                                    item.GetAllStatuses();
                                    test = true;
                                }
                            }
                            if (test == false)
                                Notifications.Notification(ConsoleColor.Red, $"We havent found any user in this:{choice2} ID");
                        }
                        break;

                    case 4:
                        Console.Clear();
                        if (users.Length == 0 || statuses.Length == 0)
                            Notifications.Notification(ConsoleColor.Red, $"We havent found any status");
                        if (users.Length > 0 && statuses.Length > 0)
                        {
                            Console.Write("Please enter the id for search status:  ");
                            int choice3 = int.Parse(Console.ReadLine());
                            foreach (Status item in statuses)
                            {
                                if (item.Ids == choice3)
                                    Console.WriteLine(item);
                            }
                        }
                        break;

                    case 5:
                        Console.Clear();
                        if (users.Length == 0 || statuses.Length == 0)
                            Notifications.Notification(ConsoleColor.Red, $"We havent found any status");
                        if (users.Length > 0 && statuses.Length > 0)
                        {
                            foreach (Status item in statuses)
                                Console.WriteLine(item.SharedDate);

                            Console.Write("\nPlease enter the user ID: ");
                            int userId = int.Parse(Console.ReadLine());
                            Console.Write("\nPlease enter the date: ");
                            DateTime date = DateTime.Now;
                            bool test5 = false;

                            foreach (User item in users)
                            {
                                if (item.ID == userId)
                                {
                                    test5 = true;
                                    item.FilterStatusByDate(userId, date);
                                }
                            }
                            if (test5 == false)
                                Notifications.Notification(ConsoleColor.Red, $"We havent found any User in this:{userId} ID");
                        }
                        break;
                    case 6:
                        Console.Clear();
                        if (users.Length == 0 || statuses.Length == 0)
                            Notifications.Notification(ConsoleColor.Red, $"We havent found any status");
                        if (users.Length > 0 && statuses.Length > 0)
                        {
                            foreach (User item in users)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(item);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                item.GetAllStatuses();
                                Console.ResetColor();
                            }
                        }
                        break;
                    case 0:
                        break;

                }

            } while (input != 0);


        }
    }
    
}
