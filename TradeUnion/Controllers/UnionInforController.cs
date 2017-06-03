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
    /// <summary>
    /// 工会信息
    /// </summary>
    public class UnionInforController : Controller
    {

        #region --主界面视图
        /// <summary>
        /// 返回工会主页视图
        /// </summary>
        /// <returns></returns>
        // GET: UnionInfor
        public ActionResult UnionInforIndex()
        {
            return View();
        }
        #endregion

        #region 架构信息方法

        /// <summary>
        /// 浏览工会架构信息
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
        /// 返回添加架构信息页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionArchiIndex()
        {
            //返回视图，即点击左侧链接时，先返回一个AddUnionAnnounIndex页面，具体提交该页面表单数据的方法在本控制器下面写出来。
            return View();
        }

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
        /// 删除工会架构信息的方法
        /// </summary>
        /// <returns></returns>
        public ActionResult DelUnionArchiIndex(int Id = 0)
        {
            const string DelJiaGousql = @"
                        DELETE FROM dbo.tb_jiagou
                        WHERE ID = @ID

            ";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ID", Id);
                var result = conn.Execute(DelJiaGousql, dp) > 0;
            }
            return RedirectToAction("ScanUnionArchiIndex", "UnionInfor");
        }

        


        public ActionResult EditUnionArchiIndex(int Id = 0)
        {
            UnionInforDal unioninforDal = new UnionInforDal();
            var queryResult = unioninforDal.QueryJiaGou(Id);
            ViewData.Model = queryResult;
            return View(ViewData.Model);
        }

        public ActionResult FullArchiContents(int Id = 0)
        {
            UnionInforDal unioninforDal = new UnionInforDal();
            var queryResult = unioninforDal.QueryJiaGou(Id);
            ViewData.Model = queryResult;
            return View(ViewData.Model);
        }
        public ActionResult EditUnionArchiSave(JiaGou model)
        {
            const string EditUnionArchiSaveSql = @"UPDATE dbo.TB_JiaGou
				                                   SET	MingCheng=@MingCheng,
					                                    FabuRen=@FabuRen,
					                                    JieShao=@JieShao
				                                   WHERE ID=@ID";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                var result = conn.Execute(EditUnionArchiSaveSql, model) > 0;
            }
            return RedirectToAction("ScanUnionArchiIndex", "UnionInfor");
        }

        #endregion



        #region --政策法规方法

        /// <summary>
        /// 浏览工会政策法规全部信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanUnionPolicyIndex()
        {
            UnionInforDal ScanUnion = new UnionInforDal();
            var queryResult = ScanUnion.Query_FaGui();
            ViewBag.List = queryResult;
            return View();
        }

        public ActionResult FullPolicyContents(int Id = 0)
        {
            UnionInforDal unioninforDal = new UnionInforDal();
            var queryResult = unioninforDal.QueryFaGui(Id);
            ViewData.Model = queryResult;
            return View(ViewData.Model);
        }

        /// <summary>
        /// 返回政策法规主页
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionPolicyIndex()
        {
            return View();
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
        /// 删除政策法规信息的方法
        /// </summary>
        /// <returns></returns>
        public ActionResult DelFaGuiMSG(int Id = 0)
        {
            const string DelectedFaGuisql = @"
                        DELETE FROM dbo.TB_FaGui
                        WHERE ID = @ID
            ";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ID", Id);
                var result = conn.Execute(DelectedFaGuisql, dp) > 0;
            }
            return RedirectToAction("ScanUnionPolicyIndex", "UnionInfor");
        }

        /// <summary>
        /// 返回工会法规信息到视图的方法(Controller到View)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EditUnionPolicyIndex(int Id = 0)
        {
            UnionInforDal unioninforDal = new UnionInforDal();
            var queryResult = unioninforDal.QueryFaGui(Id);
            ViewData.Model = queryResult;
            return View(ViewData.Model);
        }
        /// <summary>
        /// 编辑保存法规信息的方法
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EditUnionPolicySave(FaGui model)
        {
            const string EditUnionPolicySaveSql = @"UPDATE dbo.TB_FaGui
				                                    SET	MingCheng=@MingCheng,
					                                    FabuRen=@FabuRen,
					                                    JieShao=@JieShao
				                                    WHERE ID=@ID";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                var result = conn.Execute(EditUnionPolicySaveSql, model) > 0;
            }

            return RedirectToAction("ScanUnionPolicyIndex", "UnionInfor");
        }
        #endregion

        #region --最新公告方法

        /// <summary>
        /// 浏览工会政策法规全部信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanUnionAnnounIndex()
        {
            UnionInforDal ScanUnion = new UnionInforDal();
            var queryResult = ScanUnion.Query_GongGao();
            ViewBag.List = queryResult;
            return View();
        }

        public ActionResult FullAnnounContents(int Id = 0)
        {
            UnionInforDal unioninforDal = new UnionInforDal();
            var queryResult = unioninforDal.QueryGongGao(Id);
            ViewData.Model = queryResult;
            return View(ViewData.Model);
        }

        /// <summary>
        /// 返回最新公告主页
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionAnnounIndex()
        {
            return View();
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

        /// <summary>
        /// 删除最新公告信息的方法
        /// </summary>
        /// <returns></returns>
        public ActionResult DelGongGaoMSG(int Id = 0)
        {
            const string DelectedGongGaosql = @"
                        DELETE FROM dbo.TB_GongGao
                        WHERE ID = @ID
            ";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ID", Id);
                var result = conn.Execute(DelectedGongGaosql, dp) > 0;
            }
            return RedirectToAction("ScanUnionAnnounIndex", "UnionInfor");
        }

        /// <summary>
        /// 返回工会最新公告到视图的方法(Controller到View)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EditUnionAnnounIndex(int Id = 0)
        {
            UnionInforDal unioninforDal = new UnionInforDal();
            var queryResult = unioninforDal.QueryGongGao(Id);
            ViewData.Model = queryResult;
            return View(ViewData.Model);
        }

        /// <summary>
        /// 修改最新公告信息的方法
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EditAnnounSave(GongGao model)
        {
            const string EditUnionAnnounSaveSql = @"UPDATE dbo.TB_GongGao
				                                    SET	MingCheng=@MingCheng,
					                                    FabuRen=@FabuRen,
					                                    JieShao=@JieShao
				                                    WHERE ID=@ID";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                var result = conn.Execute(EditUnionAnnounSaveSql, model) > 0;
            }
            return RedirectToAction("ScanUnionAnnounIndex", "UnionInfor");
        }

        #endregion

    }
}