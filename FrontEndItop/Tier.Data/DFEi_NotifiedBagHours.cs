using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DFEi_NotifiedBagHours : DataParent<Dto.FEi_NotifiedBagHours>
    {
        #region [Constructors]
        public DFEi_NotifiedBagHours()
            : base() { }

        public DFEi_NotifiedBagHours(string ConnectionStringName)
            : base(ConnectionStringName) { }
        #endregion

        public override void AssingParametersValues(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.FEi_NotifiedBagHours obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("p_notifications_id", obj.notifications_id),
                new MySql.Data.MySqlClient.MySqlParameter("p_baghours_id", obj.baghours_id),
                new MySql.Data.MySqlClient.MySqlParameter("p_date", obj.date),
            });
        }

        public override IList<Dto.FEi_NotifiedBagHours> RetrieveFiltered(Dto.FEi_NotifiedBagHours obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_notifiedbaghours");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Select));
                this.AssingParametersValues(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.FEi_NotifiedBagHours>(reader);
                }
            }
        }

        public override bool Insert(Dto.FEi_NotifiedBagHours obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_notifiedbaghours");

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.Insert));
                this.AssingParametersValues(cmd, obj);

                byte id = Convert.ToByte(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return id > 0;
            }
        }

        public override bool Insert(Dto.FEi_NotifiedBagHours obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.FEi_NotifiedBagHours obj)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.FEi_NotifiedBagHours obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.FEi_NotifiedBagHours obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.FEi_NotifiedBagHours obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public bool GetNotificationBagHourFlag(Dto.FEi_NotifiedBagHours obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = base.GetProcedureNameWithSchema("usp_core_notifiedbaghours");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("p_accion", StoreProcedureActions.GetBagHourNotificationFlag));

                this.AssingParametersValues(cmd, obj);

                bool result = Convert.ToBoolean(base.CurrentDatabase.ExecuteScalar(cmd));

                return result;
            }
        }
    }
}
