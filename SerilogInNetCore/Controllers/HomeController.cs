using Microsoft.AspNetCore.Mvc;
namespace SerilogInNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            LogHelper.Debug("Test Debug");
            LogHelper.Info("Test Info");
            LogHelper.Error("Test Error");

            try
            {
                string test = null;
                test.ToLower();
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(ex, "Error in Home Controller");
            }

            return View();
        }
    }
}
