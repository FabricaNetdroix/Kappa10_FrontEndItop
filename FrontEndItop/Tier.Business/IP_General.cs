using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class IP_General : BusinessParent
    {
        public IList<Dto.IP_Contract> GetProductionContracts()
        {
            return new Data.DItopPlatform("iTopPlatformConnectionString").GetProductionContracts();
        }

        public IList<Dto.IP_Contract> GetProductionContractsByLogin(string userAlias)
        {
            return new Data.DItopPlatform("iTopPlatformConnectionString").GetProductionContractsByLogin(userAlias);
        }
    }
}
