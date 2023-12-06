using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanBell.Sqlsugar.Model
{
    [SugarTable("test_model","测试表")]
    public class TestModel
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
