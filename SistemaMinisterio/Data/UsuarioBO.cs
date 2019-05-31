using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using SistemaMinisterio.Models;

namespace SistemaMinisterio.Data
{
    public class UsuarioBO
    {
        private string _connetionstring;

        public UsuarioBO(string connectionString)
        {
            _connetionstring = connectionString;
        }

        public Usuario GetUser(string Nome)
        {
            try
            {
                string select = @"SELECT * FROM Usuario WHERE Nome = @nome";

                using (var sqlConnection = new SqlConnection(_connetionstring))
                {
                    var usuario = sqlConnection.QueryFirstOrDefault<Usuario>(select, new { Nome = Nome });
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
