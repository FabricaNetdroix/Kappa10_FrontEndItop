using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BFEi_Users
    {
        public IList<Dto.FEi_User> GetAllUsers()
        {
            return new Data.DFEi_Users().RetrieveFiltered(new Dto.FEi_User());
        }

        public Dto.FEi_User GetUserById(int idUser)
        {
            return new Data.DFEi_Users().RetrieveFiltered(new Dto.FEi_User() { id = idUser }).FirstOrDefault();
        }

        public Dto.FEi_User GetUserByCredentials(string userAlias, string userPassword, Dto.UserTypes userType)
        {
            string encryptedPassword = Tier.Transverse.Crypto.GetMd5Hash(userPassword);
            return new Data.DFEi_Users().RetrieveFiltered(new Dto.FEi_User() { alias = userAlias, password = encryptedPassword, role = (byte)userType }).FirstOrDefault();
        }

        public bool CreateUser(Dto.FEi_User obj)
        {
            return new Data.DFEi_Users().Insert(obj);
        }

        public IList<Dto.FEi_User> GetFiltered(Dto.FEi_User obj)
        {
            return new Data.DFEi_Users().RetrieveFiltered(obj);
        }

        public bool UpdateUser(Dto.FEi_User obj)
        {
            return new Data.DFEi_Users().Update(obj);
        }

        public bool DeleteUser(Dto.FEi_User obj)
        {
            return new Data.DFEi_Users().Delete(obj);
        }
    }
}
