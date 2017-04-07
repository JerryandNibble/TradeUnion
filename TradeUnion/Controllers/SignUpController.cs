using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradeUnion.Controllers
{
    public class SignUpController : Controller
    {
        #region ---返回视图
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: SignUp
        public ActionResult SignUpIndex()
        {
            return View();
        }
        #endregion

        #region ---注册用户
        public ActionResult AddNewAccountAction(Admin model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string AddEyeBeftsql = @"INSERT INTO dbo.TB_Admin
                                       ( UserName,PassWord)
                                        VALUES  ( @UserName, 
                                                  @PassWord
            ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("UserName",model.UserName),
              new SqlParameter("PassWord", model.PassWord)
             };
            sqlh.ExecData(AddEyeBeftsql, para);
            return RedirectToAction("LoginIndex", "Login");
        }

        #endregion
    }
}