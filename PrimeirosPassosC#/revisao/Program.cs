using System;

namespace revisao
{
  class Program
  {
    static void Main(string[] args)
    {
      Aluno[] alunos = new Aluno[5];
      int indice = 0;
      string opcUser = ObterOpcaoUser();

      while (opcUser.ToUpper() != "X")
      {
        switch (opcUser)
        {
          case "1":
            //   Add aluno
            Aluno xaluno = new Aluno();
            Console.WriteLine("Informe o nome:");
            xaluno.Nome = Console.ReadLine();
            Console.WriteLine("Informe a nota:");
            if (decimal.TryParse(Console.ReadLine(), out decimal Nota))
            {
              xaluno.Nota = Nota;
            }
            else
            {
              throw new ArgumentException("O valor da nota deve ser numérico!");
            }

            alunos[indice] = xaluno;
            indice++;
            break;
          case "2":
            //   Listar Alunos
            foreach (var aluno in alunos)
            {
              if (!string.IsNullOrEmpty(aluno.Nome))
              {
                Console.WriteLine($"Nome: {aluno.Nome} - Nota: {aluno.Nota}");
              }
            }
            break;
          case "3":
            //   Calcular média geral
            decimal notaTotal = 0;
            int totalAlunos = 0;

            for (int i = 0; i < alunos.Length; i++)
            {
              if (!string.IsNullOrEmpty(alunos[i].Nome))
              {
                notaTotal += alunos[i].Nota;
                totalAlunos++;
              }
            }

            decimal media = notaTotal / totalAlunos;
            Conceito xconceito;
            if (media < 2)
            {
              xconceito = Conceito.E;
            }
            else if (media < 4)
            {
              xconceito = Conceito.D;
            }
            else if (media < 6)
            {
              xconceito = Conceito.C;
            }
            else if (media < 8)
            {
              xconceito = Conceito.B;
            }
            else
            {
              xconceito = Conceito.A;
            }

            Console.WriteLine($"A média geral é: {media} - Conceito: {xconceito}");
            Console.WriteLine();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcUser = ObterOpcaoUser();
      }
    }

    private static string ObterOpcaoUser()
    {
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1 - Inserir novo aluno");
      Console.WriteLine("2 - Listar novo aluno");
      Console.WriteLine("3 - Calcular média geral");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcUser = Console.ReadLine();
      return opcUser;
    }
  }
}
