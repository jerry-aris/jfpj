using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using YcTeam.BLL.Master;
using YcTeam.BLL.System;
using YcTeam.DTO.Master;
using YcTeam.DTO.System;
using YcTeam.IBLL.Master;
using YcTeam.IBLL.System;
using YcTeam.MVCSite.Filters;
using YcTeam.MVCSite.Models.SysDepartViewModels;

namespace YcTeam.MVCSite.Controllers
{
    //[UserAuth]
    public class SysDepartController : Controller
    {
        // GET: SysDepart
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 部门清单
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SysDepartList(int pageIndex = 1, int pageSize = 20)
        {
            //总页码、当前页码、可显示总页码
            var sysDepartSvc = new SysDepartService();
            //当前第n页数据
            var sysDepart = await sysDepartSvc.GetAllSysDepart(pageIndex, pageSize, false);
            //总个数
            var dataCount = await sysDepartSvc.GetDataCount();
            //绑定分页
            var list = new PagedList<SysDepartDto>(sysDepart, pageIndex, pageSize, dataCount);

            return View(list);
        }

        /// <summary>
        /// 部门添加
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateSysDepart()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CreateSysDepart(SysDepartViewModel model)
        {
            if (ModelState.IsValid)
            {
                ISysDepartService sysDepartSvc = new SysDepartService();
                sysDepartSvc.CreateSysDepart(model.DepartName,model.RegionCity,model.RegionCounty);
                return RedirectToAction(nameof(SysDepartList));
            }
            ModelState.AddModelError("", @"您录入的信息有误");
            return View();
        }

        /// <summary>
        /// 部门修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> SysDepartEdit(Guid id)
        {
            var sysDepartService = new SysDepartService();
            var data = await sysDepartService.GetOneSysDepartById(id);

            return View(new SysDepartViewModel()
            {
                Id = data.Id,
                DepartName = data.DepartName,
                RegionCity = data.RegionCity,
                RegionCounty = data.RegionCounty
            });
        }

        [HttpPost]
        public async Task<ActionResult> SysDepartEdit(Models.SysDepartViewModels.SysDepartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sysDepartService = new SysDepartService();
                await sysDepartService.EditSysDepart(model.Id, model.DepartName,model.RegionCity,model.RegionCounty);
                return RedirectToAction(nameof(SysDepartList));
            }
            else
            {
                await new SysDepartService().CreateSysDepart(model.DepartName,model.RegionCity,model.RegionCounty);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> SysDepartDetails(Guid? id)
        {
            var sysDepartService = new SysDepartService();
            if (id == null || !await sysDepartService.ExistsSysDepart(id.Value))
            {
                return RedirectToAction(nameof(SysDepartList));
            }
            return View(await sysDepartService.GetOneSysDepartById(id.Value));
        }

        [HttpGet]
        public async Task<ActionResult> SysDepartDelete(Guid id)
        {
            var sysDepartService = new SysDepartService();
            await sysDepartService.RemoveSysDepart(id);
            return RedirectToAction(nameof(SysDepartList));
        }
    }
}