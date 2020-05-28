using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YcTeam.DTO.Master
{
    public class ProjectDto
    {
        public Guid Id { get; set; }

        [Display(Name = "项目名称")]
        public string Name { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
