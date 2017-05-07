﻿using SQLSeverDal.EmployeeBenefits;
using System.Data.SqlClient;
using System.Web.Mvc;
using TU.Model.Models;

namespace TradeUnion.Controllers
{
    public class EmployeeBenefitsController : Controller
    {
        #region ---返回视图
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: EmployeeBenefits
        public ActionResult EmployeeBenefitsIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBodyExamIndex()
        {
            return View();
        }
        /// <summary>
        /// 返回添加文体活动AddActivityIndex视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddActivityIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBirthdayIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddInsuranceIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSpecialIndex()
        {
            return View();
        }
        /// <summary>
        /// 
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
        public ActionResult ScanBirthdayIndex()
        {
            EmployeeBenefitsDal ScanBirthday = new EmployeeBenefitsDal();
            var queryResult = ScanBirthday.Query_Shengri();
            ViewBag.List = queryResult;
            return View();
        }
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
        public ActionResult AddEyeBeft(TiJian model)
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