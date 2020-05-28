using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace YcTeam.MVCSite.Models.EvContentViewModels
{
    public class EvContentEditViewModel
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