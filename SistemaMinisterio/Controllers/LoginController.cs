﻿using Microsoft.AspNetCore.Mvc;
using SistemaMinisterio.Domain.Models.Entities;
using SistemaMinisterio.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using SistemaMinisterio.Domain.Models.Utils;

namespace SistemaMinisterio.Controllers
{
    public class LoginController : Controller
    {
        private IUsuarioBO _usuarioBO;
        private IConfiguration _connectionString;
        
        public LoginController(IConfiguration configuration, IUsuarioBO usuarioBO)
        {
            _usuarioBO = usuarioBO;
            _connectionString = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            if (user != null)
            {
                var v = _usuarioBO.GetUsuario(user.Nome);
                if (v.Nome == user.Nome.ToLower() && v.Senha == user.Senha)
                {
                    HttpContext.Session.SetString("usuarioLogadoID", v.Id.ToString());
                    HttpContext.Session.SetString("nomeUsuarioLogado", v.Nome);
                    return RedirectToAction("Index", "Home");
                }
                else
                    return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Mensagem = new RetornoMensagem(
                    mensagem: "Usuario e Senha em branco!",
                    tipo: Domain.Models.Enuns.Tipos.Senha
                    );
                return RedirectToAction("Index", "Login");
            }
                
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove("usuarioLogadoID");
            HttpContext.Session.Remove("nomeUsuarioLogado");

            return RedirectToAction("Index");
        }
    }
}