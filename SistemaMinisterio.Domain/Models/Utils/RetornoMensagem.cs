using System;
using System.Collections.Generic;
using System.Text;
using SistemaMinisterio.Domain.Models.Enuns;

namespace SistemaMinisterio.Domain.Models.Utils
{
    public class RetornoMensagem
    {
        public RetornoMensagem(string mensagem, Tipos tipo)
        {
            Mensagem = mensagem;
            Tipo = tipo;
        }

        public string Mensagem { get; set; }
        public Tipos Tipo { get; set; }
    }
}
