namespace cadastro_clientes.Models;

public class UsuarioModel:cadastro_clientes.repositorio.Entity{
    public string User{get; set;}
    public string Senha{get; set;}
    
    public UsuarioModel(){
        User=string.Empty;
        Senha=string.Empty;
    }
}