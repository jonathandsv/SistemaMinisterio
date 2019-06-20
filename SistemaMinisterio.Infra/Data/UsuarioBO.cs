using System;
using System.Collections.Generic;
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
    }
}
