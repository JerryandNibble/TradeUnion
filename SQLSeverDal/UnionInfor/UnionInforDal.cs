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
            return base.Query<JiaGou>(Query_factorySql).ToList();
        }
    }
}
