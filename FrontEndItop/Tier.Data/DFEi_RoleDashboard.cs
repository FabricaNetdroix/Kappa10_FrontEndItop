using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DFEi_RoleDashboard : DataParent<Dto.FEi_RoleDashboard>
    {
        #region [Constructors]
        public DFEi_RoleDashboard()
            : base() { }

        public DFEi_RoleDashboard(string ConnectionStringName)
            : base(ConnectionStringName) { }
        #endregion

        public override void AssingParametersValues(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.FEi_RoleDashboard obj)
        {
            throw new NotImplementedException();
        }

        public override IList<Dto.FEi_RoleDashboard> RetrieveFiltered(Dto.FEi_RoleDashboard obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(Dto.FEi_RoleDashboard obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(Dto.FEi_RoleDashboard obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.FEi_RoleDashboard obj)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.FEi_RoleDashboard obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.FEi_RoleDashboard obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.FEi_RoleDashboard obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public Dto.FEi_RoleDashboard GetRoleDashboard(int role)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_reports");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.GetDashboardInfo));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_userrole", role));

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.FEi_RoleDashboard>(reader).FirstOrDefault();
                }
            }
        }
    }
}
