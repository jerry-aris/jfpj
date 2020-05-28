using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YcTeam.Models.Master
{
    public class EvContent:BaseEntity
    {
        /// <summary>
        /// 内容编号
        /// </summary>
        public int ContentCode { get; set; }

        /// <summary>
        /// 评价标准内容
        /// </summary>
        public string Content { get; set; }

       

    }
}
