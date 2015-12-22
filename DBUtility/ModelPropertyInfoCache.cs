using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DBUtility
{
    /// <summary>
    /// 对象属性的缓存类
    /// </summary>
    public sealed class ModelPropertyInfoCache
    {
        private static Hashtable modelPropertyInfoPool = new Hashtable();

        private ModelPropertyInfoCache() { }

        public readonly static ModelPropertyInfoCache Instance = new ModelPropertyInfoCache();

        public PropertyInfo[] GetProperties<T>()
        {
            Type type = typeof(T);
            string key = type.FullName;
            object ret = null;
            lock (modelPropertyInfoPool)
            {
                if (modelPropertyInfoPool.Contains(key))
                {
                    ret = modelPropertyInfoPool[key];
                }
                else
                {
                    ret = type.GetProperties();
                    modelPropertyInfoPool.Add(key, ret);
                }
            }
            return (PropertyInfo[])ret;
        }

        public int ClearModelPropertyPool()
        {
            int count = modelPropertyInfoPool.Count;
            modelPropertyInfoPool.Clear();
            return count;
        }
    }
}
