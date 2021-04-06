using System;

namespace estruturaPrograma
{
  class Program
  {
    static void Main(string[] args)
    {
      var S = new Pilha();
      S.Empilha(3);
      S.Empilha(5);
      S.Empilha(9);
      Console.WriteLine(S.Desempilha());
      Console.WriteLine(S.Desempilha());
      Console.WriteLine(S.Desempilha());
      Console.WriteLine(S.Desempilha());
    }
  }
}
