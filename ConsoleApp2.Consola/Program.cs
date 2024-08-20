namespace ConsoleApp2.Consola
{
    using System;

    class Rombo
    {
        public double DiagonalMayor { get; set; }
        public double DiagonalMenor { get; set; }
        public double Lado { get; private set; }
        public double Perimetro { get; private set; }
        public double Superficie { get; private set; }

        public Rombo(double diagonalMayor, double diagonalMenor)
        {
            DiagonalMayor = diagonalMayor;
            DiagonalMenor = diagonalMenor;
            CalcularLado();
            CalcularPerimetro();
            CalcularSuperficie();
        }

        private void CalcularLado()
        {
            Lado = Math.Sqrt(Math.Pow(DiagonalMayor / 2, 2) + Math.Pow(DiagonalMenor / 2, 2));
        }

        private void CalcularPerimetro()
        {
            Perimetro = Lado * 4;
        }

        private void CalcularSuperficie()
        {
            Superficie = (DiagonalMayor * DiagonalMenor) / 2;
        }
    }

    class Program
    {
        static void Main()
        {
            const int cantidadRombos = 5;
            Rombo[] rombos = new Rombo[cantidadRombos];
            double mayorSuperficie = 0;
            int iteracionMayorSuperficie = 0;
            double sumaPerimetros = 0;

            for (int i = 0; i < cantidadRombos; i++)
            {
                Console.WriteLine($"Rombo {i + 1}:");

                double DM;
                do
                {
                    Console.Write("Ingrese el valor de la diagonal mayor (DM): ");
                    DM = Convert.ToDouble(Console.ReadLine());
                    if (DM <= 0)
                    {
                        Console.WriteLine("El valor de la diagonal mayor debe ser mayor que cero. Inténtelo de nuevo.");
                    }
                } while (DM <= 0);

                double dm;
                do
                {
                    Console.Write("Ingrese el valor de la diagonal menor (dm): ");
                    dm = Convert.ToDouble(Console.ReadLine());
                    if (dm <= 0)
                    {
                        Console.WriteLine("El valor de la diagonal menor debe ser mayor que cero. Inténtelo de nuevo.");
                    }
                } while (dm <= 0);

                rombos[i] = new Rombo(DM, dm);

                if (rombos[i].Superficie > mayorSuperficie)
                {
                    mayorSuperficie = rombos[i].Superficie;
                    iteracionMayorSuperficie = i + 1;
                }

                sumaPerimetros += rombos[i].Perimetro;

                Console.WriteLine($"Lado: {rombos[i].Lado}");
                Console.WriteLine($"Perímetro: {rombos[i].Perimetro}");
                Console.WriteLine($"Superficie: {rombos[i].Superficie}");
                Console.WriteLine();
            }

            
            Console.WriteLine($"El rombo de mayor tamaño tiene una superficie de {mayorSuperficie} y fue ingresado en la iteración {iteracionMayorSuperficie}.");

            
            double promedioPerimetros = sumaPerimetros / cantidadRombos;
            Console.WriteLine($"El promedio de los perímetros de los rombos ingresados es: {promedioPerimetros}");

            
         
        }
    }

}
