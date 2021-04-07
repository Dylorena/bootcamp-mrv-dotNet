using System;

namespace Series
{
  class Program
  {
    static serieRepositorio repositorio = new serieRepositorio();
    static void Main(string[] args)
    {
      string opcaoUser = ObterOpcaoUsuario();

      while (opcaoUser != "X")
      {
        switch (opcaoUser)
        {
          case "1":
            ListarSerie();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUser = ObterOpcaoUsuario();
      }
    }

    private static void VisualizarSerie()
    {
      Console.WriteLine("Digite o Id para ser detalhado:");
      int idDigitado = int.Parse(Console.ReadLine());

      var listaDetalhar = repositorio.RetornaPorId(idDigitado);
      Console.WriteLine(listaDetalhar);
    }

    private static void ExcluirSerie()
    {
      Console.WriteLine("Digite o Id para ser excluído:");
      int idDigitado = int.Parse(Console.ReadLine());
      repositorio.Excluir(idDigitado);
    }

    private static void AtualizarSerie()
    {
      Console.WriteLine("Qual ID você deseja atualizar?");
      int idDigitado = int.Parse(Console.ReadLine());

      foreach (int indice in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", indice, Enum.GetName(typeof(Genero), indice));
      }

      Console.WriteLine("Digite o gênero entre as opções acima:");
      int entradaGenero = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite o título da série:");
      string entradaTitulo = Console.ReadLine();
      Console.WriteLine("Digite o Ano de início da série:");
      int entradaAno = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite a descrição da série:");
      string entradaDescricao = Console.ReadLine();

      Series novaSerie = new Series(
        id: idDigitado,
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        descricao: entradaDescricao,
        ano: entradaAno
      );

      repositorio.Atualiza(idDigitado, novaSerie);
    }

    private static void InserirSerie()
    {
      foreach (int indice in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", indice, Enum.GetName(typeof(Genero), indice));
      }

      Console.WriteLine("Digite o gênero entre as opções acima:");
      int entradaGenero = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite o título da série:");
      string entradaTitulo = Console.ReadLine();
      Console.WriteLine("Digite o Ano de início da série:");
      int entradaAno = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite a descrição da série:");
      string entradaDescricao = Console.ReadLine();

      Series novaSerie = new Series(
        id: repositorio.ProximoId(),
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        descricao: entradaDescricao,
        ano: entradaAno
      );

      repositorio.Insere(novaSerie);
    }

    private static void ListarSerie()
    {
      Console.WriteLine("Listar Séries");

      var lista = repositorio.Lista();
      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada");
        return;
      }
      foreach (var serie in lista)
      {
        Console.WriteLine("#ID {0} - {1}", serie.retornaId(), serie.retornaTitulo());
      }
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar séries");
      Console.WriteLine("2- Inserir nova série");
      Console.WriteLine("3- Atualizar série");
      Console.WriteLine("4- Excluir série");
      Console.WriteLine("5- Visualizar série");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
