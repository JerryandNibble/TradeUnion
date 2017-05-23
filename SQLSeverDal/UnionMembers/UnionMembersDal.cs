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
                                              from tb_kehu";
            return Query<KeHu>(Query_factorySql).ToList();
        }

        #region 对教职工成员进行遍历操作的Dal语句
        public KeHu QueryEmployee(int Id)
        {
            const string Query_Employeesql = @"select xingming,
                                                     shengri,
                                                     address,
                                                     lianxifangshi
                                            from tb_kehu
                                            where ID = @Id";
            var Model = base.QueryFirst<KeHu>(Query_Employeesql, new { Id = Id });
            return Model;
        }
        #endregion

    }
}
