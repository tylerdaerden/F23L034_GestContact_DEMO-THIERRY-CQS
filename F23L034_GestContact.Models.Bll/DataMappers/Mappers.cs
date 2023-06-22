using F23L034_GestContact.Models.Bll.Entities;
using DalUtilisateur = F23L034_GestContact.Models.Dal.Entities.Utilisateur;

namespace F23L034_GestContact.Models.Bll.DataMappers
{
    internal static class Mappers
    {
        internal static DalUtilisateur ToDal(this Utilisateur utilisateur)
        {
            DalUtilisateur entity = new DalUtilisateur()
            {
                Id = utilisateur.Id,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Email = utilisateur.Email,
                Passwd = utilisateur.Passwd,
            };
            utilisateur.Passwd = null;
            return entity;
        }

        internal static Utilisateur ToBll(this DalUtilisateur utilisateur)
        {
            return new Utilisateur(utilisateur.Id, utilisateur.Nom, utilisateur.Prenom, utilisateur.Email);
        }
    }
}
