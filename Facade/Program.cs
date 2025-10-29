using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Facherito";
            // Variables a utilizar
            string opcion = "";

            IEntretenimiento sistema = new SistemaEntretenimiento();

            do
            {
                
                Console.Clear();
                Console.WriteLine("====================================================");
                Console.WriteLine("|            SISTEMA DE ENTRETENIMIENTO            |");
                Console.WriteLine("====================================================");
                Console.WriteLine("| 1) Modo Cine                                     |");
                Console.WriteLine("| 2) Modo Juegos                                   |");
                Console.WriteLine("| 3) Apagar Todo                                   |");
                Console.WriteLine("====================================================");

                Console.Write("\nSeleccione una opción: ");
                opcion = Console.ReadLine();
                Console.Clear();

                // Ejecutar la opción seleccionada
                switch (opcion)
                {
                    case "1":
                        sistema.ModoCine();
                        break;

                    case "2":
                        sistema.ModoJuego();
                        break;

                    case "3":
                        sistema.ApagarTodo();
                        break;

                    default:
                        Console.WriteLine("Opción no válida...");
                        Console.WriteLine("Presione ENTER para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            } while (opcion != "3");
        }
    }
}
