using SistemaMinisterio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMinisterio.Domain.Models.Entities
{

    public class Usuario : BaseEntity
    {
        public Usuario(int id, string nome, string userName, string sobrenome, int idPerfilUsuario, string senha, string email, string sexo, int idade)
            : base(id)
        {
            Nome = nome;
            UserName = userName;
            Sobrenome = sobrenome;
            IdPerfilUsuario = idPerfilUsuario;
            Senha = senha;
            Email = email;
            Sexo = sexo;
            Idade = idade;
        }

        public string Nome { get; private set; }
        public string UserName { get; private set; }
        public string Sobrenome { get; private set; }
        public int IdPerfilMembro { get; private set; }
        public int IdPerfilUsuario { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public string Sexo { get; private set; }
        public int Idade { get; private set; }
    }

}
