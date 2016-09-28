using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DFEi_Users : DataParent<Dto.FEi_User>
    {
        #region [Constructors]
        public DFEi_Users()
            : base() { }

        public DFEi_Users(string ConnectionStringName)
            : base(ConnectionStringName) { }
        #endregion

        public override void AssingParametersValues(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.FEi_User obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("p_id", obj.id),
                new MySql.Data.MySqlClient.MySqlParameter("p_alias", obj.alias),
                new MySql.Data.MySqlClient.MySqlParameter("p_password", obj.password),
                new MySql.Data.MySqlClient.MySqlParameter("p_role", obj.role),
                new MySql.Data.MySqlClient.MySqlParameter("p_first_name", obj.first_name),
                new MySql.Data.MySqlClient.MySqlParameter("p_last_name", obj.last_name),
                new MySql.Data.MySqlClient.MySqlParameter("p_email", obj.email),
                new MySql.Data.MySqlClient.MySqlParameter("p_department", obj.department),
                new MySql.Data.MySqlClient.MySqlParameter("p_status", obj.status),
                new MySql.Data.MySqlClient.MySqlParameter("p_notes", obj.notes),
                new MySql.Data.MySqlClient.MySqlParameter("p_last_user_update", obj.last_user_update),
            });
        }

        public override IList<Dto.FEi_User> RetrieveFiltered(Dto.FEi_User obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_security_users");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Select));
                this.AssingParametersValues(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.FEi_User>(reader);
                }
            }
        }

        public override bool Insert(Dto.FEi_User obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_security_users");

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Insert));
                this.AssingParametersValues(cmd, obj);

                obj.id = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.id > 0;
            }
        }

        public override bool Insert(Dto.FEi_User obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.FEi_User obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_security_users");

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Update));
                this.AssingParametersValues(cmd, obj);

                int affectedRecords = Convert.ToInt32(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return affectedRecords > 0;
            }
        }

        public override bool Update(Dto.FEi_User obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.FEi_User obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_security_users");

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Delete));
                this.AssingParametersValues(cmd, obj);

                int affectedRecords = Convert.ToInt32(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return affectedRecords > 0;
            }
        }

        public override bool Delete(Dto.FEi_User obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
