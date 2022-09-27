using System;
using System.IO;
using System.Threading;
using System.Timers;

namespace PerguntaCronometrada
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        static int num1, num2, respostaCorreta, currentTime = 10;
        static int respostaUser = 0;
        static int tempo = 0;
        static int contador = 20;
        static string textoResultado;
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            contador = 20;
            Console.Clear();
            Console.WriteLine("---Pergunta Cronometrada---");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Qual operação matemática deseja testar seus conhecimentos?");
            Console.WriteLine("1 - SOMA");
            Console.WriteLine("2 - SUBTRAÇÃO");
            Console.WriteLine("3 - MULTIPLICAÇÃO");
            Console.WriteLine("4 - DIVISÃO");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("---------------------------");
            short respostaMenu = short.Parse(Console.ReadLine());
            switch (respostaMenu)
            {
                case 1: Soma(); break;
                //case 2: Subtracao(); break;
                //case 3: Multiplicacao(); break;
                //case 4: Divisao(); break;
                case 5: System.Environment.Exit(0); break;
                default: Console.WriteLine("Entre com um valor valido..."); Menu(); break;
            }
        }

        static void Soma()
        {
            contador = 20;

            Random random = new Random();
            num1 = random.Next(1, 100);
            num2 = random.Next(1, 100);
            respostaCorreta = (num1 + num2);

            SetTimer();
            Console.Clear();
            while ((currentTime > 0))
            {
                //Console.Clear();
                currentTime--;
                string pergunta = ($"Quanto custa {num1} + {num2}?");
                //entrando com os dados para ser salvo no arquivo

                Editar(pergunta);
                aTimer.Dispose();
                aTimer.Stop();

                break;
                Console.Clear();

            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalizado...");


            if (currentTime <= 0)
            {
                Console.WriteLine("Infelizmente você não respondeu a tempo");
            }

            do
            {

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        static void Editar(string pergunta)
        {
            Console.Clear();
            Console.WriteLine(pergunta);
            Console.WriteLine("Digite seu texto abaixo (Aperte A para sair)");
            Console.WriteLine("---------------------------------------");

            string text = "";

            do
            {

                //Faça enquanto esc não for precionado
                text += Console.ReadLine();
                text += Environment.NewLine;
            } while (Console.ReadKey().Key != ConsoleKey.A);


            Salvar(text);

        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            Console.WriteLine("---------------------------------------");
            // Path - Caminho
            var path = Console.ReadLine();
            //criando um arquivo e salvando a string dentro
            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }

        static void Cronometro(int num1, int num2)
        {
            int currentTime = 10;
            int respostaUser;
            while (currentTime > 0)
            {
                Console.Clear();
                Console.WriteLine($"Quanto custa {num1} + {num2}?");
                respostaUser = int.Parse(Console.ReadLine());
                currentTime--;
                Console.WriteLine(currentTime);
                Thread.Sleep(1000);

            }
            Console.Clear();
            Console.WriteLine("Stopwatch finalizado...");
            Thread.Sleep(2500);

            if (currentTime <= 0)
            {
                Console.WriteLine("Infelizmente você não respondeu a tempo");
            }


        }

        private static void SetTimer()
        {

            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;



        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            aTimer.Enabled = true;
            contador--;
            if (contador == 0)
            {
                Console.WriteLine("Infelizmente seu tempo acabou");
                aTimer.Enabled = false;
                Thread.Sleep(5000);

                Menu();

            }

        }

    }
}