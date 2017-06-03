using Dapper;
using SQLServerDal;
using SQLSeverDal.UnionInfor;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Mvc;
using TU.Model.Models;

namespace TradeUnion.Controllers
{
    public class UnionFunctionController : Controller
    {
        #region  --返回视图
        public ActionResult UnionFunctionIndex()
        {
            return View();
        }
        #endregion
    }
}