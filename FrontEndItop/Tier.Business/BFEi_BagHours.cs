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
            return new Data.DFEi_BagHours().RetrieveFiltered(new Dto.FEi_BagHours());
        }

        public Dto.FEi_BagHours GetBagHoursById(int idBagHours)
        {
            return new Data.DFEi_BagHours().RetrieveFiltered(new Dto.FEi_BagHours() { id = idBagHours }).FirstOrDefault();
        }

        public bool DeleteBagHours(Dto.FEi_BagHours obj)
        {
            return new Data.DFEi_BagHours().Delete(obj);
        }
    }
}
