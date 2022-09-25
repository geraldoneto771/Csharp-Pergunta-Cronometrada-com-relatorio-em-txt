using System;


namespace PerguntaCronometrada
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {

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
            Console.Clear();
            Random random = new Random();
            int num1 = random.Next(1, 100);
            int num2 = random.Next(1, 100);
            int respostaCorreta = (num1 + num2);
            int respostaUser;


            do
            {
                Console.WriteLine($"Quanto custa {num1} + {num2}?");
                respostaUser = int.Parse(Console.ReadLine());
            }
            while (respostaUser != respostaCorreta);

            Console.WriteLine($"Parabéns {num1} + {num2} é: {respostaCorreta}!");
        }


    }
}