﻿using CarlosSeries.Classes;
using System;

namespace CarlosSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
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
            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("Deseja mesmo excluir esta serie? Para excluir digite S senão digite N ");
            string confirmacao = Console.ReadLine();            
            if (confirmacao == "S")
            {
                repositorio.Exclui(indiceSerie);
            }
            else
            {
                ObterOpcaoUsuario();
            }


            
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
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

            Serie novaSerie = new Serie(Id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
                );
            repositorio.Insere(novaSerie);

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");

            var lista = repositorio.Lista();

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



        private static string ObterOpcaoUsuario()
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
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;



        }
    }
}
