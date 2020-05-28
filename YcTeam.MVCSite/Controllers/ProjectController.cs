using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using YcTeam.BLL;
using YcTeam.BLL.Master;
using YcTeam.IBLL.Master;
using YcTeam.MVCSite.Filters;
using YcTeam.MVCSite.Models.ProjectViewModels;

namespace YcTeam.MVCSite.Controllers
{
    [UserAuth]
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> ProjectList(int pageIndex = 1, int pageSize = 5)
        {
            //总页码、当前页码、可显示总页码
            var projectSvc = new ProjectService();
            //当前第n页数据
            var articles = await projectSvc.GetAllProject(pageIndex, pageSize, false);
            //总个数
            var dataCount = await projectSvc.GetDataCount();
            //绑定分页
            var list = new PagedList<DTO.Master.ProjectDto>(articles, pageIndex, pageSize, dataCount);

            return View(list);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject(ProjectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                IProjectService projectSvc = new ProjectService();
                projectSvc.CreateProject(model.Name);
                return RedirectToAction(nameof(ProjectList));
            }
            ModelState.AddModelError("", @"您录入的信息有误");
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> ProjectEdit(Guid id)
        {
            var projectService = new ProjectService();
            var data = await projectService.GetOneProjectById(id);

            return View(new ProjectEditViewModel()
            {
                Name = data.Name,
                
            });
        }
        [HttpPost]
        public async Task<ActionResult> ProjectEdit(Models.ProjectViewModels.ProjectEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var projectService = new ProjectService();
                await projectService.EditProject(model.Id, model.Name);
                return RedirectToAction(nameof(ProjectList));
            }
            else
            {
                await new ProjectService().CreateProject(model.Name);
                return View(model);
            }
        }
        [HttpGet]
        public async Task<ActionResult> ProjectDetails(Guid? id)
        {
            var projectService = new ProjectService();
            if (id == null || !await projectService.ExistsProject(id.Value))
            {
                return RedirectToAction(nameof(ProjectList));
            }
            return View(await projectService.GetOneProjectById(id.Value));
        }

        [HttpGet]
        public async Task<ActionResult> ProjectDelete(Guid id)
        {
            var projectService = new ProjectService();
            await projectService.RemoveProject(id);
            return RedirectToAction(nameof(ProjectList));
        }
    }
}