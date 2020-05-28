using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.Models.Sys
{
   public class SysStaffStateHistory:BaseEntity
    {
            [ForeignKey(nameof(SysUser))]
            public Guid UserId { get; set; }

            public SysUser SysUser { get; set; }
        
    }
}
