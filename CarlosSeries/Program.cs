using CarlosSeries.Classes;
using System;

namespace CarlosSeries
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            MenuPrincipal();


            

            
        }

        private static void MenuPrincipal()
        {
            Console.WriteLine("Deseja acessar filmes ou series? Digite F e S para series.");
            string opcaoUsuario = Console.ReadLine();
            if (opcaoUsuario.ToUpper() == "S")
            {
                OpcoesSeries();
            }
            else if (opcaoUsuario.ToUpper() == "F")
            {
                OpcoesFilmes();
            }
        }

        private static void OpcoesFilmes()
        {
            string opcaoUsuario = ObterOpcaoUsuarioFilmes();


            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;

                    case "2":
                        InserirFilmes();
                        break;
                    case "3":
                        AtualizarFilmes();
                        break;
                    case "4":
                        ExcluirFilmes();
                        break;
                    case "5":
                        VisualizarFilmes();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    case "V":
                        MenuPrincipal();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuarioFilmes();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void VisualizarFilmes()
        {
            Console.WriteLine("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);
            Console.WriteLine(filme);
        }

        private static void ExcluirFilmes()
        {
            Console.WriteLine("Digite o ID da filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            Console.WriteLine("Deseja mesmo excluir este filme? Para excluir digite S senão digite N ");
            string confirmacao = Console.ReadLine();
            if (confirmacao == "S")
            {
                repositorioFilme.Exclui(indiceFilme);
            }
            else
            {
                ObterOpcaoUsuarioFilmes();
            }
        }

        private static void AtualizarFilmes()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entr as opções a acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(Id: indiceFilme,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
                );
            repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
        }

        private static void InserirFilmes()
        {
            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entr as opções a acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(Id: repositorioFilme.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
                );
            repositorioFilme.Insere(novoFilme);
        }

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filme");

            var lista = repositorioFilme.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma filme cadastrado.");
                return;
            }
            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static void OpcoesSeries()
        {
            string opcaoUsuario = ObterOpcaoUsuarioSeries();

            
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
                    case "V":
                        MenuPrincipal();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuarioSeries();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entr as opções a acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(Id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
                );
            repositorioSerie.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("Deseja mesmo excluir esta serie? Para excluir digite S senão digite N ");
            string confirmacao = Console.ReadLine();            
            if (confirmacao == "S")
            {
                repositorioSerie.Exclui(indiceSerie);
            }
            else
            {
                ObterOpcaoUsuarioSeries();
            }


            
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entr as opções a acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(Id: repositorioSerie.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
                );
            repositorioSerie.Insere(novaSerie);

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");

            var lista = repositorioSerie.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie cadastrada.");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }       
        }



        private static string ObterOpcaoUsuarioSeries()
        {
            Console.WriteLine();
            Console.WriteLine("Carlos Series a seu dispor!!");
            Console.WriteLine("Informe a opcao desejada: ");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("V - Voltar");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;



        }
        private static string ObterOpcaoUsuarioFilmes()
        {
            Console.WriteLine();
            Console.WriteLine("Carlos Filmes e Series a seu dispor!!");
            Console.WriteLine("Informe a opcao desejada: ");

            Console.WriteLine("1 - Listar Filmes");
            Console.WriteLine("2 - Inserir novo Filme");
            Console.WriteLine("3 - Atualizar Filmes");
            Console.WriteLine("4 - Excluir Filmes");
            Console.WriteLine("5 - Visualizar Filmes");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;



        }
    }
}
