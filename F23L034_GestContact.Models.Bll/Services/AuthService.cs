using F23L034_GestContact.Models.Bll.Entities;
using F23L034_GestContact.Models.Bll.Repositories;

using IAuthDalRepository = F23L034_GestContact.Models.Dal.Repositories.IAuthRepository;
using AuthDalService = F23L034_GestContact.Models.Dal.Services.AuthService;
using F23L034_GestContact.Models.Bll.DataMappers;

namespace F23L034_GestContact.Models.Bll.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly IAuthDalRepository _authDalRepository;
            
        public AuthService(IAuthDalRepository authDalRepository)
        {
            _authDalRepository = authDalRepository;
        }

        public Utilisateur? Login(string email, string passwd)
        {
            return _authDalRepository.Login(email, passwd)?.ToBll();
        }

        public void Register(Utilisateur utilisateur)
        {
            _authDalRepository.Register(utilisateur.ToDal());
        }
    }
}
