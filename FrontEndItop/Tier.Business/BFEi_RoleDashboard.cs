using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BFEi_RoleDashboard
    {
        public Dto.FEi_RoleDashboard GetRoleDashboard(int role)
        {
            return new Data.DFEi_RoleDashboard().GetRoleDashboard(role);
        }
    }
}
