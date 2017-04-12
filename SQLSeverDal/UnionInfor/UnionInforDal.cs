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
    }
}
