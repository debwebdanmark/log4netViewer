using System.Collections.Generic;

namespace log4netViewer.MvcWeb.Models
{
    public class HomeIndexModel
    {
        public List<Log> Logs { get; private set; }

        public HomeIndexModel()
        {
            Logs = new List<Log>();
        }
    }
}