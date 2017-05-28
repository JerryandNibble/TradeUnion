using SQLServerDal;
using System.Collections.Generic;
using System.Linq;
using TU.Model.Models;

namespace SQLSeverDal.EmployeeFamily
{
    public class EmployeeFamilyDal : BaseDal
    {
        #region 浏览子女信息方法
        public IList<ZiNV> Query_ZiNV()
        {
            const string Query_factorySql = @"select id,
                                                     xingming,
                                                     guanxi,
                                                     xingming2,
                                                     age,
                                                     xueli,
                                                     xuexiao
                                              from tb_zinv
                                           ";
            return Query<ZiNV>(Query_factorySql).ToList();
        }

        public ZiNV QueryChild(int Id)
        {
            const string Query_Childsql = @"select id,
                                            bianhao,
                                            xingming,
                                            guanxi,
                                            xingming2,
                                            age,
                                            xuexiao
                                            from tb_zinv
                                            where ID = @Id
                                           ";
            var Model = base.QueryFirst<ZiNV>(Query_Childsql, new { Id = Id });
            return Model;
        }
        #endregion
        public IList<FTeShu> Query_FTeShu()
        {
            const string Query_factorySql = @"select id,
                                                     bianhao,
                                                     xingming,
                                                     teshu
                                              from tb_fteshu
                                           ";
            return Query<FTeShu>(Query_factorySql).ToList();
        }
    }
}
