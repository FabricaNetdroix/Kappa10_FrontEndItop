using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BFEi_BagHours
    {
        public bool CreateBagHours(Dto.FEi_BagHours obj)
        {
            return new Data.DFEi_BagHours().Insert(obj);
        }

        public IList<Dto.FEi_BagHours> GetAllBagHours()
        {
            return new Data.DFEi_BagHours().RetrieveFiltered(new Dto.FEi_BagHours() { is_visible = true });
        }

        public Dto.FEi_BagHours GetBagHoursById(int idBagHours)
        {
            return new Data.DFEi_BagHours().RetrieveFiltered(new Dto.FEi_BagHours() { id = idBagHours }).FirstOrDefault();
        }

        public IList<Dto.FEi_BagHours> GetBagActiveHours()
        {
            return new Data.DFEi_BagHours().RetrieveFiltered(new Dto.FEi_BagHours() { status = (short)Dto.BagHoursStatus.Active, is_visible = true });
        }

        public bool DeleteBagHours(Dto.FEi_BagHours obj)
        {
            return new Data.DFEi_BagHours().Delete(obj);
        }

        public Dto.FEi_BagHours GetBagHoursByContractId(int idContract)
        {
            return new Data.DFEi_BagHours().RetrieveFiltered(new Dto.FEi_BagHours() { contract_id = idContract }).FirstOrDefault();
        }

        public bool UpdateBagHours(Dto.FEi_BagHours obj)
        {
            return new Data.DFEi_BagHours().Update(obj);
        }
    }
}
