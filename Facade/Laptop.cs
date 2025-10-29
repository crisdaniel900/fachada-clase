using System;
using System.Threading;
namespace Facade
{
    public class Laptop
    {
        private string[] aplicaciones = { "MINECRAFT", "GTA V", "VRCHAT", "TERRARIA" };
        bool estado = false;

        public void Encender()
        {
            Console.Write("Encendiendo Laptop");
            
            Console.Write("Laptop encendida...");

            estado = true;

            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public void MostrarAplicaciones()
        {
            for (int i = 0; i < aplicaciones.Length; i++)
            {
                Console.WriteLine($"{i + 1} Aplicación {i + 1}: {aplicaciones[i]}");
            }
        }

        public void Apagar()
        {
            if (estado)
            {
                Console.Write("Apagando Laptop");
                
                Console.WriteLine("Laptop apagada");
            }
            else
            {
                Console.WriteLine("La laptop ya está apagada");
            }
        }
        public void AbrirAplicacion(int aplicacion)
        {
            Console.WriteLine($"Abriendo el juego {aplicaciones[aplicacion - 1]}");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    } 
}
