using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YcTeam.MVCSite
{
    public class Common
    {
        /// <summary>
        /// 登录用户编号
        /// </summary>
        /// <returns></returns>
        public static Guid? GetUserId()
        {
            if (HttpContext.Current.Session["userId"] == null)
            {
                return null;
            }

            return Guid.Parse(HttpContext.Current.Session["userId"].ToString());
        }

        /// <summary>
        /// 登录用户所属部门编号
        /// </summary>
        /// <returns></returns>
        public static Guid? GetUserSysDepartId()
        {
            if (HttpContext.Current.Session["sysDepartId"] == null)
            {
                return null;
            }
            return Guid.Parse(HttpContext.Current.Session["sysDepartId"].ToString());
        }

        /// <summary>
        /// 登录用户所属城市名称
        /// </summary>
        /// <returns></returns>
        public static string GetUserRegionCityName()
        {
            if (HttpContext.Current.Session["regionCity"] == null)
            {
                return "";
            }
            return HttpContext.Current.Session["regionCity"].ToString();
        }

        /// <summary>
        /// 登录用户所属县区名称
        /// </summary>
        /// <returns></returns>
        public static string GetUserRegionCountyName()
        {
            if (HttpContext.Current.Session["regionCounty"] == null)
            {
                return "";
            }
            return HttpContext.Current.Session["regionCounty"].ToString();
        }
    }
}