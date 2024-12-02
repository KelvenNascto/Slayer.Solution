using Slayer.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Slayer.DAL
{
    public class FilmeDAL : Conexao
    {
        string msg = "Essa foi mais uma cagada que eu cometi no meu código !!";

        //Create
        public void CreateFilm(FilmeDTO film)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Filme (TituloFilme,ProdutoraFilme,UrlFilme,GeneroId,ClassificacaoId) VALUES (@TituloFilme,@ProdutoraFilme,@UrlFilme,@GeneroId,@ClassificacaoId)", conn); 
                cmd.Parameters.AddWithValue("@TituloFilme", film.TituloFilme);
                cmd.Parameters.AddWithValue("@ProdutoraFilme", film.ProdutoraFilme);
                cmd.Parameters.AddWithValue("@UrlFilme", film.UrlFilme);
                cmd.Parameters.AddWithValue("@GeneroId", film.GeneroId);
                cmd.Parameters.AddWithValue("@ClassificacaoId", film.ClassificacaoId);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //Read
        public List<FilmeDTO> GetFilm()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdFilme, TituloFilme, ProdutoraFilme, UrlFilme,DescricaoGenero, DescricaoClassificacao From Filme INNER JOIN Genero ON GeneroId = IdGenero INNER JOIN Classificacao ON  ClassificacaoId = IdClassificacao;", conn);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> listFilm = new List<FilmeDTO>();//ponteiro
                while (dr.Read())
                {
                    FilmeDTO film = new FilmeDTO();
                    film.IdFilme = Convert.ToInt32(dr["IdFilme"]);
                    film.TituloFilme = dr["TituloFilme"].ToString();
                    film.ProdutoraFilme = dr["ProdutoraFilme"].ToString();
                    film.UrlFilme = dr["UrlFilme"].ToString();
                    film.ClassificacaoId = dr["DescricaoClassificacao"].ToString();
                    film.GeneroId = dr["DescricaoGenero"].ToString();
                    listFilm.Add(film);
                }
                return listFilm;

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //Update
        public void UpdateFilm(FilmeDTO film)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Filme SET TituloFilme = @TituloFilme,ProdutoraFilme = @ProdutoraFilme,UrlFilme = @UrlFilme, GeneroId = @GeneroId,ClassificacaoId = @ClassificacaoId WHERE IdFilme = @IdFilme;", conn);
                cmd.Parameters.AddWithValue("@TituloFilme", film.TituloFilme);
                cmd.Parameters.AddWithValue("@ProdutoraFilme", film.ProdutoraFilme);
                cmd.Parameters.AddWithValue("@UrlFilme", film.UrlFilme);
                cmd.Parameters.AddWithValue("@GeneroId", film.GeneroId);
                cmd.Parameters.AddWithValue("@ClassificacaoId", film.ClassificacaoId);
                //passando o id para condicao WHERE do comando sql
                cmd.Parameters.AddWithValue("@IdFilme", film.IdFilme);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }
        }

        //Delete
        public void DeleteFilm(int idFilme)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Filme WHERE IdFilme = @IdFilme;", conn);
                cmd.Parameters.AddWithValue("@IdFilme", idFilme);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }
        }

        //SearchById
        public FilmeDTO SearchFilmId(int idFilme)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Filme WHERE IdFilme = @IdFilme;", conn);
                cmd.Parameters.AddWithValue("@IdFilme", idFilme);
                dr = cmd.ExecuteReader();
                FilmeDTO film = null;//ponteiro
                if (dr.Read())
                {
                    film = new FilmeDTO();
                    film.IdFilme = Convert.ToInt32(dr["IdFilme"]);
                    film.TituloFilme = dr["TituloFilme"].ToString();
                    film.ProdutoraFilme = dr["ProdutoraFilme"].ToString();
                    film.UrlFilme = dr["UrlFilme"].ToString();
                    film.GeneroId = dr["GeneroId"].ToString();
                    film.ClassificacaoId = dr["ClassificacaoId"].ToString();
                }
                return film;

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //SearchByTitulo
        public FilmeDTO SearchFilmTitle(string nomeFilme)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Filme WHERE TituloFilme = @TituloFilme;", conn);
                cmd.Parameters.AddWithValue("@TituloFilme", nomeFilme);
                dr = cmd.ExecuteReader();
                FilmeDTO film = null;//ponteiro
                if (dr.Read())
                {
                    film = new FilmeDTO();
                    film.IdFilme = Convert.ToInt32(dr["IdFilme"]);
                    film.TituloFilme = dr["TituloFilme"].ToString();
                    film.ProdutoraFilme = dr["ProdutoraFilme"].ToString();
                    film.UrlFilme = dr["UrlFilme"].ToString();
                    film.GeneroId = dr["GeneroId"].ToString();
                    film.ClassificacaoId = dr["ClassificacaoId"].ToString();
                }
                return film;

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //LoadDDLClassificacao
        public List<ClassificacaoDTO> LoadDDLClassification()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Classificacao;", conn);
                dr = cmd.ExecuteReader();
                List<ClassificacaoDTO> listFilm = new List<ClassificacaoDTO>();//ponteiro
                while (dr.Read())
                {
                    ClassificacaoDTO filmC = new ClassificacaoDTO();
                    filmC.IdClassificacao = Convert.ToInt32(dr["IdClassificacao"]);
                    filmC.DescricaoClassificacao = dr["DescricaoClassificacao"].ToString();

                    listFilm.Add(filmC);
                }
                return listFilm;

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //LoadDDLGenero
        public List<GeneroDTO> LoadDDLGenre()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Genero;", conn);
                dr = cmd.ExecuteReader();
                List<GeneroDTO> listFilm = new List<GeneroDTO>();//ponteiro
                while (dr.Read())
                {
                    GeneroDTO filmG = new GeneroDTO();
                    filmG.IdGenero = Convert.ToInt32(dr["IdGenero"]);
                    filmG.DescricaoGenero = dr["DescricaoGenero"].ToString();

                    listFilm.Add(filmG);
                }
                return listFilm;

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }

        //FilterByGenero
        public List<FilmeDTO> FilterByGenre(string genero)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdFilme, TituloFilme, ProdutoraFilme, UrlFilme, DescricaoGenero, DescricaoClassificacao FROM Filme INNER JOIN Genero ON GeneroId = IdGenero INNER JOIN Classificacao ON ClassificacaoId = IdClassificacao WHERE DescricaoGenero = @DescricaoGenero;;", conn);
                cmd.Parameters.AddWithValue("@DescricaoGenero", genero);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> listFilm = new List<FilmeDTO>();//lista vazia
                while (dr.Read())
                {
                    FilmeDTO film = new FilmeDTO();
                    film.IdFilme = Convert.ToInt32(dr["IdFilme"]);
                    film.TituloFilme = dr["TituloFilme"].ToString();
                    film.ProdutoraFilme = dr["ProdutoraFilme"].ToString();
                    film.UrlFilme = dr["UrlFilme"].ToString();
                    film.ClassificacaoId = dr["DescricaoClassificacao"].ToString();
                    film.GeneroId = dr["DescricaoGenero"].ToString();
                    listFilm.Add(film);
                }
                return listFilm;

            }
            catch (Exception ex)
            {
                throw new Exception($"{msg} - {ex.Message}");
            }
            finally
            {
                Desconectar();
            }

        }
    }
}
