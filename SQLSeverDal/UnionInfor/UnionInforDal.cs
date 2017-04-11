using SQLServerDal;
using System.Collections.Generic;
using System.Linq;
using TU.Model.Models;

namespace SQLSeverDal.UnionInfor
{
    public class UnionInforDal : BaseDal
    {
        /// <summary>
        /// 取出“架构”数据库中的数据，返回数据列表
        /// </summary>
        /// <returns></returns>
        public IList<JiaGou> Query_JiaGou()
        {
            const string Query_factorySql = @"select id,
                                            mingcheng,
                                            faburen,
                                            jieshao,
                                            shijian 
                                            from tb_jiagou
                                           ";
            return base.Query<JiaGou>(Query_factorySql).ToList();
        }
        /// <summary>
        /// 取出“法规”数据库中的数据，返回数据列表
        /// </summary>
        /// <returns></returns>
        public IList<FaGui> Query_FaGui()
        {
            const string Query_factorySql = @"select id,
                                            mingcheng,
                                            faburen,
                                            jieshao,
                                            shijian 
                                            from tb_fagui
                                           ";
            return base.Query<FaGui>(Query_factorySql).ToList();
        }
        /// <summary>
        /// 取出“公告”数据库中的数据，返回数据列表
        /// </summary>
        /// <returns></returns>
        public IList<GongGao> Query_GongGao()
        {
            const string Query_factorySql = @"select id,
                                            mingcheng,
                                            faburen,
                                            jieshao,
                                            shijian 
                                            from tb_gonggao
                                           ";
            return base.Query<GongGao>(Query_factorySql).ToList();
        }
    }
}
