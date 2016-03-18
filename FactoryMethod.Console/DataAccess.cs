using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Console
{
    public class DataAccess
    {
        private IDbHelper dbHelper = null;
        /// <summary>
        /// 业务数据库部分
        /// </summary>
        protected IDbHelper DbHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    // 当前数据库连接对象
                    dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.BusinessDbType, BaseSystemInfo.BusinessDbConnection);
                }
                return dbHelper;
            }
        }

        private IDbHelper userCenterDbHelper = null;
        /// <summary>
        /// 用户中心数据库部分
        /// </summary>
        protected IDbHelper UserCenterDbHelper
        {
            get
            {
                if (userCenterDbHelper == null)
                {
                    // 当前数据库连接对象
                    userCenterDbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
                }
                return userCenterDbHelper;
            }
        }

        private IDbHelper workFlowDbHelper = null;
        /// <summary>
        /// 工作流数据库部分
        /// </summary>
        protected IDbHelper WorkFlowDbHelper
        {
            get
            {
                if (workFlowDbHelper == null)
                {
                    // 当前数据库连接对象
                    workFlowDbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
                }
                return workFlowDbHelper;
            }
        }
    }
}
