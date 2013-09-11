using System.Linq;
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

            model.SelectedLogDatabase = GetSelectedConnectionStringName();
            model.LogDatabases.AddRange(LogDatabaseConnectionStrings.Select(css => new SelectListItem { Text = css.Name.Replace(LogDatabase.ConnectionStringPrefix, string.Empty), Value = css.Name }));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HomeIndexModel model)
        {
            if (IsConnectionStringInWebConfig(model.SelectedLogDatabase))
            {
                SetConnectionStringCookie(model.SelectedLogDatabase);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TruncateLogs()
        {
            var profiler = MiniProfiler.Current;

            using (profiler.Step("Truncating logs in database"))
            using (var sqlConn = CreateProfiledDbConnection())
            {
                sqlConn.Execute("TRUNCATE TABLE [Log]");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
