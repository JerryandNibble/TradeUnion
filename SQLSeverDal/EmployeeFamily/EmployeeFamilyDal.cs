using SQLServerDal;
using System.Collections.Generic;
using System.Linq;
using TU.Model.Models;

namespace SQLSeverDal.EmployeeFamily
{
    public class EmployeeFamilyDal : BaseDal
    {
        public IList<ZiNV> Query_ZiNV()
        {
            const string Query_factorySql = @"select xingming,
                                                     guanxi,
                                                     xingming2,
                                                     age,
                                                     xueli,
                                                     xuexiao
                                              from tb_zinv
                                           ";
            return Query<ZiNV>(Query_factorySql).ToList();
        }

        //public IList<>
    }
}
