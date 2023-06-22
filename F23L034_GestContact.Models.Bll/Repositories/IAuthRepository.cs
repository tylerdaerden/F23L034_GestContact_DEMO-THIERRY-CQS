using F23L034_GestContact.Models.Bll.Entities;

namespace F23L034_GestContact.Models.Bll.Repositories
{
    public interface IAuthRepository
    {
        public void Register(Utilisateur utilisateur);
        public Utilisateur? Login(string email, string passwd);
    }
}
