using System;
using System.ComponentModel.DataAnnotations;

namespace YcTeam.MVCSite.Models.EvContentViewModels
{
    public class EvContentCreateViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "评价编码")]
        public int ContentCode { get; set; }
        [Display(Name = "评价内容")]
        public string Content { get; set; }
        
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}