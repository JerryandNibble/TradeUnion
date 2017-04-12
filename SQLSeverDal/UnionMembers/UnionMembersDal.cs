using SQLServerDal;
using System.Collections.Generic;
using System.Linq;
using TU.Model.Models;

namespace SQLSeverDal.UnionMembers
{
    public class UnionMembersDal : BaseDal
    {
        public IList<KeHu> Query_KeHu()
        {
            const string Query_factorySql = @"select xingming,
                                                     shengri,
                                                     address,
                                                     lianxifangshi,
                                                     leixing
                                              from tb_kehu
                                           ";
            return Query<KeHu>(Query_factorySql).ToList();
        }

    }
}
