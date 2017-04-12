using SQLSeverDal.UnionMembers;
using System.Data.SqlClient;
using System.Web.Mvc;
using TU.Model.Models;

namespace TradeUnion.Controllers
{
    public class UnionMembersController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: UnionMembers
        public ActionResult UnionMembersIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUnionMembersIndex()
        {
            return View();
        }
        /// <summary>
        /// 
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
        /// 添加工会成员信息
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
    }
}