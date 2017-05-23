using SQLServerDal;
using System.Collections.Generic;
using System.Linq;
using TU.Model.Models;

namespace SQLSeverDal.UnionInfor
{
    public class UnionInforDal : BaseDal
    {
        public IList<JiaGou> Query_JiaGou()
        {
            const string Query_factorySql = @"select id,
                                            mingcheng,
                                            faburen,
                                            jieshao,
                                            shijian 
                                            from tb_jiagou
                                           ";
            return Query<JiaGou>(Query_factorySql).ToList();
        }

        public IList<FaGui> Query_FaGui()
        {
            const string Query_factorySql = @"select id,
                                            mingcheng,
                                            faburen,
                                            jieshao,
                                            shijian 
                                            from tb_FaGui
                                           ";
            return Query<FaGui>(Query_factorySql).ToList();
        }

        public IList<GongGao> Query_GongGao()
        {
            const string Query_factorySql = @"select id,
                                            mingcheng,
                                            faburen,
                                            jieshao,
                                            shijian 
                                            from tb_gonggao
                                           ";
            return Query<GongGao>(Query_factorySql).ToList();
        }



        #region 对架构信息数据进行遍历操作的Dal语句
        public JiaGou QueryJiaGou(int Id)
        {
            const string Query_JiaGousql = @"select id,
                                            mingcheng,
                                            faburen,
                                            jieshao,
                                            shijian 
                                            from tb_jiagou
                                            where ID = @Id
                                           ";
            var Model = base.QueryFirst<JiaGou>(Query_JiaGousql, new { Id = Id });
            return Model;
        }
        #endregion

        #region 对工会政策法规信息数据进行遍历操作的Dal语句
        public FaGui QueryFaGui(int Id)
        {
            const string Query_OnesMesgBendInfosql = @"select id,
                                            mingcheng,
                                            faburen,
                                            jieshao,
                                            shijian 
                                            from tb_fagui
                                            where ID = @Id
                                           ";
            var Model = base.QueryFirst<FaGui>(Query_OnesMesgBendInfosql, new { Id = Id });
            return Model;
        }
        #endregion

        #region 对工会最新公告数据进行遍历操作的Dal语句
        public GongGao QueryGongGao(int Id)
        {
            const string Query_GongGaosql = @"select id,
                                            mingcheng,
                                            faburen,
                                            jieshao,
                                            shijian
                                            from tb_gonggao
                                            where ID = @Id
                                           ";
            var Model = base.QueryFirst<GongGao>(Query_GongGaosql, new { Id = Id });
            return Model;
        }
        #endregion

    }
}
