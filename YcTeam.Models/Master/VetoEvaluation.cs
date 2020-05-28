using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.Models.Master
{
    public class VetoEvaluation:BaseEntity
    {
        public string Project { get; set; }


        public string VetoCondition { get; set; }

        public string VetoContent { get; set; }
       
    }
}
