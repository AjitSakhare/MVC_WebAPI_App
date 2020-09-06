using ContactInfo.Web.ViewModel;
using NLog;
using System.Web.Mvc;

namespace ContactInfo.Web.Controllers
{
    public class ContInfoWebMethodController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// This action method return main view when user visit website
        /// </summary>
        /// <returns></returns>
        public ActionResult MainView()
        {
            return View();
        }

        /// <summary>
        /// This action method is to show all list of available contact details
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageView()
        {
         ContactModel contactModel = new ContactModel();
            return View(contactModel);
        }

        /// <summary>
        /// This action method is used to open partila view to create new record
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateView()
        {
            return PartialView();
        }

        /// <summary>
        /// This method show/display message to user when accesing invalid URL
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            return View();
        }
    }
}