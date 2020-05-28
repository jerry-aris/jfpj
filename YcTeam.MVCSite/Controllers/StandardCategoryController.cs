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
using YcTeam.MVCSite.Models.StandardCategoryViewModels;

namespace YcTeam.MVCSite.Controllers
{
    [UserAuth]
    public class StandardCategoryController:Controller
    {
        
        
            public ActionResult Index()
            {
                return View();
            }

            [HttpGet]
            public async Task<ActionResult> StandardCategoryList(int pageIndex = 1, int pageSize = 20)
            {
                //总页码、当前页码、可显示总页码
                var standardCategorySvc = new StandardCategoryService();
                //当前第n页数据
                var articles = await standardCategorySvc.GetAllStandardCategory(pageIndex, pageSize, false);
                //总个数
                var dataCount = await standardCategorySvc.GetDataCount();
                //绑定分页
                var list = new PagedList<StandardCategoryDto>(articles, pageIndex, pageSize, dataCount);

                return View(list);
            }

            [HttpGet]
            public ActionResult CreateStandardCategory()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult CreateStandardCategory(StandardCategoryCreateViewModel model)
            {
                if (ModelState.IsValid)
                {
                    IStandardCategoryService standardCategorySvc = new StandardCategoryService();
                    standardCategorySvc.CreateStandardCategory(model.Name, model.CategoryCode);
                    return RedirectToAction(nameof(StandardCategoryList));
                }
                ModelState.AddModelError("", @"您录入的信息有误");
                return View();
            }

            [HttpGet]
            public async Task<ActionResult> StandardCategoryEdit(Guid id)
            {
                var standardCategoryService = new StandardCategoryService();
                var data = await standardCategoryService.GetOneStandardCategoryById(id);

                return View(new StandardCategoryEditViewModel()
                {
                    Id = data.Id,
                    Name = data.Name,
                    CategoryCode = data.CategoryCode,
                    
                });
            }

            [HttpPost]
            public async Task<ActionResult> StandardCategoryEdit(Models.StandardCategoryViewModels.StandardCategoryEditViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var standardCategoryService = new StandardCategoryService();
                    await standardCategoryService.EditStandardCategory(model.Id, model.Name, model.CategoryCode);
                    return RedirectToAction(nameof(StandardCategoryList));
                }
                else
                {
                    await new StandardCategoryService().CreateStandardCategory(model.Name, model.CategoryCode);
                    return View(model);
                }
            }

            [HttpGet]
            public async Task<ActionResult> StandardCategoryDetails(Guid? id)
            {
                var standardCategoryService = new StandardCategoryService();
                if (id == null || !await standardCategoryService.ExistsStandardCategory(id.Value))
                {
                    return RedirectToAction(nameof(StandardCategoryList));
                }
                return View(await standardCategoryService.GetOneStandardCategoryById(id.Value));
            }

            [HttpGet]
            public async Task<ActionResult> StandardCategoryDelete(Guid id)
            {
                var standardCategoryService = new StandardCategoryService();
                await standardCategoryService.RemoveStandardCategory(id);
                return RedirectToAction(nameof(StandardCategoryList));
            }
        }
    }