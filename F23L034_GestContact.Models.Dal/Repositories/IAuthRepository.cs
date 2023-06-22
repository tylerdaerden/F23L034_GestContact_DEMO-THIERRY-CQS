using F23L034_GestContact.Models.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F23L034_GestContact.Models.Dal.Repositories
{
    public interface IAuthRepository
    {
        public void Register(Utilisateur utilisateur);
        public Utilisateur? Login(string email, string passwd);
    }
}
