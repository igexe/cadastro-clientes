using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadastro_clientes.Models;
using cadastro_clientes.repositorio;

namespace cadastro_clientes.Controllers;

[Route("[controller]")]
public class UsuarioController:Controller{

    private Repositorio<UsuarioModel> _usuarioRepo;
    public UsuarioController(){
        _usuarioRepo=new Repositorio<UsuarioModel>();
    }

    public IActionResult Login(){
        return View();
    }
}