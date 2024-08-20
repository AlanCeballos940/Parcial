namespace ConsoleApp.Consola
{
    using System;

    class Program
    {
        static void Main()
        {
            
            Console.Write("Ingrese el valor de la diagonal mayor del rombo (DM): ");
            double DM = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el valor de la diagonal menor del rombo (dm): ");
            double dm = Convert.ToDouble(Console.ReadLine());

            
            double lado = Math.Sqrt(Math.Pow(DM / 2, 2) + Math.Pow(dm / 2, 2));

            
            double perimetro = lado * 4;

           
            double superficie = (DM * dm) / 2;

            
            Console.WriteLine($"Resultados:");
            Console.WriteLine($"Lado del rombo: {lado}");
            Console.WriteLine($"Perímetro del rombo: {perimetro}");
            Console.WriteLine($"Superficie del rombo: {superficie}");

           
         
        }
    }

}
