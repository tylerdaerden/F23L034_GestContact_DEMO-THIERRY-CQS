using F23L034_GestContact.Models.Dal.DataMappers;
using F23L034_GestContact.Models.Dal.Entities;
using F23L034_GestContact.Models.Dal.Repositories;
using System.Data;
using System.Data.SqlClient;
using Tools.Database;

namespace F23L034_GestContact.Models.Dal.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly IDbConnection _dbConnection;

        public AuthService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Utilisateur? Login(string email, string passwd)
        {
            _dbConnection.Open();
            Utilisateur? utilisateur = _dbConnection.ExecuteReader("CSP_Login", dr => dr.ToUtilisateur(), true, new { email, passwd }).SingleOrDefault();
            _dbConnection.Close();
            return utilisateur;
        }

        public void Register(Utilisateur utilisateur)
        {
            _dbConnection.Open();
            _dbConnection.ExecuteNonQuery("CSP_Register", true, new { utilisateur.Nom, utilisateur.Prenom, utilisateur.Email, utilisateur.Passwd });
            _dbConnection.Close();
        }
    }
}
