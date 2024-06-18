namespace cadastro_clientes.Models;

public class ClienteModel:cadastro_clientes.repositorio.Entity{
    public int CPF_CNPJ {get;set;}
    public int InscricaoEstadual {get;set;}
    public string Nome {get;set;}
    public string NomeFantasia {get;set;}
    public string Endereco {get;set;}
    public int NumeroEnd {get;set;}
    public string Bairro {get;set;}
    public string Cidade {get;set;}
    public string Estado {get;set;}
    public DateTime Nascimento {get;set;}

    public ClienteModel(){
        CPF_CNPJ=0;
        InscricaoEstadual=0;
        Nome=string.Empty;
        NomeFantasia=string.Empty;
        Endereco=string.Empty;
        NumeroEnd=0;
        Bairro=string.Empty;
        Cidade=string.Empty;
        Estado=string.Empty;
        Nascimento=DateTime.MinValue;
    }
}