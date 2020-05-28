using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.Models.Master
{
       public class Contribute:BaseEntity
      { 
          /// <summary>
          /// 贡献加分项目
          /// </summary>
          public string AddPointProject { get; set; }
        /// <summary>
        /// 贡献加分内容
        /// </summary>
        public string AddPointContent { get; set; }
        /// <summary>
        /// 贡献加分方法
        /// </summary>
        public string AddPointMethod { get; set; }
        /// <summary>
        /// 自评分数
        /// </summary>
        public int SelfPoint { get; set; }
        /// <summary>
        /// 自评依据
        /// </summary>
        public string SelfReason { get; set; }

        //审核评价分数
        public int AuditPoint { get; set; }
      }
}
