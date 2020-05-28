using System;
using System.Collections.Generic;
using System.Linq;
using YcTeam.IDAL.Master;
using YcTeam.IDAL.System;
using YcTeam.Models;
using YcTeam.Models.Master;
using YcTeam.Models.Sys;

namespace YcTeam.DAL.System
{
    public class SysUserDao : BaseService<SysUser>, ISysUserDao
    {
        public SysUserDao() : base(new YcContext())
        {

        }
    }
}
