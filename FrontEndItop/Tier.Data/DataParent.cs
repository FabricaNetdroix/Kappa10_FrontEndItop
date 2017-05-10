using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public abstract class DataParent<T>
    {
        #region [Fields]
        System.Configuration.ConnectionStringSettings objConnectionString;
        DatabaseProviderFactory objDatabaseProviderFactory;
        Database objDatabase;
        #endregion

        #region [Properties]
        public System.Configuration.ConnectionStringSettings CurrentConnectionString { get { return this.objConnectionString; } }
        public Database CurrentDatabase { get { return this.objDatabase; } }

        /// <summary>
        /// Database schema for iTop platform installation Database.
        /// </summary>
        public string iTopPlatformSchema
        {
            get
            {
                return string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["iTopPlatformSchema"].ToString())
                    ? "itop"
                    : System.Configuration.ConfigurationManager.AppSettings["iTopPlatformSchema"].ToString();
            }
        }

        /// <summary>
        /// Database schema for iTop platform installation Database.
        /// </summary>
        public string FEiTopPlatformSchema
        {
            get
            {
                return string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["FEiTopPlatformSchema"].ToString())
                    ? "fe_itop"
                    : System.Configuration.ConfigurationManager.AppSettings["FEiTopPlatformSchema"].ToString();
            }
        }
        #endregion

        #region [Constructors]
        public DataParent()
        {
            DatabaseSettings objSection = (DatabaseSettings)System.Configuration.ConfigurationManager.GetSection("dataConfiguration");

            objDatabaseProviderFactory = new DatabaseProviderFactory();
            objDatabase = objDatabaseProviderFactory.CreateDefault();
            objConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[objSection.DefaultDatabase];
        }

        public DataParent(string ConnectionStringName)
        {
            objDatabaseProviderFactory = new DatabaseProviderFactory();
            objDatabase = objDatabaseProviderFactory.Create(ConnectionStringName);
            objConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionStringName];
        }
        #endregion

        #region [Enumerators]
        internal enum StoreProcedureActions : byte
        {
            Insert = 1,
            Select = 2,
            Update = 3,
            Delete = 4,
            GetConcadenatedExcludedCategories = 5,
            GetBagHourNotificationFlag = 6,
            GetDashboardInfo = 7
        }

        public enum DataBaseEntities : byte
        {
            BagHours = 1,
            Users = 2,
        }
        #endregion

        public abstract void AssingParametersValues(MySql.Data.MySqlClient.MySqlCommand cmd, T obj);

        public abstract IList<T> RetrieveFiltered(T obj);

        public abstract bool Insert(T obj);
        public abstract bool Insert(T obj, MySql.Data.MySqlClient.MySqlTransaction objTrans);

        public abstract bool Update(T obj);
        public abstract bool Update(T obj, MySql.Data.MySqlClient.MySqlTransaction objTrans);

        public abstract bool Delete(T obj);
        public abstract bool Delete(T obj, MySql.Data.MySqlClient.MySqlTransaction objTrans);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeProcedureName"></param>
        /// <returns></returns>
        internal string GetProcedureNameWithSchema(string storeProcedureName)
        {
            return string.Format("{0}.{1}", this.FEiTopPlatformSchema, storeProcedureName);
        }
    }
}
