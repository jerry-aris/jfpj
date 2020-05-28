using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.DTO.System
{
    public class SysDepartDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartName { get; set; }

        /// <summary>
        /// 市级单位名称
        /// </summary>
        public string RegionCity { get; set; }

        /// <summary>
        /// 县级单位名称
        /// </summary>
        public string RegionCounty { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
