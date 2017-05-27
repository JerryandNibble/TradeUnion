using Dapper;
using SQLServerDal;
using SQLSeverDal.UnionMembers;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Mvc;
using TU.Model.Models;



namespace TradeUnion.Controllers
{
    public class UnionMembersController : Controller
    {
        #region  返回教职工成员主页视图
        /// <summary>
        /// 返回工会成员管理视图
        /// </summary>
        /// <returns></returns>
        // GET: UnionMembers
        public ActionResult UnionMembersIndex()
        {
            return View();
        }

        #endregion

        #region  工会教职工成员方法
        /// <summary>
        /// 返回添加工会教职工视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionMembersIndex()
        {
            return View();
        }
        /// <summary>
        /// 返回工会教职工信息视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ScanUnionMembersIndex()
        {
            UnionMembersDal ScanUnionMembers = new UnionMembersDal();
            var queryResult = ScanUnionMembers.Query_KeHu();
            ViewBag.List = queryResult;
            return View();
        }
        /// <summary>
        /// 返回添加工会职工视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddMbs(KeHu model)
        {
            SQLHelper sqlh = new SQLHelper();
            const string AddMbssql = @"INSERT INTO dbo.TB_KeHu
                                       ( Address, BianHao,IDCard,LeiXing,LianXIFangShi,PassWord,ShengRi,XingMing) 
                                        VALUES  ( @Address, 
                                                  @BianHao,
			                                      @IDCard,
                                                  @LeiXing,
                                                  @LianXIFangShi,
                                                  @PassWord,
                                                  @ShengRi,
                                                  @XingMing
                                         ) ";
            SqlParameter[] para = new SqlParameter[]
            {
              new SqlParameter("Address",model.Address),
              new SqlParameter("BianHao", model.BianHao),
              new SqlParameter("IDCard", model.IDCard),
              new SqlParameter("LeiXing", model.LeiXing),
              new SqlParameter("LianXIFangShi", model.LianXIFangShi),
              new SqlParameter("PassWord", model.PassWord),
              new SqlParameter("ShengRi", model.ShengRi),
              new SqlParameter("XingMing", model.XingMing)
              
             };
            sqlh.ExecData(AddMbssql, para);
            return RedirectToAction("ScanUnionMembersIndex", "UnionMembers");
        }

        /// <summary>
        /// 删除工会成员信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DelMbsMSG(int Id = 0)
        {
            const string DeleteMbssql = @"
                        DELETE FROM dbo.tb_kehu
                        WHERE ID = @ID";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ID", Id);
                var result = conn.Execute(DeleteMbssql, dp) > 0;
            }
            return RedirectToAction("ScanUnionMembersIndex", "UnionMembers");
        }

        /// <summary>
        /// 从控制器返回数据到视图
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EditUnionMembersIndex(int Id = 0)
        {
            UnionMembersDal unioninforDal = new UnionMembersDal();
            var queryResult = unioninforDal.QueryEmployee(Id);
            ViewData.Model = queryResult;
            return View(ViewData.Model);
        }

        public ActionResult EditMembersSave(KeHu model)
        {
            const string EditUnionPolicySaveSql = @"UPDATE dbo.TB_KeHu
				                                    SET	BianHao=@BianHao,
					                                    PassWord=@PassWord,
					                                    XingMing=@XingMing,
                                                        IDCard=@IDCard,
                                                        ShengRi=@ShengRi,
                                                        Address=@Address,
                                                        LianXIFangShi=@LianXIFangShi,
                                                        LeiXing=@LeiXing
				                                    WHERE ID=@ID";
            using (DbConnection conn = DbFactory.CreateConnection())
            {
                var result = conn.Execute(EditUnionPolicySaveSql, model) > 0;
            }
            return RedirectToAction("ScanUnionMembersIndex", "UnionMembers");
        }
        #endregion
    }
}