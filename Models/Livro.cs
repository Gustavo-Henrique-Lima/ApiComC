namespace APIC.Models
{
    public class Livro
    {
        public int id{get;set;}
        public string? name{get;set;}
        public int qtdPaginas{get;set;}
        public string? editora{get;set;}
        public string? genero{get;set;}
        public double valor{get;set;}
        public bool disponivel{get;set;}
    }
}