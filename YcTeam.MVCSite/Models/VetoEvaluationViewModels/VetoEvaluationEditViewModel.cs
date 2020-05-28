using System;
using System.ComponentModel.DataAnnotations;

namespace YcTeam.MVCSite.Models.VetoEvaluationViewModels
{
    public class VetoEvaluationEditViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "否决条件")]
        public string VetoCondition { get; set; }

        [Display(Name = "项目名称")]
        public string Project { get; set; }


        [Display(Name = "否决内容")]
        public string VetoContent { get; set; }


        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}