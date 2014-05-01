using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public interface IDataModel
    {
        DataTable GetDataSource(string tableName, int categoryId, int pageIndex, int pageSize);

        int GetTotalCount(string tableName, int categoryId);
    }
}