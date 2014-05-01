using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CmsCore.DataBase;

namespace CmsCore.Areas.Manage.Services
{
    public class DefaultCategoryService : BaseService, ICategoryService
    {
        public void Create(Category model)
        {
            CmsCoreDB.Category.Add(model);
        }

        public bool Delete(int id)
        {
            var model = CmsCoreDB.Category.FirstOrDefault(p => p.ID == id);

            if (model == null) return false;

            CmsCoreDB.Entry(model).State = EntityState.Deleted;

            return CmsCoreDB.SaveChanges() > 0;
        }

        public bool Update(Category model)
        {
            var dbModel = CmsCoreDB.Category.FirstOrDefault(p => p.ID == model.ID);

            if (dbModel == null) return false;

            dbModel.CatPath = model.CatPath;
            dbModel.CategoryTemplate = model.CategoryTemplate;
            dbModel.DefaultStyle = model.DefaultStyle;
            dbModel.ListPageSize = model.ListPageSize;
            dbModel.ListTemplate = model.ListTemplate;
            dbModel.MetaDescription = model.MetaDescription;
            dbModel.MetaKeywords = model.MetaKeywords;
            dbModel.MetaTitle = model.MetaTitle;
            dbModel.ModelId = model.ModelId;
            dbModel.ModelType = model.ModelType;
            dbModel.Order = model.Order;
            dbModel.ParentId = model.ParentId;
            dbModel.ShowPageSize = model.ShowPageSize;
            dbModel.ShowTemplate = model.ShowTemplate;
            dbModel.SiteId = model.SiteId;
            dbModel.Title = model.Title;
            dbModel.Url = model.Url;

            CmsCoreDB.Entry(dbModel).State = EntityState.Modified;

            return CmsCoreDB.SaveChanges() > 0;
        }

        public IList<Category> Query()
        {
            return CmsCoreDB.Category.OrderByDescending(p => p.CreateTime).ToList();
        }
    }
}