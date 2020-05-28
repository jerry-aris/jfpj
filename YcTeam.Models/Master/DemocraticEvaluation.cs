using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YcTeam.Models.Sys;

namespace YcTeam.Models.Master
{
   public class DemocraticEvaluation:BaseEntity
    {
        //党员姓名
        [ForeignKey(nameof(SysUser))]
        public Guid UserId { get; set; }

        public SysUser SysUser { get; set; }

        //日常评价
        [ForeignKey(nameof(DailyEvaluation))]
        public Guid DailyEvaluationId { get; set; }

        public DailyEvaluation DailyEvaluation { get; set; }

        //贡献积分
        [ForeignKey(nameof(Contribute))]
        public Guid ContributeId { get; set; }

        public Contribute Contribute { get; set; }

        //否决评价
        [ForeignKey(nameof(VetoEvaluation))]
        public Guid VetoEvaluationId { get; set; }

        public VetoEvaluation VetoEvaluation { get; set; }

        //党员综合评价
        public int ComprehensivePoint { get; set; }
    }
}
