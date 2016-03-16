using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace Chat.Common
{
    public class DataTable2EntityListHelper
    {
        /// <summary>
        /// 将一个列表转换成DataTable,如果列表为空将返回空的DataTable结构
        /// </summary>
        /// <typeparam name="T">要转换的数据类型</typeparam>
        /// <param name="entityList">实体对象列表</param> 
        public static DataTable EntityListToDataTable<T>(List<T> entityList)
        {
            DataTable dt = new DataTable();

            //取类型T所有Propertie
            Type entityType = typeof(T);
            PropertyInfo[] entityProperties = entityType.GetProperties();
            Type colType = null;
            foreach (PropertyInfo propInfo in entityProperties)
            {

                if (propInfo.PropertyType.IsGenericType)
                {
                    colType = Nullable.GetUnderlyingType(propInfo.PropertyType);
                }
                else
                {
                    colType = propInfo.PropertyType;
                }

                if (colType.FullName.StartsWith("System"))
                {
                    dt.Columns.Add(propInfo.Name, colType);
                }
            }

            if (entityList != null && entityList.Count > 0)
            {
                foreach (T entity in entityList)
                {
                    DataRow newRow = dt.NewRow();
                    foreach (PropertyInfo propInfo in entityProperties)
                    {
                        if (dt.Columns.Contains(propInfo.Name))
                        {
                            object objValue = propInfo.GetValue(entity, null);
                            newRow[propInfo.Name] = objValue == null ? DBNull.Value : objValue;
                        }
                    }
                    dt.Rows.Add(newRow);
                }
            }

            return dt;
        }


        /// <summary>
        /// 将一个DataTable转换成列表
        /// </summary>
        /// <typeparam name="T">实体对象的类型</typeparam>
        /// <param name="dt">要转换的DataTable</param>
        /// <returns></returns>
        public static List<T> DataTableToEntityList<T>(DataTable dt)
        {
            List<T> entiyList = new List<T>();

            Type entityType = typeof(T);
            PropertyInfo[] entityProperties = entityType.GetProperties();

            foreach (DataRow row in dt.Rows)
            {
                T entity = Activator.CreateInstance<T>();

                foreach (PropertyInfo propInfo in entityProperties)
                {
                    if (dt.Columns.Contains(propInfo.Name))
                    {
                        if (!row.IsNull(propInfo.Name))
                        {
                            propInfo.SetValue(entity, row[propInfo.Name], null);
                        }
                    }
                }

                entiyList.Add(entity);
            }

            return entiyList;
        }
    }
}