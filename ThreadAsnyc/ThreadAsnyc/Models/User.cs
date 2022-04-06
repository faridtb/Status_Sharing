using System;
using System.Collections.Generic;

namespace ThreadAsnyc
{
    class User
    {
        private static int _id;
        public int ID { get; }
        public string Username { get; set; }

        List<Status> statuses = new List<Status>();

        public User(string username)
        {
            _id++;
            ID = _id;
            statuses = new List<Status>();
            Username = username;

        }

        /// <summary>
        /// For sharing status
        /// </summary>
        /// <param name="st"></param>
        public void ShareStatus(Status st)
        {
            statuses.Add(st);
        }

        /// <summary>
        /// Find status by id
        /// </summary>
        /// <param name="ids"></param>
        public void GetStatusById(int? ids)
        {
            bool exist = false;
            foreach (Status item in statuses)
            {
                if (item.Ids == ids)
                {
                    exist = true;
                    Console.WriteLine(item);
                }
            }
            if (exist == false)
                Notifications.Notification(ConsoleColor.Red,$"There is no status in this:{ids} id");
        }

        /// <summary>
        /// Get all status
        /// </summary>
        public void GetAllStatuses()

        {
            foreach (Status item in statuses)
            {
                Console.WriteLine(item);
                Console.WriteLine("-----------------------");
            }
        }

        /// <summary>
        /// Filtering status by date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        public void FilterStatusByDate(int? id, DateTime date)
        {
            if (id==ID)
            {
                foreach (Status item in statuses)
                {
                    if (date>=item.SharedDate)
                        Console.WriteLine(item);
                }
            }
            else
                Notifications.Notification(ConsoleColor.Red,$"There is no user in this:{id} ID");
        }
        public override string ToString()
        {
            return $"User ID: {ID}\n" +
                $"Username:{Username}\n";      
        }
    }
}
