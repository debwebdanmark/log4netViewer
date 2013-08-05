using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace log4netViewer.MvcWeb.Controllers
{
    public class Log4NetViewerController : Controller
    {
        protected string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["log4net-database"].ConnectionString; }
        }

        protected ProfiledDbConnection CreateProfiledDbConnection()
        {
            return new ProfiledDbConnection(new SqlConnection(ConnectionString), MiniProfiler.Current);
        }
    }
}