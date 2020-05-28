using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YcTeam.Models.Sys;

namespace YcTeam.Models.Master
{
   public class PointSum:BaseEntity
    {
        //党员姓名
        [ForeignKey(nameof(SysUser))]
        public Guid UserId { get; set; }

        public SysUser SysUser { get; set; }


    }
}
