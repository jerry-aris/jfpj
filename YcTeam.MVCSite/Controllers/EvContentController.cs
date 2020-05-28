using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using YcTeam.BLL;
using YcTeam.BLL.Master;
using YcTeam.DTO;
using YcTeam.DTO.Master;
using YcTeam.IBLL.Master;
using YcTeam.MVCSite.Filters;
using YcTeam.MVCSite.Models.EvContentViewModels;


namespace YcTeam.MVCSite.Controllers
{
    [UserAuth]
    public class EvContentController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> EvContentList(int pageIndex = 1, int pageSize = 5)
        {
            //总页码、当前页码、可显示总页码
            var evContentSvc = new EvContentService();
            //当前第n页数据
            var articles = await evContentSvc.GetAllEvContent(pageIndex, pageSize, false);
            //总个数
            var dataCount = await evContentSvc.GetDataCount();
            //绑定分页
            var list = new PagedList<EvContentDto>(articles, pageIndex, pageSize, dataCount);

            return View(list);
        }

        [HttpGet]
        public ActionResult CreateEvContent()
        {
            return View();
        }

        /// <summary>
        /// 添加评价标准
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvContent(EvContentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                IEvContentService evContentSvc = new EvContentService();
                evContentSvc.CreateEvContent(model.ContentCode, model.Content);
                return RedirectToAction(nameof(EvContentList));
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
        public async Task<ActionResult> EvContentEdit(Guid id)
        {
            var evContentService = new EvContentService();
            var data = await evContentService.GetOneEvContentById(id);

            return View(new EvContentEditViewModel()
            {
                Id = data.Id,
                ContentCode = data.ContentCode,
                Content = data.Content
                });
        }
        /// <summary>
        /// 修改评价标准
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> EvContentEdit(Models.EvContentViewModels.EvContentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var evContentService = new EvContentService();
                await evContentService.EditEvContent(model.Id, model.ContentCode, model.Content);
                return RedirectToAction(nameof(EvContentList));
            }
            else
            {
                await new EvContentService().CreateEvContent(model.ContentCode, model.Content);
                return View(model);
            }
        }
        /// <summary>
        /// 评价标准详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> EvContentDetails(Guid? id)
        {
            var evContentService = new EvContentService();
            if (id == null || !await evContentService.ExistsEvContent(id.Value))
            {
                return RedirectToAction(nameof(EvContentList));
            }
            return View(await evContentService.GetOneEvContentById(id.Value));
        }

        [HttpGet]
        public async Task<ActionResult> EvContentDelete(Guid id)
        {
            var evContentService = new EvContentService();
            await evContentService.RemoveEvContent(id);
            return RedirectToAction(nameof(EvContentList));
        }
    }
}