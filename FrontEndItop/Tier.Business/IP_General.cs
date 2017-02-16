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

        public Dto.IP_Contract GetProductionContractById(int id)
        {
            return new Data.DItopPlatform("iTopPlatformConnectionString").GetProductionContractById(id);
        }

        public IList<Dto.IP_Contract> GetProductionContractsByLogin(string userAlias)
        {
            return new Data.DItopPlatform("iTopPlatformConnectionString").GetProductionContractsByLogin(userAlias);
        }

        public IList<Dto.IP_Tickets> GetTicketsByContractId(int contractId)
        {
            return new Data.DItopPlatform("iTopPlatformConnectionString").GetTicketsByContractId(contractId);
        }

        public Dto.IP_Tickets GetTicketById(int ticketId)
        {
            return new Data.DItopPlatform("iTopPlatformConnectionString").GetTicketById(ticketId);
        }
    }
}
