using Slayer.DAL;
using Slayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slayer.BLL
{
    public class FilmeBLL
    {
        //objeto global
        FilmeDTO filmDTO = new FilmeDTO();
        FilmeDAL filmDAL = new FilmeDAL();

        //CRUD
        //Create
        public void CreateFilmBLL(FilmeDTO film)
        {
            filmDAL.CreateFilm(film);
        }

        //Read
        public List<FilmeDTO> GetFilmBLL()
        {
            return filmDAL.GetFilm();
        }

        //Update
        public void UpdateFilmBLL(FilmeDTO film)
        {
            filmDAL.UpdateFilm(film);
        }

        //Delete
        public void DeleteFilmBLL(int idFilme)
        {
            filmDAL.DeleteFilm(idFilme);
        }

        //SearchById
        public FilmeDTO SearchFilmIdBLL(int idFilme)
        {
            return filmDAL.SearchFilmId(idFilme);
        }

        //SearchByName
        public FilmeDTO SearchFilmTitleBLL(string nomeFilme)
        {
            return filmDAL.SearchFilmTitle(nomeFilme);
        }

        //loadDDLClassification
        public List<ClassificacaoDTO> LoadDDLClassificationBLL()
        {
            return filmDAL.LoadDDLClassification();
        }

        //loadDDLGenre
        public List<GeneroDTO> LoadDDLGenreBLL()
        {
            return filmDAL.LoadDDLGenre();
        }

        //FilterByGenre
        public List<FilmeDTO> FilterByGenreBLL(string genero)
        {
            return filmDAL.FilterByGenre(genero);
        }
    }
}
