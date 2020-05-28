using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YcTeam.Models.Sys;

namespace YcTeam.Models.Master
{
    public class DailyEvaluation:BaseEntity
    {
        //项目名称
        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        //标准分类
        [ForeignKey(nameof(StandardCategory))]
        public Guid StandardCategoryId { get; set; }

        public StandardCategory StandardCategory { get; set; }

        //评分标准
        [ForeignKey(nameof(EvContent))] 
        public Guid EvContentId { get; set; }
        public EvContent EvContent { get; set; }

        //自评分数
        public int SelfPoint { get; set; }

        //扣分原因
        public string Reason { get; set; }

        //审核分数
        public int AuditPoint { get; set; }

    }
}
