using SistemaMinisterio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMinisterio.Domain.Models.Entities
{

    public class Usuario : BaseEntity
    {
        public Usuario(int id, string nome, string sobrenome, int idPerfilMembro, int idPerfilUsuario, int senha, string email, string sexo, int idade)
            : base(id)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            IdPerfilMembro = idPerfilMembro;
            IdPerfilUsuario = idPerfilUsuario;
            Senha = senha;
            Email = email;
            Sexo = sexo;
            Idade = idade;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int IdPerfilMembro { get; set; }
        public int IdPerfilUsuario { get; set; }
        public int Senha { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
    }

}
