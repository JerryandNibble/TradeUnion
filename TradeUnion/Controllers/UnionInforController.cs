using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeUnion.Models;

namespace TradeUnion.Controllers
{
    public class UnionInforController : Controller
    {
        #region --返回视图
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: UnionInfor
        public ActionResult UnionInforIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionArchiIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionPolicyIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionAnnounIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanUnionArchiIndex()
        {
           // ScanJiaGouMSG();
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanUnionPolicyIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanUnionAnnounIndex()
        {
            return View();
        }
        #endregion
        
        #region ---工会架构信息的方法
        /// <summary>
        /// 添加工会架构信息的方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddJiaGouMSG(JiaGou model)
        {
            SQLHelper sqlh = new SQLHelper();
            model.ShiJian = DateTime.Now;
            const string AddJiaGousql = @"INSERT INTO dbo.TB_JiaGou
                                       ( MingCheng, FabuRen,JieShao,ShiJian) 
                                        VALUES  ( @MingCheng, 
                                                  @FabuRen,
			                                      @JieShao,
			                                      @ShiJian
            ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("MingCheng",model.MingCheng),
              new SqlParameter("FabuRen", model.FabuRen),
              new SqlParameter("JieShao", model.JieShao),
              new SqlParameter("ShiJian", model.ShiJian)
             };
            sqlh.ExecData(AddJiaGousql, para);
            return RedirectToAction("ScanUnionArchiIndex", "UnionInfor");
        }
        #endregion

        #region ---法规信息增加的方法
        /// <summary>
        /// 添加工会架构信息的方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddFaGuiMSG(FaGui model)
        {
            SQLHelper sqlh = new SQLHelper();
            model.ShiJian = DateTime.Now;
            const string AddFaGuisql = @"INSERT INTO dbo.TB_FaGui
                                       ( MingCheng, FabuRen,JieShao,ShiJian) 
                                        VALUES  ( @MingCheng, 
                                                  @FabuRen,
			                                      @JieShao,
			                                      @ShiJian
            ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("MingCheng",model.MingCheng),
              new SqlParameter("FabuRen", model.FabuRen),
              new SqlParameter("JieShao", model.JieShao),
              new SqlParameter("ShiJian", model.ShiJian)
             };
            sqlh.ExecData(AddFaGuisql, para);
            return RedirectToAction("ScanUnionPolicyIndex", "UnionInfor");
        }

        #endregion
        
        #region ---工会公告信息的方法
        /// <summary>
        /// 添加工会公告信息的方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddGongGaoMSG(GongGao model)
        {
            SQLHelper sqlh = new SQLHelper();
            model.ShiJian = DateTime.Now;
            const string AddGongGaosql = @"INSERT INTO dbo.TB_GongGao
                                       ( MingCheng, FabuRen,JieShao,ShiJian) 
                                        VALUES  ( @MingCheng, 
                                                  @FabuRen,
			                                      @JieShao,
			                                      @ShiJian
            ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("MingCheng",model.MingCheng),
              new SqlParameter("FabuRen", model.FabuRen),
              new SqlParameter("JieShao", model.JieShao),
              new SqlParameter("ShiJian", model.ShiJian)
             };
            sqlh.ExecData(AddGongGaosql, para);
            return RedirectToAction("ScanUnionAnnounIndex", "UnionInfor");
        }

        #endregion

        //#region ---浏览工会架构信息
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public ActionResult ScanJiaGouMSG(JiaGou model)
        //{
        //    DataSet set = new DataSet();
        //    SQLHelper sqlCheck = new SQLHelper();
        //    model.ShiJian = DateTime.Now;
        //    const string ScanJiaGousql = @"select *
        //                                   from TB_JiaGou
        //    ";
        //    set = SQLHelper.ExcueReturnDataset(ScanJiaGousql, null);

        //    ViewBag.Message = "fsfsf";
        //    ViewData["testData"] = "daddddsds";
        //    return RedirectToAction("ScanUnionArchiIndex", "UnionInfor"); 
        //}




        public ActionResult ScanJiaGouMSG(JiaGou model)
        {
            //var p = new JiaGou()
            //const string ScanJiaGousql = @"select *
            //                               from TB_JiaGou
            //";
            //{
            //  ID = 1,
            //  MingCheng = "标题",
            //  FabuRen = "小王",
            //  JieShao = "哈哈哈",
            // // ShiJian = '2017-4-9'
            //};
            //ViewBag._JiaGou = p;
            //return RedirectToAction("ScanUnionArchiIndex", "UnionInfor");

            var p = new Admin()
            {
                ID = 1,
                UserName = "饮料",
                PassWord = "fsfs"
            };
           
            return View(p);
        }









    }
}