using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DFEi_Notifications : DataParent<Dto.FEi_Notification>
    {
        #region [Constructors]
        public DFEi_Notifications()
            : base() { }

        public DFEi_Notifications(string ConnectionStringName)
            : base(ConnectionStringName) { }
        #endregion

        public override void AssingParametersValues(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.FEi_Notification obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("p_id", obj.id),
                new MySql.Data.MySqlClient.MySqlParameter("p_recipients", obj.recipients),
                new MySql.Data.MySqlClient.MySqlParameter("p_date_rule", obj.date_rule),
                new MySql.Data.MySqlClient.MySqlParameter("p_hours_rule", obj.hours_rule),
                new MySql.Data.MySqlClient.MySqlParameter("p_html_template", obj.html_template),
                new MySql.Data.MySqlClient.MySqlParameter("p_notes", obj.notes),
                new MySql.Data.MySqlClient.MySqlParameter("p_status", obj.status),
                new MySql.Data.MySqlClient.MySqlParameter("p_last_user_update", obj.last_user_update),
            });
        }

        public override IList<Dto.FEi_Notification> RetrieveFiltered(Dto.FEi_Notification obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_notifications");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Select));
                this.AssingParametersValues(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.FEi_Notification>(reader);
                }
            }
        }

        public override bool Insert(Dto.FEi_Notification obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_notifications");

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Insert));
                this.AssingParametersValues(cmd, obj);

                obj.id = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.id > 0;
            }
        }

        public override bool Insert(Dto.FEi_Notification obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.FEi_Notification obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_notifications");

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Update));
                this.AssingParametersValues(cmd, obj);

                int affectedRecords = Convert.ToInt32(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return affectedRecords > 0;
            }
        }

        public override bool Update(Dto.FEi_Notification obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.FEi_Notification obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_notifications");

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Delete));
                this.AssingParametersValues(cmd, obj);

                int affectedRecords = Convert.ToInt32(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return affectedRecords > 0;
            }
        }

        public override bool Delete(Dto.FEi_Notification obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
