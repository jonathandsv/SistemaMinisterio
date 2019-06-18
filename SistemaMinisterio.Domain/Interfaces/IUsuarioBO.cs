using SistemaMinisterio.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMinisterio.Domain.Interfaces
{
    public interface IUsuarioBO
    {
        Usuario GetUsuario(int id);
        Usuario GetUsuario(string name);
    }
}
