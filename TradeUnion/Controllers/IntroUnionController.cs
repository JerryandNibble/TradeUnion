using System.Web.Mvc;

namespace TradeUnion.Controllers
{
    public class IntroUnionController : Controller
    {
        #region --返回视图
        /// <summary>
        /// 工会职能
        /// </summary>
        /// <returns></returns>
        // GET: IntroUnion
        public ActionResult IntroUnionIndex()
        {
            return View();
        }
        #endregion
    }
}