using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradeUnion.Controllers
{
    public class HomeController : Controller
    {
        #region  ---返回视图
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult HomeIndex()
        {
            return View();
        }
        #endregion
    }
}