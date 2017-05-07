using SQLServerDal;
using System.Collections.Generic;
using System.Linq;
using TU.Model.Models;

namespace SQLSeverDal.EmployeeBenefits
{
    public class EmployeeBenefitsDal : BaseDal
    {
        /// <summary>
        /// 体检
        /// </summary>
        /// <returns></returns>
        public IList<TiJian> Query_TiJian()
        {
            const string Query_factorySql = @"select xingming,
                                            shijian,
                                            yiyuan,
                                            jieguo 
                                            from tb_tijian
                                           ";
            return Query<TiJian>(Query_factorySql).ToList();
        }
        /// <summary>
        /// 添加活动的方法
        /// </summary>
        /// <returns></returns>
        public IList<HuoDong> Query_HuoDong()
        {
            const string Query_factorySql = @"select ActMingCheng,
                                              FaBuRen,
                                              JieShao,
                                              ShiJian
                                              from tb_huodong
                                            ";
            return Query<HuoDong>(Query_factorySql).ToList();
        }

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
        /// 保险
        /// </summary>
        /// <returns></returns>
        public IList<Baoxian> Query_BaoXian()
        {
            const string Query_factorySql = @"select xingming,
                                            youxiaoqi,
                                            baoxian,
                                            fenshu 
                                            from tb_baoxian
                                           ";
            return Query<Baoxian>(Query_factorySql).ToList();
        }
        /// <summary>
        /// 特殊情况
        /// </summary>
        /// <returns></returns>
        public IList<Teshu> Query_TeShu()
        {
            const string Query_factorySql = @"select id,
                                            bianhao,
                                            xingming,
                                            teshu
                                            from tb_teshu
                                           ";
            return Query<Teshu>(Query_factorySql).ToList();
        }
    }
}
