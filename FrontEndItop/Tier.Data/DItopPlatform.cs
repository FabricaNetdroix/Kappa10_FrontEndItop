using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DItopPlatform : DataParent<Dto.ItopPlatform>
    {
        #region [Constructors]
        public DItopPlatform()
            : base() { }

        public DItopPlatform(string ConnectionStringName)
            : base(ConnectionStringName) { }
        #endregion

        public override void AssingParametersValues(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.ItopPlatform obj)
        {
            throw new NotImplementedException();
        }

        public override IList<Dto.ItopPlatform> RetrieveFiltered(Dto.ItopPlatform obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(Dto.ItopPlatform obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(Dto.ItopPlatform obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.ItopPlatform obj)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Dto.ItopPlatform obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.ItopPlatform obj)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Dto.ItopPlatform obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public IList<Dto.IP_Contract> GetProductionContracts()
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = string.Format(StaticQueries.itop_platform_get_contracts, base.iTopPlatformSchema);

                using (System.Data.IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.IP_Contract>(reader);
                }
            }
        }

        public Dto.IP_Contract GetProductionContractById(int id)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = string.Format(StaticQueries.itop_platform_get_contractbyid, base.iTopPlatformSchema, id);

                using (System.Data.IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.IP_Contract>(reader).FirstOrDefault();
                }
            }
        }

        public IList<Dto.IP_Contract> GetProductionContractsByLogin(string userAlias)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = string.Format(StaticQueries.itop_platform_get_userbylogin, base.iTopPlatformSchema, userAlias);

                using (System.Data.IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.IP_Contract>(reader);
                }
            }
        }

        public IList<Dto.IP_Tickets> GetTicketsByContractId(int contractId, DateTime contractStart, DateTime contractEnd)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;

                string concadenatedExcludedCategories = new Data.DFEi_ExcludedCategories().GetConcadenatedExcludedCategories();
                concadenatedExcludedCategories = (string.IsNullOrEmpty(concadenatedExcludedCategories) ? "-1" : concadenatedExcludedCategories);

                string startDate = string.Format("{0:yyyyMMdd}", contractStart);
                string endDate = string.Format("{0:yyyyMMdd}", contractEnd);
                cmd.CommandText = string.Format(StaticQueries.itop_platform_get_ticketsbycontractid, base.iTopPlatformSchema, contractId, concadenatedExcludedCategories, startDate, endDate);

                using (System.Data.IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.IP_Tickets>(reader);
                }
            }
        }

        public Dto.IP_Tickets GetTicketById(int ticketId)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = string.Format(StaticQueries.itop_platform_get_ticketbyid, base.iTopPlatformSchema, ticketId);

                using (System.Data.IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.IP_Tickets>(reader).FirstOrDefault();
                }
            }
        }
    }
}
