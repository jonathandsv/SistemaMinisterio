using System;
using System.Collections.Generic;
using System.Text;
using SistemaMinisterio.Domain.Interfaces;
using SistemaMinisterio.Domain.Models.Entities;

namespace SistemaMinisterio.Infra.Data
{
    public class UsuarioBO : IUsuarioBO
    {
        public Usuario GetUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuario(string name)
        {
            throw new NotImplementedException();
        }
    }
}
