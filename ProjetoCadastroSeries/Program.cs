using ProjetoCadastroSeries.Classes;
using ProjetoCadastroSeries.Enums;
using ProjetoCadastroSeries.Interfaces;
using System.Text.Json;


namespace DIO.Series
{
    class Program
    {
        public static RepositorioSeries repositorio = RepositorioSeries.GetInstance();
        public static void Main()
        {
            string descricao_mr_robot = "Mr. Robot é uma série de televisão norte-americana criada por Sam Esmail. \n\tÉ protagonizada por Rami Malek como Elliot Alderson, \n\tum engenheiro de cibersegurança e hacker que sofre de transtorno de ansiedade social e depressão clínica";
            var serie = new Serie("Mr Robot", new List<Genero> { Genero.Thriller_tecnologico, Genero.Thriller_psicologico, Genero.Drama }, descricao_mr_robot, 2015);

            

            for (int i = 0; i < 5; i++)
            {
                repositorio.Cadastrar(SerieGenerator.GeraSerie());
            }

            repositorio.Atualiza(2, serie);

            var x = repositorio.ListarPorId(2);

            repositorio.Exclui(1);
            var y = repositorio.ListarTodos();

            // Aproveitando o código dado de exemplo no desafio especialmente para fazer o menu (com poucas modificações):
            // Maior autor´do ódigo a baixxo: elizarp
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
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

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }


        static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui((uint) indiceSerie);
        }

        static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.ListarPorId((uint) indiceSerie);

            Console.WriteLine(serie);
        }

        static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            int cont = 0;
            var listaGeneros = new List<Genero>();
            while (true)
            {
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima ou [-1] para seguir para o próximo item de cadastro da série: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                if (entradaGenero == -1) break;

                listaGeneros.Add((Genero)entradaGenero);
                
                ++cont;
                if (cont >= 4)
                {
                    Console.WriteLine("Apenas 4 gêneros podem ser escolhidos para a série. Vamos prosseguir:");
                    break;
                }

            }

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(generos: listaGeneros,
                                        titulo: entradaTitulo,
                                        anoTransmissaoOriginal: (ushort) entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza((uint) indiceSerie, atualizaSerie);
        }
        static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.Excluido;

                Console.WriteLine("#ID {0}: - {1} {2}", serie.Id, serie.Titulo, (excluido ? "*Excluído*" : ""));
            }
        }

        static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            int cont = 0;
            var listaGeneros = new List<Genero>();
            while (true)
            {
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima ou [-1] para seguir para o próximo item de cadastro da série: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                if (entradaGenero == -1) break;

                listaGeneros.Add((Genero) entradaGenero);

                ++cont;
                if (cont >= 4)
                {
                    Console.WriteLine("Apenas 4 gêneros podem ser escolhidos para a série. Vamos prosseguir:");
                }

            }

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(entradaTitulo, listaGeneros, entradaDescricao, (ushort)entradaAno);

            repositorio.Cadastrar(novaSerie);
        }


        static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
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
