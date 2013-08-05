using Dapper;
using log4netViewer.MvcWeb.Models;
using StackExchange.Profiling;
using System.Web.Mvc;

namespace log4netViewer.MvcWeb.Controllers
{
    public class HomeController : Log4NetViewerController
    {
        public ActionResult Index()
        {
            var model = new HomeIndexModel();
            var profiler = MiniProfiler.Current;

            using (profiler.Step("Getting logs from database"))
            using (var sqlConn = CreateProfiledDbConnection())
            {
                model.Logs.AddRange(sqlConn.Query<Log>("SELECT TOP 100 * FROM Log ORDER BY Id DESC"));
            }

            return View(model);
        }
    }
}
