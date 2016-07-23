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
            Delete = 4
        }
        #endregion

        public abstract void AssingParametersValues(MySql.Data.MySqlClient.MySqlCommand cmd, T obj);

        public abstract IEnumerable<T> RetrieveFiltered(T obj);

        public abstract bool Insert(T obj);
        public abstract bool Insert(T obj, MySql.Data.MySqlClient.MySqlTransaction objTrans);

        public abstract bool Update(T obj);
        public abstract bool Update(T obj, MySql.Data.MySqlClient.MySqlTransaction objTrans);

        public abstract bool Delete(T obj);
        public abstract bool Delete(T obj, MySql.Data.MySqlClient.MySqlTransaction objTrans);
    }
}
