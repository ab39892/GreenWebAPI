using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenApi3.Models;
using Newtonsoft.Json;

namespace GreenApi3.Controllers
{
    public class HomeController : Controller
    {
        DataAccessLayer dal = new DataAccessLayer();
        public ActionResult Index()
        {
            //dal.testConn();
            ViewBag.Title = "Home Page";
            dal.testConn();
            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            return Json("Hello", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Upload(SensorData data)
        {
            if (data != null)
            {
                try
                {
                    dal.uploadData(data);
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK, "ok");
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "No data in request");
        }
    }
}
