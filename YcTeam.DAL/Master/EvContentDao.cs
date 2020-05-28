using YcTeam.IDAL.Master;
using YcTeam.Models;
using YcTeam.Models.Master;

namespace YcTeam.DAL.Master
{
    public class EvContentDao : BaseService<EvContent>,IEvContentDao
    {
       

        public EvContentDao() : base(new YcContext())
        {

        }

        }
}
