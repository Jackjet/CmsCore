using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using RazorEngine.Templating;

namespace CmsCore.Service
{
    public class DataModelManage
    {
        private readonly IDataModel _dataModelService = new SqlServerDataModel();

        public int GetTotalCount(string tableName, int categoryId)
        {
            return _dataModelService.GetTotalCount(tableName, categoryId);
        }

        public IEnumerable<dynamic> GetPageList(string tableName, int categoryId, int pageIndex, int pageSize)
        {
            //返回结果集
            var returnResult = new List<dynamic>();

            //获取数据源
            var dataSource = _dataModelService.GetDataSource(tableName, categoryId, pageIndex, pageSize);

            //反射发出动态创建类型
            var customType = DefineDynamicType(tableName, dataSource.Columns);

            //创建类型
            var customTypeFields = customType.GetFields();

            //遍历数据源行
            for (var rowIndex = 0; rowIndex < dataSource.Rows.Count; rowIndex++)
            {
                //实例化对象
                var instanceType = Activator.CreateInstance(customType);

                //遍历对象属性
                foreach (var field in customTypeFields)
                {
                    //遍历对象字段
                    for (var columnIndex = 0; columnIndex < dataSource.Columns.Count; columnIndex++)
                    {
                        //按对象字段名称完全匹配
                        if (dataSource.Columns[columnIndex].ColumnName == field.Name)
                        {
                            //给对象字段赋值
                            field.SetValue(instanceType, dataSource.Rows[rowIndex][dataSource.Columns[columnIndex].ColumnName]);
                        }
                    }
                }

                //添加到返回结果集合
                returnResult.Add(instanceType);
            }

            //返回结果
            return returnResult;
        }

        private static Type DefineDynamicType(string dataModelName, DataColumnCollection classDefineForColumn)
        {
            //定义程序集
            var assemblyName = new AssemblyName(string.Format("CmsCore.Dynamic.{0}", dataModelName));
            var customAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            var customModule = customAssembly.DefineDynamicModule(assemblyName.Name, string.Format("{0}.dll", assemblyName.Name));

            //定义Class
            //var customClass = customModule.DefineType(dataModelName, TypeAttributes.Public, typeof(BaseEntity));
            var customClass = customModule.DefineType(dataModelName, TypeAttributes.Public);

            //定义公共字段
            for (var i = 0; i < classDefineForColumn.Count; i++)
            {
                customClass.DefineField(classDefineForColumn[i].ColumnName, classDefineForColumn[i].DataType, FieldAttributes.Public);
            }

            //创建类型
            var customType = customClass.CreateType();

            //保存程序集
            customAssembly.Save(string.Format("{0}.dll", assemblyName.Name));

            //加载
            //AppDomain.CurrentDomain.Load(assemblyName);
            //Assembly.Load(assemblyName);

            //返回类型
            return customType;
        }
    }
}