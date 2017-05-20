using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DFEi_BagHours : DataParent<Dto.FEi_BagHours>
    {
        #region [Constructors]
        public DFEi_BagHours()
            : base() { }

        public DFEi_BagHours(string ConnectionStringName)
            : base(ConnectionStringName) { }
        #endregion

        public override void AssingParametersValues(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.FEi_BagHours obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("p_id", obj.id),
                new MySql.Data.MySqlClient.MySqlParameter("p_organization_id", obj.organization_id),
                new MySql.Data.MySqlClient.MySqlParameter("p_organization_name", obj.organization_name),
                new MySql.Data.MySqlClient.MySqlParameter("p_contract_id", obj.contract_id),
                new MySql.Data.MySqlClient.MySqlParameter("p_contract_name", obj.contract_name),
                new MySql.Data.MySqlClient.MySqlParameter("p_contract_start", obj.contract_start),
                new MySql.Data.MySqlClient.MySqlParameter("p_contract_end", obj.contract_end),
                new MySql.Data.MySqlClient.MySqlParameter("p_contract_description", obj.contract_description),
                new MySql.Data.MySqlClient.MySqlParameter("p_contract_services", obj.contract_services),
                new MySql.Data.MySqlClient.MySqlParameter("p_quantity", obj.quantity),
                new MySql.Data.MySqlClient.MySqlParameter("p_is_warranty", obj.is_warranty),
                new MySql.Data.MySqlClient.MySqlParameter("p_notes", obj.notes),
                new MySql.Data.MySqlClient.MySqlParameter("p_status", obj.status),
                new MySql.Data.MySqlClient.MySqlParameter("p_last_user_update", obj.last_user_update),
                new MySql.Data.MySqlClient.MySqlParameter("p_is_visible", obj.is_visible),
            });
        }

        public override IList<Dto.FEi_BagHours> RetrieveFiltered(Dto.FEi_BagHours obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_baghours");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Select));
                this.AssingParametersValues(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.FEi_BagHours>(reader);
                }
            }
        }

        public override bool Insert(Dto.FEi_BagHours obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_baghours");

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Insert));
                this.AssingParametersValues(cmd, obj);

                obj.id = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.id > 0;
            }
        }

        public override bool Insert(Dto.FEi_BagHours obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.FEi_BagHours obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_baghours");

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Update));
                this.AssingParametersValues(cmd, obj);

                int affectedRecords = Convert.ToInt32(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return affectedRecords > 0;
            }
        }

        public override bool Update(Dto.FEi_BagHours obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.FEi_BagHours obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_baghours");

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Delete));
                this.AssingParametersValues(cmd, obj);

                int affectedRecords = Convert.ToInt32(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return affectedRecords > 0;
            }
        }

        public override bool Delete(Dto.FEi_BagHours obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
