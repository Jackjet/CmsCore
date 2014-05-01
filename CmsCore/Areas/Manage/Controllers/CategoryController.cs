using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CmsCore.Areas.Manage.Models;
using CmsCore.Areas.Manage.Services;

namespace CmsCore.Areas.Manage.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        //
        // GET: /Manage/Category/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new CategoryCreateParam());
        }

        [HttpPost]
        public ActionResult Create(CategoryCreateParam model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            return RedirectToAction("Index");
        }
	}
}