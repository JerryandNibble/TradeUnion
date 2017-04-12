using SQLSeverDal.EmployeeFamily;
using System.Data.SqlClient;
using System.Web.Mvc;
using TU.Model.Models;

namespace TradeUnion.Controllers
{
    public class EmployeeFamilyController : Controller
    {
        /// <summary>
        /// 返回教职工家属信息视图
        /// </summary>
        /// <returns></returns>
        // GET: EmployeeFamily
        public ActionResult EmployeeFamilyIndex()
        {
            return View();
        }
        /// <summary>
        /// 返回添加子女信息视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddChildIndex()
        {
            return View();
        }
        /// <summary>
        /// 返回添加子女特殊情况视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddChildStatusIndex()
        {
            return View();
        }
        /// <summary>
        /// 返回浏览子女信息视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanChildIndex()
        {
            EmployeeFamilyDal ScanEmployeeFamily = new EmployeeFamilyDal();
            var queryResult = ScanEmployeeFamily.Query_ZiNV();
            ViewBag.List = queryResult;
            return View();
        }
        /// <summary>
        /// 返回浏览子女特殊情况视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanChildStatusIndex()
        {
            EmployeeFamilyDal ScanEmployeeFamilyTeShu = new EmployeeFamilyDal();
            var queryResult = ScanEmployeeFamilyTeShu.Query_FTeShu();
            ViewBag.List = queryResult;
            return View();
        }
        

        /// <summary>
        /// 添加子女信息的方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddCil(ZiNV model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string AddCilsql = @"INSERT INTO dbo.TB_ZiNV
                                       ( BianHao,XingMing,Age,GuanXi,XingMing2,XueLi,XueXiao)
                                        VALUES  ( @BianHao, 
                                                  @XingMing,
			                                      @Age,
                                                  @GuanXi,
                                                  @XingMing2,
                                                  @XueLi,
                                                  @XueXiao
            ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("BianHao",model.BianHao),
              new SqlParameter("XingMing", model.XingMing),
              new SqlParameter("Age", model.Age),
              new SqlParameter("GuanXi", model.GuanXi),
              new SqlParameter("XingMing2", model.XingMing2),
              new SqlParameter("XueLi", model.XueLi),
              new SqlParameter("XueXiao", model.XueXiao)
             };
            sqlh.ExecData(AddCilsql, para);
            return RedirectToAction("ScanChildIndex", "EmployeeFamily");
        }


        /// <summary>
        /// 添加子女特殊情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddZiNvStatus(FTeShu model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string AddZiNvStatussql = @"INSERT INTO dbo.TB_FTeShu
                                       ( BianHao,XingMing,TeShu)
                                        VALUES  ( @BianHao, 
                                                  @XingMing,
			                                      @TeShu
            ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("BianHao",model.BianHao),
              new SqlParameter("XingMing", model.XingMing),
              new SqlParameter("TeShu", model.TeShu)
             };
            sqlh.ExecData(AddZiNvStatussql, para);
            return RedirectToAction("ScanChildStatusIndex", "EmployeeFamily");
        }
    }
}