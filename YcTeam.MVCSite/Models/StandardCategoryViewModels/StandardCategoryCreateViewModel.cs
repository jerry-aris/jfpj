using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YcTeam.MVCSite.Models.StandardCategoryViewModels
{
    public class StandardCategoryCreateViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "分类名称")]
        public string Name { get; set; }

        [Display(Name = "分类编号")]
        public int CategoryCode { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}