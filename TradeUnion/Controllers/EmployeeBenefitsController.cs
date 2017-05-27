using Dapper;
using SQLServerDal;
using SQLSeverDal.EmployeeBenefits;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Mvc;
using TU.Model.Models;

namespace TradeUnion.Controllers
{
    public class EmployeeBenefitsController : Controller
    {
        #region 职工福利首页
        public ActionResult EmployeeBenefitsIndex()
        {
            return View();
        }
        #endregion


        #region 体检信息方法
        /// <summary>
        /// 浏览体检信息的方法
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanBodyExamIndex()
        {
            EmployeeBenefitsDal ScanBodyExam = new EmployeeBenefitsDal();
            var queryResult = ScanBodyExam.Query_TiJian();
            ViewBag.List = queryResult;
            return View();
        }

        /// <summary>
        /// 返回视图和添加体检信息方法
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBodyExamIndex()
        {
            return View();
        }

        public ActionResult AddBodyExamInfor(TiJian model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string AddEyeBeftsql = @"INSERT INTO dbo.TB_TiJian
                                       ( BianHao,JieGuo,ShiJian,XingMing,YiYuan)
                                        VALUES  ( @BianHao, 
                                                  @JieGuo,
			                                      @ShiJian,
			                                      @XingMing,
                                                  @YiYuan
            ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("BianHao",model.BianHao),
              new SqlParameter("JieGuo", model.JieGuo),
              new SqlParameter("ShiJian", model.ShiJian),
              new SqlParameter("XingMing", model.XingMing),
              new SqlParameter("YiYuan", model.YiYuan)
             };
            sqlh.ExecData(AddEyeBeftsql, para);
            return RedirectToAction("ScanBodyExamIndex", "EmployeeBenefits");
        }


        public ActionResult DelBodyExamInfor(int Id = 0)
        {
            const string DelBodyExamsql = @"
                        DELETE FROM dbo.tb_tijian
                        WHERE ID = @ID
            ";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ID", Id);
                var result = conn.Execute(DelBodyExamsql, dp) > 0;
            }
            return RedirectToAction("ScanBodyExamIndex", "EmployeeBenefits");
        }

        /// <summary>
        /// 返回Model数据和更新体检信息方法
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EditBodyExamInforIndex(int Id = 0)
        {   //对应工会教职工信息的数据访问层的类，
            //其对象通过调用QueryTiJian方法实现Model内数据取出操作并最终通过ViewData方式显示到View视图
            EmployeeBenefitsDal bodyexaminforDal = new EmployeeBenefitsDal();
            var queryResult = bodyexaminforDal.QueryTiJian(Id);
            ViewData.Model = queryResult;
            return View(ViewData.Model);
        }

        public ActionResult EditBodyExamInforSave(TiJian model)
        {
            const string BodyExamInforSaveSql = @"UPDATE dbo.TB_TiJian
				                                   SET	BianHao=@BianHao,
					                                    XingMing=@XingMing,
					                                    ShiJian=@ShiJian,
                                                        YiYuan=@YiYuan,
                                                        JieGuo=@JieGuo
				                                   WHERE ID=@ID";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                var result = conn.Execute(BodyExamInforSaveSql, model) > 0;
            }
            return RedirectToAction("ScanBodyExamIndex", "EmployeeBenefits");
        }
        #endregion

        #region 生日信息方法
        public ActionResult ScanBirthdayIndex()
        {
            EmployeeBenefitsDal ScanBirthday = new EmployeeBenefitsDal();
            var queryResult = ScanBirthday.Query_Shengri();
            ViewBag.List = queryResult;
            return View();
        }

        public ActionResult AddBirthdayIndex()
        {
            return View();
        }

        public ActionResult AddBriDay(Shengri model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string AddBriDaysql = @"INSERT INTO dbo.TB_ShengRi
                                       ( BianHao,XingMing,ShengRi)
                                        VALUES  ( @BianHao, 
                                                  @XingMing,
			                                      @ShengRi
            ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("BianHao",model.BianHao),
              new SqlParameter("XingMing", model.XingMing),
              new SqlParameter("ShengRi", model.ShengRi)
             };
            sqlh.ExecData(AddBriDaysql, para);
            return RedirectToAction("ScanBirthdayIndex", "EmployeeBenefits");
        }

        /// <summary>
        /// 删除教职工生日信息方法
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult DelShengRi(int Id = 0)
        {
            const string DelShengRisql = @"
                        DELETE FROM dbo.tb_shengri
                        WHERE ID = @ID
            ";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ID", Id);
                var result = conn.Execute(DelShengRisql, dp) > 0;
            }
            return RedirectToAction("ScanBirthdayIndex", "EmployeeBenefits");
        }

        public ActionResult EditShengRiIndex(int Id = 0)
        {
            EmployeeBenefitsDal unioninforDal = new EmployeeBenefitsDal();
            var queryResult = unioninforDal.QueryShengRi(Id);
            ViewData.Model = queryResult;
            return View(ViewData.Model);
        }

        public ActionResult EditShengRiSave(JiaGou model)
        {
            const string EditShengRiSaveSql = @"UPDATE dbo.TB_ShengRi
				                                   SET	BianHao=@BianHao,
					                                    XingMing=@XingMing,
					                                    ShengRi=@ShengRi
				                                   WHERE ID=@ID";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                var result = conn.Execute(EditShengRiSaveSql, model) > 0;
            }
            return RedirectToAction("ScanBirthdayIndex", "EmployeeBenefits");
        }
        #endregion


        #region 保险基金方法
        public ActionResult AddInsuranceIndex()
        {
            return View();
        }



        #endregion


        #region 特殊情况方法
        public ActionResult AddSpecialIndex()
        {
            return View();
        }



        #endregion

        #region ---返回视图
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: EmployeeBenefits


        /// <summary>
        /// 返回添加文体活动AddActivityIndex视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddActivityIndex()
        {
            return View();
        }





        /// <summary>
        /// 浏览文体活动方法返回视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanActivityIndex()
        {
            EmployeeBenefitsDal ScanActivity = new EmployeeBenefitsDal();
            var queryResult = ScanActivity.Query_HuoDong();
            ViewBag.List = queryResult;
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanInsuranceIndex()
        {
            EmployeeBenefitsDal ScanInsurance = new EmployeeBenefitsDal();
            var queryResult = ScanInsurance.Query_BaoXian();
            ViewBag.List = queryResult;
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanSpecialIndex()
        {
            EmployeeBenefitsDal ScanSpecial = new EmployeeBenefitsDal();
            var queryResult = ScanSpecial.Query_TeShu();
            ViewBag.List = queryResult;
            return View();
        }
        #endregion

        #region --体检信息 
        

        #endregion

        /// <summary>
        /// 添加文体活动的方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddEyeActivity(HuoDong model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string AddEyeActivitysql = @"INSERT INTO dbo.TB_HuoDong
                                       ( ActMingCheng,FaBuRen,JieShao)
                                        VALUES  ( @ActMingCheng,
			                                      @FaBuRen,
			                                      @JieShao
            ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("ActMingCheng", model.ActMingCheng),
              new SqlParameter("FaBuRen", model.FaBuRen),
              new SqlParameter("JieShao", model.JieShao)
             };
            sqlh.ExecData(AddEyeActivitysql, para);
            return RedirectToAction("ScanActivityIndex", "EmployeeBenefits");
        }

        #region --教师职工生日信息
        


        #endregion

        #region --健康基金投险信息
        public ActionResult AddEmpBenf(Baoxian model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string AddEmpBenfsql = @"INSERT INTO dbo.TB_BaoXian
                                       ( BianHao,XingMing,BaoXian,FenSHu,YouXiaoQi)
                                        VALUES  ( @BianHao, 
                                                  @XingMing,
			                                      @BaoXian,
                                                  @FenSHu,
                                                  @YouXiaoQi
            ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("BianHao",model.BianHao),
              new SqlParameter("XingMing", model.XingMing),
              new SqlParameter("BaoXian", model.BaoXian),
              new SqlParameter("FenSHu", model.FenSHu),
              new SqlParameter("YouXiaoQi", model.YouXiaoQi)
             };
            sqlh.ExecData(AddEmpBenfsql, para);
            return RedirectToAction("ScanInsuranceIndex", "EmployeeBenefits");
        }


        #endregion


        #region --特殊情况
        public ActionResult AddSpe(Teshu model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string AddSpesql = @"INSERT INTO dbo.TB_TeShu
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
            sqlh.ExecData(AddSpesql, para);

            return RedirectToAction("ScanSpecialIndex", "EmployeeBenefits");
        }


        #endregion

    }
}