using SQLSeverDal.UnionInfor;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using TU.Model.Models;

namespace TradeUnion.Controllers
{

    public class UnionInforController : Controller
    {
        /// <summary>
        /// 返回UnionInforIndex视图
        /// </summary>
        /// <returns></returns>
        // GET: UnionInfor
        public ActionResult UnionInforIndex()
        {
            return View();
        }

        #region 返回添加工会信息视图
        /// <summary>
        /// 返回AddUnionArchiIndex视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionArchiIndex()
        {
            //返回视图，即点击左侧链接时，先返回一个AddUnionAnnounIndex页面，具体提交该页面表单数据的方法在本控制器下面写出来。
            return View();
        }
        /// <summary>
        /// 返回AddUnionPolicyIndex视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionPolicyIndex()
        {
            return View();
        }
        /// <summary>
        /// 返回AddUnionAnnounIndex视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionAnnounIndex()
        {
            return View();
        }
        #endregion

        #region 添加工会信息的方法
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
        /// <summary>
        /// 添加工会法规信息的方法
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





        #region 返回删除信息的视图
        /// <summary>
        /// 返回删除架构信息DelUnionArchiIndex视图
        /// </summary>
        /// <returns></returns>
        public ActionResult DelUnionArchiIndex()
        {
            return View();
        }

        public ActionResult DelUnionPolicyIndex()
        {
            return View();
        }

        public ActionResult DelUnionAnnounIndex()
        {
            return View();
        }
        #endregion

        #region 删除工会信息的方法
        /// <summary>
        /// 删除工会架构信息的方法
        /// </summary>
        /// <returns></returns>
        public ActionResult DelArchiMSG(JiaGou model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string sql = @"delete from dbo.TB_JiaGou where ID=@f";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("f", model.ID)
            };
            sqlh.ExecData(sql, para);
            return RedirectToAction("ScanUnionArchiIndex", "UnionInfor");
        }

        public ActionResult DelPolicyMSG(JiaGou model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string sql = @"delete from dbo.TB_JiaGou where ID=@f";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("f", model.ID)
            };
            sqlh.ExecData(sql, para);
            return RedirectToAction("ScanUnionArchiIndex", "UnionInfor");
        }

        public ActionResult DelAnnounMSG(JiaGou model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string sql = @"delete from dbo.TB_JiaGou where ID=@f";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("f", model.ID)
            };
            sqlh.ExecData(sql, para);
            return RedirectToAction("ScanUnionArchiIndex", "UnionInfor");
        }
        #endregion





        #region 返回编辑确认ID视图
        public ActionResult EditArchiDialog(JiaGou model)
        {
            return View();
        }

        public ActionResult EditAnnounDialog(GongGao model)
        {
            return View();
        }

        public ActionResult EditPolicyDialog(FaGui model)
        {
            return View();
        }
        #endregion

        #region 返回工会信息到视图的方法(Controller到View)
        /// <summary>
        /// 返回EditUnionArchiIndex视图
        /// </summary>
        /// <returns></returns>
        public ActionResult EditUnionArchiIndex(JiaGou model)
        {
            string sql = "select * from TB_JiaGou where ID=" + model.ID;
            DataTable dt = SQLHelper.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ViewData["MingCheng"] = dt.Rows[0]["MingCheng"].ToString();
                ViewData["FabuRen"] = dt.Rows[0]["FabuRen"].ToString();
                ViewData["JieShao"] = dt.Rows[0]["JieShao"].ToString();
                ViewData["ID"] = dt.Rows[0]["ID"].ToString();
            }
            return View();
        }
        /// <summary>
        /// 返回EditUnionAnnounIndex视图
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EditUnionAnnounIndex(GongGao model)
        {
            string sql = "select * from TB_GongGao where ID=" + model.ID;
            DataTable dt = SQLHelper.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ViewData["MingCheng"] = dt.Rows[0]["MingCheng"].ToString();
                ViewData["FabuRen"] = dt.Rows[0]["FabuRen"].ToString();
                ViewData["JieShao"] = dt.Rows[0]["JieShao"].ToString();
                ViewData["ID"] = dt.Rows[0]["ID"].ToString();
            }
            return View();
        }
        /// <summary>
        /// 返回EditUnionFaGuiIndex视图
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EditUnionPolicyIndex(FaGui model)
        {
            string sql = "select * from TB_FaGui where ID=" + model.ID;
            DataTable dt = SQLHelper.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ViewData["MingCheng"] = dt.Rows[0]["MingCheng"].ToString();
                ViewData["FabuRen"] = dt.Rows[0]["FabuRen"].ToString();
                ViewData["JieShao"] = dt.Rows[0]["JieShao"].ToString();
                ViewData["ID"] = dt.Rows[0]["ID"].ToString();
            }
            return View();
        }
        #endregion

        #region 编辑工会信息的方法
        /// <summary>
        /// 编辑工会架构信息的方法
        /// </summary>
        /// <returns></returns>
        public ActionResult EditArchiMSG(JiaGou model)
        {
            SQLHelper sqlh = new SQLHelper();
            model.ShiJian = DateTime.Now;
            const string UpdateJiaGousql = @"UPDATE dbo.TB_JiaGou
                                            SET MingCheng = @MingCheng,
                                                FabuRen = @FabuRen,
                                                JieShao = @JieShao
                                            WHERE ID = @ID
            ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("MingCheng",model.MingCheng),
              new SqlParameter("FabuRen", model.FabuRen),
              new SqlParameter("JieShao", model.JieShao),
              new SqlParameter("ID", model.ID)
             };
            sqlh.ExecData(UpdateJiaGousql, para);
            return RedirectToAction("ScanUnionArchiIndex", "UnionInfor");
        }

        public ActionResult EditAnnounMSG(GongGao model)
        {
            SQLHelper sqlh = new SQLHelper();
            model.ShiJian = DateTime.Now;
            const string UpdateGongGaosql = @"UPDATE dbo.TB_GongGao
                                            SET MingCheng = @MingCheng,
                                                FabuRen = @FabuRen,
                                                JieShao = @JieShao
                                            WHERE ID = @ID
            ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("MingCheng",model.MingCheng),
              new SqlParameter("FabuRen", model.FabuRen),
              new SqlParameter("JieShao", model.JieShao),
              new SqlParameter("ID", model.ID)
             };
            sqlh.ExecData(UpdateGongGaosql, para);
            return RedirectToAction("ScanUnionAnnounIndex", "UnionInfor");
        }

        public ActionResult EditPolicyMSG(GongGao model)
        {
            SQLHelper sqlh = new SQLHelper();
            model.ShiJian = DateTime.Now;
            const string UpdateFaGuisql = @"UPDATE dbo.TB_FaGui
                                            SET MingCheng = @MingCheng,
                                                FabuRen = @FabuRen,
                                                JieShao = @JieShao
                                            WHERE ID = @ID
            ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("MingCheng",model.MingCheng),
              new SqlParameter("FabuRen", model.FabuRen),
              new SqlParameter("JieShao", model.JieShao),
              new SqlParameter("ID", model.ID)
             };
            sqlh.ExecData(UpdateFaGuisql, para);
            return RedirectToAction("ScanUnionPolicyIndex", "UnionInfor");
        }
        #endregion





        #region 浏览工会信息同时返回视图
        /// <summary>
        /// 浏览工会架构信息的同时返回视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanUnionArchiIndex()
        {
            UnionInforDal ScanUnion = new UnionInforDal();
            var queryResult = ScanUnion.Query_JiaGou();
            ViewBag.List = queryResult;
            return View();
        }
        /// <summary>
        /// 浏览工会政策法规信息的同时返回视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanUnionPolicyIndex()
        {
            UnionInforDal ScanUnion = new UnionInforDal();
            var queryResult = ScanUnion.Query_FaGui();
            ViewBag.List = queryResult;
            return View();
        }
        /// <summary>
        /// 浏览工会政策法规信息的同时返回视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanUnionAnnounIndex()
        {
            UnionInforDal ScanUnion = new UnionInforDal();
            var queryResult = ScanUnion.Query_GongGao();
            ViewBag.List = queryResult;
            return View();
        }
        #endregion



    }
}