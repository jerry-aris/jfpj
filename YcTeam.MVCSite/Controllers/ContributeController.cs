using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using YcTeam.BLL.Master;
using YcTeam.DTO.Master;
using YcTeam.IBLL.Master;
using YcTeam.MVCSite.Models.ContributeViewModels;

namespace YcTeam.MVCSite.Controllers
{
    public class ContributeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ContributeList(int pageIndex = 1, int pageSize = 5)
        {
            //总页码、当前页码、可显示总页码
            var contributeSvc = new ContributeService();
            //当前第n页数据
            var articles = await contributeSvc.GetAllContribute(pageIndex, pageSize, false);
            //总个数
            var dataCount = await contributeSvc.GetDataCount();
            //绑定分页
            var list = new PagedList<ContributeDto>(articles, pageIndex, pageSize, dataCount);

            return View(list);
        }

        [HttpGet]
        public ActionResult CreateContribute()
        {
            return View();
        }

        /// <summary>
        /// 添加评价标准
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContribute(ContributeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                IContributeService contributeSvc = new ContributeService();
                contributeSvc.CreateContribute(model.AddPointProject, model.AddPointContent, model.AddPointMethod,
                    model.SelfPoint, model.SelfReason, model.AuditPoint);
                return RedirectToAction(nameof(ContributeList));
            }
            ModelState.AddModelError("", @"您录入的信息有误");
            return View();
        }
        /// <summary>
        /// 获取修改评价标准
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ContributeEdit(Guid id)
        {
            var contributeService = new ContributeService();
            var data = await contributeService.GetOneContributeById(id);

            return View(new ContributeEditViewModel()
            {
                Id = data.Id,
                AddPointProject = data.AddPointProject,
                AddPointContent = data.AddPointContent,
                AddPointMethod = data.AddPointMethod,
                SelfPoint = data.SelfPoint,
                SelfReason = data.SelfReason,
                AuditPoint = data.AuditPoint
            });
        }
        /// <summary>
        /// 修改评价标准
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ContributeEdit(Models.ContributeViewModels.ContributeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contributeService = new ContributeService();
                await contributeService.EditContribute(model.Id, model.AddPointProject, model.AddPointContent, model.AddPointMethod,
                    model.SelfPoint, model.SelfReason, model.AuditPoint);
                return RedirectToAction(nameof(ContributeList));
            }
            else
            {
                await new ContributeService().CreateContribute(model.AddPointProject, model.AddPointContent, model.AddPointMethod,
                    model.SelfPoint, model.SelfReason, model.AuditPoint);
                return View(model);
            }
        }
        /// <summary>
        /// 评价标准详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ContributeDetails(Guid? id)
        {
            var contributeService = new ContributeService();
            if (id == null || !await contributeService.ExistsContribute(id.Value))
            {
                return RedirectToAction(nameof(ContributeList));
            }
            return View(await contributeService.GetOneContributeById(id.Value));
        }

        [HttpGet]
        public async Task<ActionResult> ContributeDelete(Guid id)
        {
            var contributeService = new ContributeService();
            await contributeService.RemoveContribute(id);
            return RedirectToAction(nameof(ContributeList));
        }
    }
}
