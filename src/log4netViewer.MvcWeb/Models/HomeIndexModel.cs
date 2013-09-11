using System.Collections.Generic;
using System.Web.Mvc;
using log4netViewer.MvcWeb.Extensions;

namespace log4netViewer.MvcWeb.Models
{
    public class HomeIndexModel
    {
        public List<Log> Logs { get; private set; }

        public string SelectedLogDatabase { get; set; }
        public List<SelectListItem> LogDatabases { get; set; }

        public string SelectedLogDatabaseName
        {
            get
            {
                if (SelectedLogDatabase == null)
                {
                    return null;
                }

                return SelectedLogDatabase.ToFriendlyLogDatabaseName();
            }
        }

        public HomeIndexModel()
        {
            Logs = new List<Log>();
            LogDatabases = new List<SelectListItem>();
        }
    }
}