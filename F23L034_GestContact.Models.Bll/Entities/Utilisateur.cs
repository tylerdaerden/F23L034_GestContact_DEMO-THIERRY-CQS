using F23L034_GestContact.Models.Dal.Entities;
using DalUtilisateur = F23L034_GestContact.Models.Dal.Entities.Utilisateur;

namespace F23L034_GestContact.Models.Bll.Entities
{
    public class Utilisateur
    {
        public int Id { get; init; }
        public string Nom { get; init; }
        public string Prenom { get; init; }
        public string Email { get; init; }
        public string? Passwd { get; internal set; }
        
        public Utilisateur(string nom, string prenom, string email, string passwd)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Passwd = passwd;
        }

        internal Utilisateur(int id, string nom, string prenom, string email)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
        }
    }
}
