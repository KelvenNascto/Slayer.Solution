using Slayer.DAL;
using Slayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slayer.BLL
{
    public class UsuarioBLL
    {
        //objeto global
        UsuarioDTO userDTO = new UsuarioDTO();
        UsuarioDAL userDAL = new UsuarioDAL();

        //autenticacao
        public UsuarioDTO AuthenticateUserBLL(string user, string password)
        {
            return userDAL.AuthenticateUser(user, password);
        }

        //CRUD
        //Create
        public void CreateUserBLL(UsuarioDTO user)
        {
            userDAL.CreateUser(user);
        }

        //Read
        public List<UsuarioDTO> GetUserBLL()
        {
            return userDAL.GetUser();
        }

        //Update
        public void UpdateUserBLL(UsuarioDTO user)
        {
            userDAL.UpdateUser(user);
        }

        //Delete
        public void DeleteUserBLL(int idUser)
        {
            userDAL.DeleteUser(idUser);
        }

        //SearchById
        public UsuarioDTO SearchBLL(int idUser)
        {
            return userDAL.Search(idUser);
        }

        //SearchByName
        public UsuarioDTO SearchBLL(string nomeUser)
        {
            return userDAL.Search(nomeUser);
        }

        //loadDDL
        public List<TipoUsuarioDTO> GetTypeUserBLL()
        {
            return userDAL.GetTypeUser();
        }

    }
}
