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
using YcTeam.MVCSite.Filters;
using YcTeam.MVCSite.Models.VetoEvaluationViewModels;

namespace YcTeam.MVCSite.Controllers
{
    [UserAuth]
    public class VetoEvaluationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> VetoEvaluationList(int pageIndex = 1, int pageSize = 1)
        {
            //总页码、当前页码、可显示总页码
            var vetoEvaluationSvc = new VetoEvaluationService();
            //当前第n页数据
            var articles = await vetoEvaluationSvc.GetAllVetoEvaluation(pageIndex, pageSize, false);
            //总个数
            var dataCount = await vetoEvaluationSvc.GetDataCount();
            //绑定分页
            var list = new PagedList<VetoEvaluationDto>(articles, pageIndex, pageSize, dataCount);

            return View(list);
        }

        [HttpGet]
        public ActionResult CreateVetoEvaluation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVetoEvaluation(VetoEvaluationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                IVetoEvaluationService vetoEvaluationSvc = new VetoEvaluationService();
                vetoEvaluationSvc.CreateVetoEvaluation(model.Project, model.VetoCondition, model.VetoContent);
                return RedirectToAction(nameof(VetoEvaluationList));
            }
            ModelState.AddModelError("", @"您录入的信息有误");
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> VetoEvaluationEdit(Guid id)
        {
            var vetoEvaluationService = new VetoEvaluationService();
            var data = await vetoEvaluationService.GetOneVetoEvaluationById(id);

            return View(new VetoEvaluationEditViewModel()
            {
                Id = data.Id,
                Project = data.Project,
                VetoCondition = data.VetoCondition,
                VetoContent = data.VetoContent,
                
            });
        }

        [HttpPost]
        public async Task<ActionResult> VetoEvaluationEdit(Models.VetoEvaluationViewModels.VetoEvaluationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vetoEvaluationService = new VetoEvaluationService();
                await vetoEvaluationService.EditVetoEvaluation(model.Id, model.Project, model.VetoCondition, model.VetoContent);
                return RedirectToAction(nameof(VetoEvaluationList));
            }
            else
            {
                await new VetoEvaluationService().CreateVetoEvaluation(model.Project, model.VetoCondition, model.VetoContent);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> VetoEvaluationDetails(Guid? id)
        {
            var vetoEvaluationService = new VetoEvaluationService();
            if (id == null || !await vetoEvaluationService.ExistsVetoEvaluation(id.Value))
            {
                return RedirectToAction(nameof(VetoEvaluationList));
            }
            return View(await vetoEvaluationService.GetOneVetoEvaluationById(id.Value));
        }

        [HttpGet]
        public async Task<ActionResult> VetoEvaluationDelete(Guid id)
        {
            var vetoEvaluationService = new VetoEvaluationService();
            await vetoEvaluationService.RemoveVetoEvaluation(id);
            return RedirectToAction(nameof(VetoEvaluationList));
        }
    }

}