namespace ConsoleApp3.Consola
{
    using ConsoleApp3.Consola.Entidades;
    using System;

    namespace Entidades
    {
        public struct Rombo
        {
            public double DiagonalMayor { get; private set; }
            public double DiagonalMenor { get; private set; }

            public Rombo(double diagonalMayor, double diagonalMenor)
            {
                DiagonalMayor = diagonalMayor;
                DiagonalMenor = diagonalMenor;
            }

            public void AsignarDiagonales(double diagonalMayor, double diagonalMenor)
            {
                DiagonalMayor = diagonalMayor;
                DiagonalMenor = diagonalMenor;
            }

            public double CalcularLado()
            {
                return Math.Sqrt(Math.Pow(DiagonalMayor / 2, 2) + Math.Pow(DiagonalMenor / 2, 2));
            }

            public double CalcularPerimetro()
            {
                return 4 * CalcularLado();
            }

            public double CalcularSuperficie()
            {
                return (DiagonalMayor * DiagonalMenor) / 2;
            }

            public void Informar()
            {
                Console.WriteLine($"Diagonal Mayor: {DiagonalMayor}");
                Console.WriteLine($"Diagonal Menor: {DiagonalMenor}");
                Console.WriteLine($"Lado: {CalcularLado()}");
                Console.WriteLine($"Perímetro: {CalcularPerimetro()}");
                Console.WriteLine($"Superficie: {CalcularSuperficie()}");
            }

            public bool ValidarDiagonales()
            {
                return DiagonalMayor > 0 && DiagonalMenor > 0 && DiagonalMayor > DiagonalMenor;
            }
        }
    }

    namespace RomboConsola
    {
        class Program
        {
            static void Main(string[] args)
            {
                Rombo rombo = new Rombo();

                Console.WriteLine("Ingrese la diagonal mayor del rombo:");
                double diagonalMayor = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese la diagonal menor del rombo:");
                double diagonalMenor = Convert.ToDouble(Console.ReadLine());

                rombo.AsignarDiagonales(diagonalMayor, diagonalMenor);

                if (rombo.ValidarDiagonales())
                {
                    rombo.Informar();
                }
                else
                {
                    Console.WriteLine("Las diagonales ingresadas no son válidas.");
                }

                Console.ReadKey();
            }
        }
    }

}
