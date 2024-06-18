using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace cadastro_clientes.repositorio;

// Modelo de dados base
public class Entity
{
    public int Id { get; set; }    
}

// Classe que simula o banco de dados
public class Repositorio<TModel> where TModel : Entity   
{
    private static string localArquivos = ".";
    private string arquivoRepositorio;

    public Repositorio()
    {
        arquivoRepositorio = GetArquivo<TModel>();
    }

    private static string GetArquivo<TModel>()
    {
       return $"{localArquivos}\\{typeof(TModel).Name}.json";
    }

    // Adiciona um novo objeto ao arquivo JSON
    public void Adicionar(TModel model)
    {
        var models = Listar();
        model.Id = (models.Max(p => (int?)p.Id) ?? 0 )+ 1;
        models.Add(model);
        Salvar(models);
    }

    // Busca um objeto pelo ID
    public TModel Buscar(int id)
    {
        var usuarios = Listar();
        return usuarios.Find(u => u.Id == id);
    }

    // Remove um objeto pelo ID
    public void Remover(int id)
    {
        var models = Listar();
        models.RemoveAll(u => u.Id == id);
        Salvar(models);
    }

    // Lê a lista de objeto do arquivo JSON
    public List<TModel> Listar()
    {       
        if (!File.Exists(arquivoRepositorio))
        {
            return new List<TModel>();
        }

        var json = File.ReadAllText(arquivoRepositorio);
        return JsonSerializer.Deserialize<List<TModel>>(json) ?? new List<TModel>();
    }

    // Salva a lista de objeto no arquivo JSON
    private void Salvar(List<TModel> model)
    {
        var json = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(arquivoRepositorio, json);
    }
}
