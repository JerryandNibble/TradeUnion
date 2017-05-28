using Dapper;
using SQLServerDal;
using SQLSeverDal.EmployeeFamily;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Mvc;
using TU.Model.Models;

namespace TradeUnion.Controllers
{
    public class EmployeeFamilyController : Controller
    {
        #region 子女信息主页
        public ActionResult EmployeeFamilyIndex()
        {
            return View();
        }
        #endregion


        #region 子女信息方法
        public ActionResult ScanChildIndex()
        {
            EmployeeFamilyDal ScanEmployeeFamily = new EmployeeFamilyDal();
            var queryResult = ScanEmployeeFamily.Query_ZiNV();
            ViewBag.List = queryResult;
            return View();
        }

        public ActionResult AddChildIndex()
        {
            return View();
        }

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

        public ActionResult DelChild(int Id = 0)
        {
            const string DelZiNvsql = @"
                        DELETE FROM dbo.tb_zinv
                        WHERE ID = @ID

            ";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ID", Id);
                var result = conn.Execute(DelZiNvsql, dp) > 0;
            }
            return RedirectToAction("ScanChildIndex", "EmployeeFamily");
        }

        public ActionResult EditChildIndex(int Id = 0)
        {
            EmployeeFamilyDal childinforDal = new EmployeeFamilyDal();
            var queryResult = childinforDal.QueryChild(Id);
            ViewData.Model = queryResult;
            return View(ViewData.Model);
        }

        public ActionResult EditChildSave(ZiNV model)
        {
            const string EditChildSaveSql = @"UPDATE dbo.TB_ZiNV
				                                   SET	BianHao=@BianHao,
                                                        XingMing=@XingMing,
					                                    GuanXi=@GuanXi,
                                                        XingMing2=@XingMing2,
                                                        Age=@Age,
					                                    XueLi=@XueLi,
                                                        XueXiao=@XueXiao
				                                   WHERE ID=@ID";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                var result = conn.Execute(EditChildSaveSql, model) > 0;
            }
            return RedirectToAction("ScanChildIndex", "EmployeeFamily");
        }
        #endregion








        
        /// <summary>
        /// 返回添加子女特殊情况视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddChildStatusIndex()
        {
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