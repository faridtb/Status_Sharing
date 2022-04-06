using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadAsnyc
{
    class Status
    {
        private static int _ids;
        public int Ids { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SharedDate { get; set; }

        public Status(string title,string content)
        {
            _ids++;
            Ids = _ids;
            Title = title;
            Content = content;
            SharedDate = DateTime.Now;
        }

        public string GetStatusInfo()
        {
            TimeSpan span = DateTime.Now - SharedDate;
            return $"Status ID: {Ids}\n" +
                 $"Title: {Title}\n" +
                 $"Content: {Content} (shared {span.Seconds} second ago)\n";

        }
        public override string ToString()
        {
            return GetStatusInfo();
        }
    }
}
