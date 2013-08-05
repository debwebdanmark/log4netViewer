using Dapper;
using log4netViewer.MvcWeb.Models;
using StackExchange.Profiling;
using System.Linq;
using System.Web.Mvc;

namespace log4netViewer.MvcWeb.Controllers
{
    public class LogController : Log4NetViewerController
    {
        public ActionResult Detail(int id)
        {
            var model = new LogDetailModel();
            var profiler = MiniProfiler.Current;

            using (profiler.Step("Getting log details from database"))
            using (var sqlConn = CreateProfiledDbConnection())
            {
                model.Log = sqlConn
                    .Query<Log>("SELECT * FROM Log WHERE Id = @Id", new { Id = id })
                    .SingleOrDefault();
            }

            if (model.Log == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }
    }
}