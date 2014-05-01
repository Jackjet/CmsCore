using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmsCore.DataBase;

namespace CmsCore.Areas.Manage.Services
{
    public abstract class BaseService : IDisposable
    {
        private readonly CmsCoreDB _cmsCoreDB = new CmsCoreDB();

        public CmsCoreDB CmsCoreDB
        {
            get
            {
                return _cmsCoreDB;
            }
        }

        public void Dispose()
        {
            if (_cmsCoreDB != null)
            {
                _cmsCoreDB.Dispose();
            }
        }
    }
}