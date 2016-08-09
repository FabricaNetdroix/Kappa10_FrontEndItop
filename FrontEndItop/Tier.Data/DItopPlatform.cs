﻿using System;
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
                cmd.CommandText = StaticQueries.itop_platform_get_contracts.Replace("[<SCHEMA>]", base.iTopPlatformSchema);

                using (System.Data.IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return new List<Dto.IP_Contract>().FromDataReader<Dto.IP_Contract>(reader).ToList();
                }
            }
        }
    }
}
