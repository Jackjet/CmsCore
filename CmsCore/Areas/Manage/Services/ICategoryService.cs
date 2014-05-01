using System.Collections.Generic;
using CmsCore.DataBase;

namespace CmsCore.Areas.Manage.Services
{
    public interface ICategoryService
    {
        void Create(Category model);

        bool Delete(int id);

        bool Update(Category model);

        IList<Category> Query();
    }
}