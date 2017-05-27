using SQLServerDal;
using System.Collections.Generic;
using System.Linq;
using TU.Model.Models;

namespace SQLSeverDal.EmployeeBenefits
{
    public class EmployeeBenefitsDal : BaseDal
    {
        #region  体检活动查看的方法
        /// <summary>
        /// 体检
        /// </summary>
        /// <returns></returns>
        public IList<TiJian> Query_TiJian()
        {
            const string Query_factorySql = @"select
                                            xingming,
                                            shijian,
                                            yiyuan,
                                            jieguo 
                                            from tb_tijian
                                           ";
            return Query<TiJian>(Query_factorySql).ToList();
        }

        /// <summary>
        /// 对职工体检信息遍历
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TiJian QueryTiJian(int Id)
        {
            const string Query_TiJiansql = @"select id,
                                            bianhao,
                                            xingming,
                                            shijian,
                                            yiyuan,
                                            jieguo 
                                            from tb_tijian
                                            where ID = @Id
                                           ";
            var Model = base.QueryFirst<TiJian>(Query_TiJiansql, new { Id = Id });
            return Model;
        }
        #endregion

        #region 生日信息查看方法
        /// <summary>
        /// 生日
        /// </summary>
        /// <returns></returns>
        public IList<Shengri> Query_Shengri()
        {
            const string Query_factorySql = @"select id,
                                            bianhao,
                                            xingming,
                                            shengri
                                            from tb_shengri
                                           ";
            return Query<Shengri>(Query_factorySql).ToList();
        }

        /// <summary>
        /// 对职工体检信息遍历
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Shengri QueryShengRi(int Id)
        {
            const string Query_ShengRisql = @"select id,
                                            bianhao,
                                            xingming,
                                            shengri 
                                            from tb_shengri
                                            where ID = @Id
                                           ";
            var Model = base.QueryFirst<Shengri>(Query_ShengRisql, new { Id = Id });
            return Model;
        }
        #endregion

        #region 保险信息查看方法
        /// <summary>
        /// 保险
        /// </summary>
        /// <returns></returns>
        public IList<Baoxian> Query_BaoXian()
        {
            const string Query_factorySql = @"select
                                            xingming,
                                            youxiaoqi,
                                            baoxian,
                                            fenshu 
                                            from tb_baoxian
                                           ";
            return Query<Baoxian>(Query_factorySql).ToList();
        }

        /// <summary>
        /// 对职工保险信息遍历
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Baoxian QueryBaoXian(int Id)
        {
            const string Query_BaoXiansql = @"select id,
                                            bianhao,
                                            xingming,
                                            youxiaoqi,
                                            baoxian,
                                            fenshu
                                            from tb_baoxian
                                            where ID = @Id
                                           ";
            var Model = base.QueryFirst<Baoxian>(Query_BaoXiansql, new { Id = Id });
            return Model;
        }
        #endregion

        #region 特殊情况查看方法
        /// <summary>
        /// 特殊情况
        /// </summary>
        /// <returns></returns>
        public IList<FTeshu> Query_TeShu()
        {
            const string Query_factorySql = @"select id,
                                            bianhao,
                                            xingming,
                                            teshu
                                            from tb_teshu
                                           ";
            return Query<FTeshu>(Query_factorySql).ToList();
        }
        /// <summary>
        /// 遍历特殊情况返回至编辑视图
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public FTeShu QueryTeShu(int Id)
        {
            const string Query_FTeShusql = @"select id,
                                            bianhao,
                                            xingming,
                                            teshu 
                                            from tb_teshu
                                            where ID = @Id
                                           ";
            var Model = base.QueryFirst<FTeShu>(Query_FTeShusql, new { Id = Id });
            return Model;
        }
        #endregion


        /// <summary>
        /// 添加活动的方法
        /// </summary>
        /// <returns></returns>
        public IList<HuoDong> Query_HuoDong()
        {
            const string Query_factorySql = @"select ActMingCheng,
                                              FaBuRen,
                                              JieShao
                                              from tb_huodong
                                            ";
            return Query<HuoDong>(Query_factorySql).ToList();
        }
    }
}
