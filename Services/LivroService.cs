using APIC.Models;

namespace APIC.Services
{
    public class LivroService
    {
        static List<Livro> livros{get;}
        static int nextId=4;

        static LivroService()
        {
            livros=new List<Livro>
            {
                new Livro
                {
                    id=1,
                    name="A Ascensão De Thanos",
                    qtdPaginas=120,
                    editora="Panini",
                    genero="História em quadrinhos",
                    valor=49.90,
                    disponivel=true
                },
                new Livro
                {
                    id=2,
                    name="Cidade dos ossos (Vol. 1 Os Instrumentos Mortais)",
                    qtdPaginas=462,
                    editora="Galera",
                    genero="Ficção",
                    valor=33.00,
                    disponivel=true
                },
                new Livro
                {
                    id=3,
                    name="O ceticismo da fé: Deus: uma dúvida, uma certeza, uma distorção",
                    qtdPaginas=592,
                    editora="Ágape",
                    genero="Filosofia Religião e Espiritualidade",
                    valor=70.10,
                    disponivel=true
                }
            };
        }
      public static List<Livro> getAll()=>livros;
      public static Livro? get(int id)
      {
        return livros.FirstOrDefault(l => l.id == id);
      }
      public static void add(Livro livro)
      {
         livro.id=nextId++;
         livros.Add(livro);
      }
      public static void remove(int id)
      {
        var livro=get(id);
        if(livro is null)
            return;
        livros.Remove(livro);
      }
      public static void update(Livro livro)
      {
         var index=livros.FindIndex(l=>l.id==livro.id);
         if(index==-1)
             return;
         livros[index]=livro;
       }
       public static List<Livro> filterByValue(double minValue,double maxValue)
       {
            List<Livro> filtrados=livros.FindAll(l=> l.valor>=minValue && l.valor<=maxValue).ToList();
            return filtrados;
       }
       public static List<Livro> filterByWord(string palavra)
       {
            List<Livro> filtrados=livros.FindAll(l=> l.name.ToLower().Contains(palavra.ToLower()));
            return filtrados;
       }
    }    
}