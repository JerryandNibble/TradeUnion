using System.Data;
using System.Web.Mvc;
using TU.Model.Models;

namespace TradeUnion.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 返回该控制器的视图
        /// </summary>
        /// <returns></returns>
        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }

        /// <summary>
        /// 账号密码检查方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        
        [HttpPost]
        public ActionResult LoginAction(Login model)
        {
            string name = model.UserName;  //name 为 视图中获取的 输入框中  name为UserName 值
            string pwd = model.PassWord; //pwd 为 视图中获取的 输入框中 name为PassWord 值

            SQLHelper sqlCheck = new SQLHelper(); //创建数据库工具类的对象
            string Adminsql = "select * from TB_Admin where UserName='{0}' and Password='{1}' "; //SQL查询语句
            string Admin = string.Format(Adminsql, name, pwd); //把SQL语句 和参数整合在一个字符串里
            DataTable dt = SQLHelper.GetDataSet(Admin).Tables[0]; //调用工厂类的方法进行查询并获取返回值

            if (dt.Rows.Count > 0) //如果获取到数据，行高>0 ; 如果没有获取到数据，行高=0；
            {
                return RedirectToAction("HomeIndex", "Home"); //重定向到控制器Home 中的HomeIndex方法
            }
            else
            {
                return Redirect("LoginIndex");//重定向到本控制器中的LoginIndex方法
            }



            //BendadmindBll _bendadmindBll = new BendadmindBll();
            //var queryResult = _bendadmindBll.Scan_Bendadmind();
            //ViewBag.List = queryResult;
            //string checktrue = "true";
            //if (user.Checknumber == checktrue)
            //{
            //    foreach (var usermodel in queryResult)
            //    {
            //        if (usermodel.AdAccount == user.UserAccount && usermodel.AdPassWord == user.UserPassword)
            //        {
            //            ViewData.Model = usermodel;
            //            Session["UserAccount"] = usermodel;//将值存在一个
            //            return RedirectToAction("UnionFunctionIndex", "UnionFunctionController");
            //        }
            //    }
            //}
            //return RedirectToAction("UserLoginIndex", "LoginSignUp");
        }
    }
}