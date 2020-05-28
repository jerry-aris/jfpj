using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YcTeam.MVCSite.Models.ProjectViewModels
{
    public class ProjectEditViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "项目名称")]
        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        
    }
}