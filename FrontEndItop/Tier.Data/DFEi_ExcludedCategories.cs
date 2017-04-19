using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DFEi_ExcludedCategories : DataParent<Dto.ExcludeSubcategory>
    {
        #region [Constructors]
        public DFEi_ExcludedCategories()
            : base() { }

        public DFEi_ExcludedCategories(string ConnectionStringName)
            : base(ConnectionStringName) { }
        #endregion

        public override void AssingParametersValues(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.ExcludeSubcategory obj)
        {
            throw new NotImplementedException();
        }

        public override IList<Dto.ExcludeSubcategory> RetrieveFiltered(Dto.ExcludeSubcategory obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(Dto.ExcludeSubcategory obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(Dto.ExcludeSubcategory obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.ExcludeSubcategory obj)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.ExcludeSubcategory obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.ExcludeSubcategory obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.ExcludeSubcategory obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public string GetConcadenatedExcludedCategories()
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_excludedsubcategories");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.GetConcadenatedExcludedCategories));

                cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                    new MySql.Data.MySqlClient.MySqlParameter("p_id", null)
                });

                return (string)base.CurrentDatabase.ExecuteScalar(cmd);
            }
        }
    }
}
