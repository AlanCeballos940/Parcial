namespace ConsoleApp4.consola
{
    using System;
    using System.Linq;
    using Entidades;

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
                const int capacidad = 10; 
                AdministradorRombos administrador = new AdministradorRombos(capacidad);

                int opcion;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Ingresar rombo");
                    Console.WriteLine("2. Mostrar todos los rombos");
                    Console.WriteLine("3. Modificar un rombo");
                    Console.WriteLine("4. Mostrar estadísticas");
                    Console.WriteLine("5. Mostrar rombos con superficie superior al promedio");
                    Console.WriteLine("6. Salir");
                    Console.Write("Seleccione una opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            administrador.IngresarRombo();
                            break;
                        case 2:
                            administrador.MostrarRombos();
                            break;
                        case 3:
                            administrador.ModificarRombo();
                            break;
                        case 4:
                            administrador.MostrarEstadisticas();
                            break;
                        case 5:
                            administrador.MostrarRombosSuperiorPromedio();
                            break;
                    }

                } while (opcion != 6);
            }
        }

        class AdministradorRombos
        {
            private Rombo[] rombos;
            private int contador;

            public AdministradorRombos(int capacidad)
            {
                rombos = new Rombo[capacidad];
                contador = 0;
            }

            public bool EstaLleno()
            {
                return contador >= rombos.Length;
            }

            public void IngresarRombo()
            {
                if (EstaLleno())
                {
                    Console.WriteLine("El array de rombos está lleno.");
                    return;
                }

                Console.WriteLine("Ingrese la diagonal mayor del rombo:");
                double diagonalMayor = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese la diagonal menor del rombo:");
                double diagonalMenor = Convert.ToDouble(Console.ReadLine());

                Rombo rombo = new Rombo();
                rombo.AsignarDiagonales(diagonalMayor, diagonalMenor);
                rombos[contador++] = rombo;
            }

            public void MostrarRombos()
            {
                Console.WriteLine("Datos de los rombos:");
                for (int i = 0; i < contador; i++)
                {
                    Console.WriteLine($"Rombo {i + 1}:");
                    rombos[i].Informar();
                    Console.WriteLine();
                }
             

            }

            public void ModificarRombo()
            {
                MostrarRombos();
                Console.WriteLine("Ingrese el número del rombo que desea modificar:");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                if (index < 0 || index >= contador)
                {
                    Console.WriteLine("Número de rombo inválido.");
                    return;
                }

                Console.WriteLine("Ingrese la nueva diagonal mayor:");
                double diagonalMayor = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese la nueva diagonal menor:");
                double diagonalMenor = Convert.ToDouble(Console.ReadLine());

                rombos[index].AsignarDiagonales(diagonalMayor, diagonalMenor);
            }

            public void MostrarEstadisticas()
            {
                if (contador == 0)
                {
                    Console.WriteLine("No hay rombos para mostrar estadísticas.");
                    return;
                }

                double maxSuperficie = rombos[0].CalcularSuperficie();
                double minSuperficie = rombos[0].CalcularSuperficie();
                double sumaSuperficies = 0;

                foreach (var rombo in rombos.Take(contador))
                {
                    double superficie = rombo.CalcularSuperficie();
                    if (superficie > maxSuperficie) maxSuperficie = superficie;
                    if (superficie < minSuperficie) minSuperficie = superficie;
                    sumaSuperficies += superficie;
                }

                double promedioSuperficies = sumaSuperficies / contador;

                Console.WriteLine($"Rombo de mayor superficie: {maxSuperficie}");
                Console.WriteLine($"Rombo de menor superficie: {minSuperficie}");
                Console.WriteLine($"Promedio de superficies: {promedioSuperficies}");
            }

            public void MostrarRombosSuperiorPromedio()
            {
                if (contador == 0)
                {
                    Console.WriteLine("No hay rombos para comparar.");
                    return;
                }

                double sumaSuperficies = rombos.Take(contador).Sum(rombo => rombo.CalcularSuperficie());
                double promedioSuperficies = sumaSuperficies / contador;

                Console.WriteLine("Rombos con superficie superior al promedio:");
                foreach (var rombo in rombos.Take(contador))
                {
                    double superficie = rombo.CalcularSuperficie();
                    if (superficie > promedioSuperficies)
                    {
                        Console.WriteLine($"Superficie: {superficie}");
                    }
                }
            }
        }
    }

}
