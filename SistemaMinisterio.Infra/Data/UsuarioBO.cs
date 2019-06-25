using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SistemaMinisterio.Domain.Interfaces;
using SistemaMinisterio.Domain.Models.Entities;

namespace SistemaMinisterio.Infra.Data
{
    public class UsuarioBO : IUsuarioBO
    {
        public readonly string _connectionString;

        public UsuarioBO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int CreateLogin(Usuario usuario)
        {
            var result = 0;
            try
            {
                string inserirUsuario = @"INSERT INTO Usuarios (Nome, IDPerfilUsuario, IDPerfilMembro, Senha, Email, UserName, Sexo)
                                                      Value (@Nome, @IDPerfilUsuario, @IDPerfilMembro, @Senha, @Email, @UserName, @Sexo)";
                
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    
                    var sqlCommand = new SqlCommand(inserirUsuario, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@Nome", SqlDbType.VarChar).Value = usuario.Nome;
                    sqlCommand.Parameters.Add("@IDPerfilUsuario", SqlDbType.Int).Value = usuario.IdPerfilUsuario;
                    sqlCommand.Parameters.Add("@IDPerfilMembro", SqlDbType.Int).Value = usuario.IdPerfilMembro;
                    sqlCommand.Parameters.Add("@Senha", SqlDbType.VarChar).Value = usuario.Senha;
                    sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = usuario.Email;
                    sqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = usuario.UserName;
                    sqlCommand.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = usuario.Sexo;

                    sqlConnection.Open();

                    result = sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }

                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Usuario GetUsuario(int id)
        {
            try
            {
                string buscarUsuario = @"SELECT * FROM Usuarios WHERE IDUsuario = @id";
                Usuario usuario = null;


                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using(var sqlCommand = new SqlCommand(buscarUsuario, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            usuario = new Usuario(
                                id: Convert.ToInt32(reader["IDUsuario"]),
                                nome: reader["Nome"].ToString(),
                                userName: reader["UserName"].ToString(),
                                sobrenome: reader["Sobrenome"].ToString(),
                                idPerfilUsuario: Convert.ToInt32(reader["IDPerfilUsuario"]),
                                senha: reader["Senha"].ToString(),
                                email: reader["Email"].ToString(),
                                sexo: reader["Sexo"].ToString(),
                                idade: Convert.ToInt32(reader["Idade"])

                                );
                        }
                    }
                }

                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Usuario GetUsuario(string userName)
        {
            try
            {
                string buscarUsuario = @"SELECT * FROM Usuarios WHERE UserName = @userName";

                Usuario usuario = null;

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (var sqlCommand = new SqlCommand(buscarUsuario, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@userName", System.Data.SqlDbType.VarChar, 50).Value = userName;

                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            usuario = new Usuario(
                                id: Convert.ToInt32(reader["IDUsuario"]),
                                nome: reader["Nome"].ToString(),
                                userName: reader["UserName"].ToString(),
                                sobrenome: reader["Sobrenome"].ToString(),
                                idPerfilUsuario: Convert.ToInt32(reader["IDPerfilUsuario"]),
                                senha: reader["Senha"].ToString(),
                                email: reader["Email"].ToString(),
                                sexo: reader["Sexo"].ToString(),
                                idade: Convert.ToInt32(reader["Idade"])

                                );
                        }
                    }
                }

                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void RecoverSenha(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
