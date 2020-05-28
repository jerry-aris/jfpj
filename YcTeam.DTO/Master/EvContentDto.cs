using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YcTeam.DTO.Master
{
     public class EvContentDto 
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
