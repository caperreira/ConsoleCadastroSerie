using CRUDStreaming.Class;
using System;
using CRUDStreaming.Opcoes;
using System.Linq;

namespace CRUDStreaming
{
  class Program
  {
    // Instanciando o repositorio/// 
    static StreamingRepository repository = new StreamingRepository();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();


      while (opcaoUsuario.ToUpper() != "X")
      {

        switch (opcaoUsuario)
        {
          case "1":
            ListarSeries();
            //opcaoUsuario = ObterOpcaoUsuario();
            break;

          case "2":
            InserirSerie();
            //opcaoUsuario = ObterOpcaoUsuario();
            break;

          case "3":
            AtualizaSerie();
            //opcaoUsuario = ObterOpcaoUsuario();
            break;

          case "4":
            ExcluirSerie();
            //opcaoUsuario = ObterOpcaoUsuario();
            break;

          case "5":
            VisualizarSerie();
            //opcaoUsuario = ObterOpcaoUsuario();
            break;

          case "C":
            Console.Clear();
            break;

          default:
            Console.WriteLine("O valor digitado não corresponde a uma opção valida.");
            break;
        }

        opcaoUsuario = ObterOpcaoUsuario();

      }

      Console.WriteLine();
      Console.WriteLine("Obrigado por utilizar os nossos serviços!!");

    }

    public static void ListarSeries()
    {
      Console.WriteLine("Listar séries...");

      var lista = repository.Lista();

      if (lista.Count == 0)
      {

        Console.WriteLine("Nenhuma série cadastrado.");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();

        Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));

      }
    }


    public static void InserirSerie()
    {

      Console.WriteLine("Inserir nova série.");

      //Enum.Genero generos = new Enum.Genero();
      foreach (var i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} {1}", (int)i, i);
      }

      Console.WriteLine("\nDigite o Genero conforme as opçãoes a cima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("\nDigite o titulo da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("\nDigite o ano da série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("\nDigite a descrição: ");
      string entradaDescricao = Console.ReadLine();

      Streaming newStreaming = new Streaming(
          idMovie: repository.ProximoId(),
          genero: (Genero)entradaGenero,
          titulo: entradaTitulo,
          ano: entradaAno,
          descricao: entradaDescricao);




      repository.Insere(newStreaming);

    }

    public static void AtualizaSerie()
    {

      Console.WriteLine("Digite o Id da série: ");
      int indiceStreaming = int.Parse(Console.ReadLine());

      //Enum.Genero generos = new Enum.Genero();
      foreach (var i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} {1}", (int)i, i);
      }

      Console.WriteLine("Digite o Genero conforme as opçãoes a cima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o titulo da série: ");
      string entradaTitulo = Console.ReadLine();

      Console.WriteLine("Digite o ano da série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a descrição: ");
      string entradaDescricao = Console.ReadLine();

      Streaming updateStreaming = new Streaming(
          idMovie: indiceStreaming,
          genero: (Genero)entradaGenero,
          titulo: entradaTitulo,
          ano: entradaAno,
          descricao: entradaDescricao);




      repository.Atualiza(indiceStreaming, updateStreaming);
    }

    public static void ExcluirSerie()
    {
      Console.WriteLine("Digite o Id da Série: ");
      int indiceStreaming = int.Parse(Console.ReadLine());

      repository.Exclui(indiceStreaming);
    }

    public static void VisualizarSerie()
    {
      Console.WriteLine("Digite o id da série? ");
      int indiceStreaming = int.Parse(Console.ReadLine());

      var lista = repository.Lista();
      if (lista.Count == 0)
      {
        Console.WriteLine(" Série não encontrada.");
        Console.WriteLine("\n Nenhuma série cadastrado.");
        return;
      }
      else
      {

        var streaming = repository.RetornaPorId(indiceStreaming);
        Console.WriteLine(streaming);
      }

    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Stream CRUD - a melhor plataformas de Filmes!");
      Console.WriteLine("Informe a opção desejada");
      Console.WriteLine();


      Console.WriteLine("1 - Listar séries");
      Console.WriteLine("2 - Inserir nova série");
      Console.WriteLine("3 - Atualiza série");
      Console.WriteLine("4 - Inativar série");
      Console.WriteLine("5 - Visualizar série");
      Console.WriteLine("C - Limpar Tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();


      string opcaoUsuario = Console.ReadLine();
      return opcaoUsuario;



    }
  }
}
