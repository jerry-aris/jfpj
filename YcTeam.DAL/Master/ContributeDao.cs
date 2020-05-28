using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YcTeam.IDAL.Master;
using YcTeam.Models;
using YcTeam.Models.Master;

namespace YcTeam.DAL.Master
{
   public class ContributeDao : BaseService<Contribute>, IContributeDao
    {
        public ContributeDao() : base(new YcContext())
        {

        }
    }
}
