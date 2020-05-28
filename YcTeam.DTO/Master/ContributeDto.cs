using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.DTO.Master
{
   public class ContributeDto
    {
        public Guid Id { get; set; }

        [Display(Name = "贡献加分项目")]
        public string AddPointProject { get; set; }

        [Display(Name = "加分因素")]
        public string AddPointContent { get; set; }

        [Display(Name = "考核计分办法")]
        public string AddPointMethod { get; set; }

        [Display(Name = "自评分数")]
        public int SelfPoint { get; set; }

        [Display(Name = "加分原因")]
        public string SelfReason { get; set; }

        [Display(Name = "审核评定分数")]
        public int AuditPoint { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
