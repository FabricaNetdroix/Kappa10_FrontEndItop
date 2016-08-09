using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BItopPlatform : BusinessParent
    {
        public IList<Dto.IP_Contract> GetProductionContracts()
        {
            return new Data.DItopPlatform("iTopPlatformConnectionString").GetProductionContracts();
        }
    }
}
