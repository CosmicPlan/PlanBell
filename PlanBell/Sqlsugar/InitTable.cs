using PlanBell.Sqlsugar.Model;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanBell.Sqlsugar
{
   public class InitTable
    {
       /// <summary>
      /// 创建db、表
      /// </summary>
        public static void InitDb()
        {
            var db = DbScoped.SugarScope;
            ////建库：如果不存在创建数据库存在不会重复创建
            db.DbMaintenance.CreateDatabase();
            db.CodeFirst.InitTables(typeof(TestModel));
        }
    }
}
