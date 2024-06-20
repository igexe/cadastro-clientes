using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cadastro_clientes.Models;
using cadastro_clientes.repositorio;
using System.Text.Json;

namespace cadastro_clientes.Controllers;

[Route("[controller]")]
public class ClienteController:Controller{
    
    private Repositorio<ClienteModel> _clienteRepo;
    public ClienteController(){
        _clienteRepo=new Repositorio<ClienteModel>();
    }

    [HttpGet("Mostra")]
    public IActionResult Mostra(){
        var cliente=_clienteRepo.Listar();
        return View(cliente);
    }

    [HttpGet("Cadastro")]
    public IActionResult Cadastro(){
        return View();
    }

    [HttpPost("Cadastro")]
    public IActionResult Cadastro(ClienteModel clienteModel){
        if(ModelState.IsValid){
            _clienteRepo.Adicionar(clienteModel);
            return RedirectToAction("Mostra","Cliente");
        }
        return View(clienteModel);
    }

    [HttpGet("Modifica/{id}")]
    public IActionResult Modifica(int id){
        var cliente=_clienteRepo.Buscar(id);
        if(cliente==null){
            return NotFound();
        }
        return View(cliente);
    }

    [HttpPost("Modifica/{id}")]
    public IActionResult Modifica(ClienteModel clienteModel){
        if(ModelState.IsValid){
            _clienteRepo.Remover(clienteModel.Id);
            _clienteRepo.Adicionar(clienteModel);
            return RedirectToAction("Mostra","Cliente");
        }
        return View(clienteModel);
    }

    public IActionResult Apaga(int id){
        var cliente=_clienteRepo.Buscar(id);
        if(cliente==null){
            return RedirectToAction("Mostra","Cliente");
        }
        _clienteRepo.Remover(id);
        return RedirectToAction("Mostra","Cliente");
    }

    [HttpGet("ExportarCliente")]
        public IActionResult ExportarCliente(int id)
        {
            var cliente = _clienteRepo.Buscar(id);
            if (cliente == null)
            {
                return NotFound();
            }

            var json = JsonSerializer.Serialize(cliente, new JsonSerializerOptions{WriteIndented=true});
            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", $"cliente_{cliente.Id}.json");
        }
}