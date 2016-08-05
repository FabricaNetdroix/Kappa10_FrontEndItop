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

        public enum DataBaseEntities : byte
        {
            BagHours = 1,
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
    }

    public static class IENumerableExtensions
    {
        public static IEnumerable<T> FromDataReader<T>(this IEnumerable<T> list, System.Data.IDataReader dr)
        {
            //Instance reflec object from Reflection class coded above
            Reflection reflec = new Reflection();
            //Declare one "instance" object of Object type and an object list
            Object instance;
            List<Object> lstObj = new List<Object>();

            //dataReader loop
            while (dr.Read())
            {
                //Create an instance of the object needed.
                //The instance is created by obtaining the object type T of the object
                //list, which is the object that calls the extension method
                //Type T is inferred and is instantiated
                instance = Activator.CreateInstance(list.GetType().GetGenericArguments()[0]);

                // Loop all the fields of each row of dataReader, and through the object
                // reflector (first step method) fill the object instance with the datareader values
                foreach (System.Data.DataRow drow in dr.GetSchemaTable().Rows)
                {
                    reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), dr[drow.ItemArray[0].ToString()]);
                }

                //Add object instance to list
                lstObj.Add(instance);
            }

            List<T> lstResult = new List<T>();
            foreach (Object item in lstObj)
            {
                lstResult.Add((T)Convert.ChangeType(item, typeof(T)));
            }

            return lstResult;
        }
    }

    public class Reflection
    {
        public void FillObjectWithProperty(ref object objectTo, string propertyName, object propertyValue)
        {
            Type tOb2 = objectTo.GetType();
            tOb2.GetProperty(propertyName).SetValue(objectTo, propertyValue);
        }
    }
}
